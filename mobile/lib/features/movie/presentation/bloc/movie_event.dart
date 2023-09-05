// ignore_for_file: public_member_api_docs, sort_constructors_first
part of 'movie_bloc.dart';

sealed class MovieEvent extends Equatable {
  const MovieEvent();

  @override
  List<Object> get props => [];
}

class GetMoviesEvent extends MovieEvent {
  final String? query;
  const GetMoviesEvent({
    this.query,
  });

  @override
  List<Object> get props => [];
}


class SearchMoviesEvent extends MovieEvent {
  final String query;
  const SearchMoviesEvent({required this.query});

  @override
  List<Object> get props => [query];
}

class GetMovieDetailEvent extends MovieEvent {
  final String movieId;
  const GetMovieDetailEvent({required this.movieId});

  @override
  List<Object> get props => [movieId];
}

class BookmarkMovieEvent extends MovieEvent {
  final MovieEntity movie;
  const BookmarkMovieEvent({required this.movie});

  @override
  List<Object> get props => [movie];
}

class RemoveFromBookmarkMovieEvent extends MovieEvent {
  final MovieEntity movieEntity;
  const RemoveFromBookmarkMovieEvent({required this.movieEntity});

  @override
  List<Object> get props => [movieEntity];
}

class GetBookmarkedMoviesEvent extends MovieEvent {
  const GetBookmarkedMoviesEvent();

  @override
  List<Object> get props => [];
}
