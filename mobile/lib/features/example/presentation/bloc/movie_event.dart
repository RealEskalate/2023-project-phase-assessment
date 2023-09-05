part of 'movie_bloc.dart';

@immutable
sealed class MovieEvent {}

class GetMoviesEvent extends MovieEvent{
  
}
class SearchMovieEvent extends MovieEvent{
  final String query;
  SearchMovieEvent({required this.query});
}
