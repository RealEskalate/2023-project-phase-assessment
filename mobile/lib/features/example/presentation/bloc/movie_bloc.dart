import 'package:mobile/features/example/domain/usecases/getmovies.dart';
import 'package:mobile/features/example/presentation/bloc/movie_event.dart';
import 'package:mobile/features/example/presentation/bloc/movie_state.dart';

import 'package:flutter_bloc/flutter_bloc.dart';

class MovieBloc extends Bloc<MovieEvent, MovieState> {
  final FetchMoviesUseCase fetchMoviesUseCase;

  MovieBloc({required this.fetchMoviesUseCase}) : super(MoviesLoaded([]));

  @override
  Stream<MovieState> mapEventToState(MovieEvent event) async* {
    if (event is FetchMoviesEvent) {
      try {
        final result = await fetchMoviesUseCase.execute();
        yield result.fold(
          (error) => MoviesError(error),
          (movies) => MoviesLoaded(movies),
        );
      } catch (e) {
        yield MoviesError(Exception('Failed to fetch movies: $e'));
      }
    }
  }
}
