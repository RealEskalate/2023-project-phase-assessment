part of 'movie_bloc.dart';

sealed class MovieState extends Equatable {
  const MovieState();
  
  @override
  List<Object> get props => [];
}

final class MovieInitial extends MovieState {}

class GettingMovies extends MovieState {
  const GettingMovies();
}

class MovieLoaded extends MovieState {
  final Movie movie;
  const MovieLoaded(this.movie);

  @override
  List<Object> get props => [movie.id];
}

class MoviesLoaded extends MovieState {
  final List<Movie> movies;
  const MoviesLoaded(this.movies);

  @override
  List<String> get props => movies.map((movie) => movie.id).toList();
}

class MvovieError extends MovieState {
  const MvovieError(this.message);
  final String message;

  @override
  List<String> get props =>[message];
}