import 'package:equatable/equatable.dart';
import 'package:mobile/features/movies/domain/entities/movie.dart';

abstract class MovieState extends Equatable {
  const MovieState();

  @override
  List<Object> get props => [];
}

class MovieInitial extends MovieState {}

class MovieLoading extends MovieState {}

class MovieError extends MovieState {
  final String errorMessage;

  MovieError(this.errorMessage);

  @override
  List<Object> get props => [errorMessage];
}

class AllMoviesLoaded extends MovieState {
  final List<Movie> movies;

  const AllMoviesLoaded(this.movies);

  @override
  List<Object> get props => [movies];
}
