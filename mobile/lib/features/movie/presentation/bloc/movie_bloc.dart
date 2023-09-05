import 'package:flutter_bloc/flutter_bloc.dart';

import '../../../../core/usecase/usecase.dart';
import '../../domain/usecases/filter_movies.dart';
import '../../domain/usecases/get_movie.dart';
import '../../domain/usecases/get_movies.dart';
import 'movie_event.dart';
import 'movie_state.dart';

class MovieBloc extends Bloc<MovieEvent, MovieState> {
  final GetMovie getMovie;
  final GetMovies getAllMovies;
  final FilterMovies filterMovies;

  MovieBloc({
    required this.getMovie,
    required this.getAllMovies,
    required this.filterMovies,
  }) : super(MovieInitialState()) {
    on<GetSingleMovieEvent>(_getMovie);
    on<LoadAllMoviesEvent>(_getAllArticles);
    on<FilterMoviesEvent>(_filterArticles);
  }

  Future<void> _getMovie(
      GetSingleMovieEvent event, Emitter<MovieState> emit) async {
    emit(MovieLoadingState());

    final result = await getMovie(GetParams(id: event.id));

    result.fold(
      (failure) => emit(MovieErrorState(failure.toString())),
      (movie) => emit(MovieCreatedState(movie)),
    );
  }

  Future<void> _getAllArticles(
      LoadAllMoviesEvent event, Emitter<MovieState> emit) async {
    emit(MovieLoadingState());

    final result = await getAllMovies(NoParams());

    result.fold(
      (failure) => emit(MovieErrorState(failure.toString())),
      (articles) => emit(AllMoviesLoadedState(articles)),
    );
  }

  Future<void> _filterArticles(
      FilterMoviesEvent event, Emitter<MovieState> emit) async {
    final result = await filterMovies(FilterParams(query: event.searchParams));

    result.fold(
      (failure) => emit(MovieErrorState(failure.toString())),
      (articles) => emit(AllMoviesFilteredState(articles)),
    );
  }
}
