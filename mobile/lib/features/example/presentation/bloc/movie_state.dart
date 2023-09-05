part of 'movie_bloc.dart';

sealed class MovieState extends Equatable {
  const MovieState();

  @override
  List<Object> get props => [];
}

final class MovieInitial extends MovieState {}

final class MovieLoadingState extends MovieState {}

final class SingleMovieLoadedState extends MovieState {
  final MovieEntity movie;

  const SingleMovieLoadedState({required this.movie});

  @override
  List<Object> get props => [movie];
}

final class AllMoviesLoadedState extends MovieState {
  final List<MovieEntity> movies;

  const AllMoviesLoadedState({required this.movies});

  @override
  List<Object> get props => [movies];
}

final class FilteredMoviesLoadedState extends MovieState {
  final List<MovieEntity> movies;

  const FilteredMoviesLoadedState({required this.movies});

  @override
  List<Object> get props => [movies];
}

final class MovieErrorState extends MovieState {
  final String message;

  const MovieErrorState({required this.message});

  @override
  List<Object> get props => [message];
}
