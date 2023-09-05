import 'package:equatable/equatable.dart';

import '../../domain/entities/movie.dart';

abstract class MoviesState extends Equatable {
  const MoviesState();

  @override
  List<Object> get props => [];
}

class MoviesInitial extends MoviesState {}

class MoviesLoading extends MoviesState {}

class MoviesError extends MoviesState {
  final String errorMessage;

  MoviesError(this.errorMessage);

  @override
  List<Object> get props => [errorMessage];
}

class LoadedGetMoviesState extends MoviesState {
  final List<Movie> movies;

  const LoadedGetMoviesState(this.movies);

  @override
  List<Object> get props => [movies];
}
