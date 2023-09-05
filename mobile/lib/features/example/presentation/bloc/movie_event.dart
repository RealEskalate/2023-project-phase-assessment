part of 'movie_bloc.dart';

sealed class MovieEvent extends Equatable {
  const MovieEvent();

  @override
  List<Object> get props => [];
}

class GetMovies extends MovieEvent {
 
}

class SearchMovies extends MovieEvent {
  const SearchMovies(this.s);
  final String s;

  @override
  List<Object> get props => [s];
}

class GetSingleMovie extends MovieEvent {
  const GetSingleMovie(this.id);
  final String id;

  @override
  List<Object> get props => [id];
}
class BookMarkMovie extends MovieEvent {
  const BookMarkMovie(this.movie);
  final Movie movie;

  @override
  List<Object> get props => [movie];
}
