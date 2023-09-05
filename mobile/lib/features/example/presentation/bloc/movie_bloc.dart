import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:mobile/core/errors/failure.dart';
import 'package:mobile/core/usecase/usecase.dart';
import 'package:mobile/features/example/domain/usecases/get_all_movie_usecase.dart';
import 'package:mobile/features/example/domain/usecases/get_single_movie.dart';
import 'package:mobile/features/example/presentation/bloc/movie_events.dart';
import 'package:mobile/features/example/presentation/bloc/movie_states.dart';


const String SERVER_FAILURE_MESSAGE = 'Server Failure';
const String CACHE_FAILURE_MESSAGE = 'Cache Failure';

class MovieBloc extends Bloc<MovieEvent, MovieState> {
  final GetAllMovies viewAllMovies;
  final GetSingleMovie viewMovie;

  MovieBloc({
    required this.viewAllMovies,
    required this.viewMovie,
  }) : super(Initial()) {
    
    on<GetMovie>(_onGetMovie);
    on<GetAllMovie>(_onGetAllMovies as EventHandler<GetAllMovie, MovieState>);
  }




  void _onGetMovie(GetMovie event, Emitter<MovieState> emit) async {
    emit(Loading());
    final result = await viewMovie(Params(id: event.id));
    result.fold(
      (failure) => emit(Error(message: _mapFailureToMessage(failure))),
      (movie) => emit(ViewOne(movie: movie)),
    );
  }

  void _onGetAllMovies(
      GetAllMovies event, Emitter<MovieState> emit) async {
    emit(Loading());
    final result = await viewAllMovies(NoParams());
    result.fold(
      (failure) => emit(Error(message: _mapFailureToMessage(failure))),
      (movies) => emit(ViewAll(movies: movies)),
    );
  }

  String _mapFailureToMessage(Failure failure) {
    switch (failure.runtimeType) {
      case ServerFailure:
        return SERVER_FAILURE_MESSAGE;
      case CacheFailure:
        return CACHE_FAILURE_MESSAGE;

      default:
        return 'Unexpected Error';
    }
  }
}    