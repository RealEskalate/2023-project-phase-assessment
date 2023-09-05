import 'package:equatable/equatable.dart';

import '../../domain/entities/movie.dart';


sealed class MovieState extends Equatable {
  const MovieState();

  @override
  List<Object> get props => [];
}

final class MovieInitialState extends MovieState {}

final class MovieLoadingState extends MovieState {}

final class SingleMovieLoadedState extends MovieState {
  final Movie movie;

  const SingleMovieLoadedState(this.movie);

  @override
  List<Object> get props => [movie];
}

final class AllMoviesLoadedState extends MovieState {
  final List<Movie> movies;

  const AllMoviesLoadedState(this.movies);

  @override
  List<Object> get props => [movies];
}

final class AllMoviesFilteredState extends MovieState {
  final List<Movie> movies;

  const AllMoviesFilteredState(this.movies);

  @override
  List<Object> get props => [movies];
}

final class MovieCreatedState extends MovieState {
  final Movie movie;

  const MovieCreatedState(this.movie);

  @override
  List<Object> get props => [movie];
}

final class MovieUpdatedState extends MovieState {
  final Movie movie;

  const MovieUpdatedState(this.movie);

  @override
  List<Object> get props => [movie];
}

final class MovieDeletedState extends MovieState {
  final Movie movie;

  const MovieDeletedState(this.movie);

  @override
  List<Object> get props => [movie];
}

final class MovieErrorState extends MovieState {
  final String message;

  const MovieErrorState(this.message);

  @override
  List<Object> get props => [message];
}
