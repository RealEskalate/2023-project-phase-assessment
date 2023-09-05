part of 'movie_bloc.dart';

sealed class MovieState extends Equatable {
  const MovieState();

  @override
  List<Object> get props => [];
}

final class MovieInitialState extends MovieState {}

final class SavedMovieLoadingState extends MovieState {}

final class AllMovieLoadingState extends MovieState {}
final class SearchMoviesLoadingState extends MovieState {}
final class GetMovieLoadingState extends MovieState {}
final class MoviesLoadedState extends MovieState {
  final List<MovieEntity> movies;

  const MoviesLoadedState({
    required this.movies,
  });

  @override
  List<Object> get props => [movies];
}

final class MovieDetailLoadedState extends MovieState {
  final MovieEntity movie;

  const MovieDetailLoadedState({
    required this.movie,
  });

  @override
  List<Object> get props => [movie];
}

final class MovieErrorState extends MovieState {
  final String message;

  const MovieErrorState({
    required this.message,
  });

  @override
  List<Object> get props => [message];
}

final class MovieBookmarkedState extends MovieState {}

final class MovieRemovedFromBookmarkState extends MovieState {}

final class MovieBookmarkedLoadedState extends MovieState {
  final List<MovieEntity> movies;

  const MovieBookmarkedLoadedState({
    required this.movies,
  });

  @override
  List<Object> get props => [movies];
}

final class SucessState extends MovieState {
  final String message;

  const SucessState({required this.message});

  @override
  List<Object> get props => [message];
}
