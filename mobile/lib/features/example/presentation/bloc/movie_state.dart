part of 'movie_bloc.dart';

sealed class MovieState extends Equatable {
  const MovieState();

  @override
  List<Object> get props => [];
}

final class MovieInitial extends MovieState {}

class MovieLoaded extends MovieState {
  const MovieLoaded(this.movies,this.bookmarks);
  final List<Movie> movies;
  final List<Movie> bookmarks;
  @override
  List<Object> get props => [bookmarks,movies];
}

class MovieLoading extends MovieState {}
class MovieSearching extends MovieState {}


class MovieSearched extends MovieState {
  const MovieSearched(this.movies);
  final List<Movie> movies;
  @override
  List<Object> get props => [];
}


class Error extends MovieState {
  final String message;
  const Error({required this.message});
  @override
  List<Object> get props => [message];

}
