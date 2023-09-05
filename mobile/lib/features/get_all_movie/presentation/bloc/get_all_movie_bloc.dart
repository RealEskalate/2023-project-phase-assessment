import 'package:bloc/bloc.dart';
import 'package:equatable/equatable.dart';

part 'get_all_movie_event.dart';
part 'get_all_movie_state.dart';

class GetAllMovieBloc extends Bloc<GetAllMovieEvent, GetAllMovieState> {
  GetAllMovieBloc() : super(GetAllMovieInitial()) {
    on<GetAllMovieEvent>((event, emit) {
      // TODO: implement event handler
    });
  }
}
