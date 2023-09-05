part of 'get_movies_bloc.dart';

sealed class GetMoviesState extends Equatable {
  const GetMoviesState();
  
  @override
  List<Object> get props => [];
}

final class GetMoviesInitial extends GetMoviesState {}

class Onboarding extends GetMoviesState{}

class GettingMovies extends GetMoviesState {}

class GetMovies extends GetMoviesState {
    final List<Movie> movies;

  GetMovies({required this.movies});
}

class GetMoviesFailed extends GetMoviesState {}