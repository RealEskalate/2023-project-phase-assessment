import 'package:mobile/features/example/data/models/film_models.dart';

abstract class MovieState {}

class MoviesLoaded extends MovieState {
  final List<Movie> movies;

  MoviesLoaded(this.movies);
}

class MoviesError extends MovieState {
  final Exception error;

  MoviesError(this.error);
}
