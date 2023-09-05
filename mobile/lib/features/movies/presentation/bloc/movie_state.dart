part of 'movie_bloc.dart';

sealed class MovieState extends Equatable {

  final List<Movie> movies;
  final List<Movie> bookMarkedMovies;

  const MovieState({
    required this.movies,
    required this.bookMarkedMovies,
  });

  @override
  List<Object> get props => [movies, bookMarkedMovies];

}

final class MovieInitial extends MovieState {
  MovieInitial(): super(bookMarkedMovies: [], movies: []);
}

final class MovieLoading extends MovieState {
  MovieLoading({required super.bookMarkedMovies, required super.movies});
}
final class MovieLoaded extends MovieState {
  MovieLoaded({required super.bookMarkedMovies, required super.movies});
}
final class MovieErrorState extends MovieState {
  MovieErrorState({required super.movies, required super.bookMarkedMovies});
}
final class MovieSearchState extends MovieState {
  MovieSearchState({required super.movies, required super.bookMarkedMovies});
}
final class MovieSearchLoading extends MovieState {
  MovieSearchLoading({required super.movies, required super.bookMarkedMovies});
}


