import 'package:bloc/bloc.dart';
import 'package:equatable/equatable.dart';
import 'package:mobile/features/example/domain/entities/movie.dart';
import 'package:mobile/features/example/domain/usecases/get_movie_by_id.dart';

part 'movie_id_event.dart';
part 'movie_id_state.dart';

class MovieIdBloc extends Bloc<MovieIdEvent, MovieIdState> {
  GetMovieById getMovieById;
  MovieIdBloc({required this.getMovieById}) : super(MovieIdInitial()) {
    on<GiveMeSpecificDetail>((GiveMeSpecificDetail event, emit) async {
      final result = await getMovieById(event.id);
      result.fold((l) => null, (r) => emit(MovieIdLoaded(movie: r)));
    });
  }
}
