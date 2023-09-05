import 'package:bloc/bloc.dart';
import 'package:equatable/equatable.dart';
import 'package:mobile/features/home/domain/entities/movie.dart';
import 'package:mobile/features/home/domain/usecases/get_movies.dart';

import '../../../../injection/injection_container.dart';
import '../../domain/usecases/search_movies.dart';

part 'home_event.dart';
part 'home_state.dart';

class HomeBloc extends Bloc<HomeEvent, HomeState> {
  HomeBloc() : super(HomeInitial()) {
    final GetMovies getMovies = sl();
    final SearchForMovies searchMovies = sl();
    on<HomeEvent>((event, emit) async {
      if (event is GetAllMovies) {
        emit(Loading());
        final response = await getMovies.call();
        response.fold(
            (error) => emit(Error(
                message: "Error occured getting movies. Please try again")),
            (movies) => emit(Loaded(movies: movies)));
      } else if (event is SearchMovies) {
        emit(Loading());
        final response = await searchMovies.call(event.term);
        response.fold(
            (error) => emit(Error(
                message:
                    "Error occured searching for movies. Please try again")),
            (movies) => emit(Loaded(movies: movies)));
      }
    });
  }
}
