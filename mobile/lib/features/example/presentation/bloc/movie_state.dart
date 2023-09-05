part of 'movie_bloc.dart';

sealed class MovieState extends Equatable {
  const MovieState();
  
  @override
  List<Object> get props => [];
}

final class MovieInitial extends MovieState {}
final class MovieLoading extends MovieState{}

final class MovieLoaded extends MovieState{
  final List<Movie>movies;
  const MovieLoaded({
    required this.movies,
  });
}
final class AllMovieLoaded extends MovieState{
  final List<Movie>movies;
  const AllMovieLoaded({
    required this.movies,
  });
}
final class MovieError extends MovieState{
}
