import 'dart:async';

import 'package:bloc/bloc.dart';
import 'package:equatable/equatable.dart';
import 'package:mobile/core/usecase/usecase.dart';
import 'package:mobile/features/example/domain/entities/movie_entity.dart';

import '../../domain/usecases/usecases.dart';

part 'movie_event.dart';
part 'movie_state.dart';

class MovieBloc extends Bloc<MovieEvent, MovieState> {
  final GetMovie getMovie;
  final GetAllMovies getAllMovies;
  final FilterMovies filterMovies;

  MovieBloc({
    required this.getMovie,
    required this.getAllMovies,
    required this.filterMovies,
  }) : super(MovieInitial()) {
    on<LoadSingleMovieEvent>(_onGetMovie);
    on<LoadAllMoviesEvent>(_onGetAllMovies);
    on<FilterMoviesEvent>(_onFilterMovies);
  }

  FutureOr<void> _onGetMovie(
      LoadSingleMovieEvent event, Emitter<MovieState> emit) async {
    emit(MovieLoadingState());
    final movieOrError = await getMovie(GetParams(id: event.id));

    movieOrError.fold(
      (failure) => emit(
        MovieErrorState(
          message: failure.toString(),
        ),
      ),
      (movie) => emit(
        SingleMovieLoadedState(movie: movie),
      ),
    );
  }

  FutureOr<void> _onGetAllMovies(
      LoadAllMoviesEvent event, Emitter<MovieState> emit) async {
    emit(MovieLoadingState());
    final moviesOrError = await getAllMovies(NoParams());

    moviesOrError.fold(
      (failure) => emit(
        MovieErrorState(
          message: failure.toString(),
        ),
      ),
      (movies) => emit(
        AllMoviesLoadedState(movies: movies),
      ),
    );
  }

  FutureOr<void> _onFilterMovies(
      FilterMoviesEvent event, Emitter<MovieState> emit) async {
    emit(MovieLoadingState());

    final moviesOrError = await filterMovies(
      FilterParams(searchParams: event.searchParams),
    );

    moviesOrError.fold(
      (failure) => emit(
        MovieErrorState(
          message: failure.toString(),
        ),
      ),
      (movies) => emit(
        FilteredMoviesLoadedState(movies: movies),
      ),
    );
  }
}
