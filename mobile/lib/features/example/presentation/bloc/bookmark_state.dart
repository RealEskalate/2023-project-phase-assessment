part of 'bookmark_bloc.dart';

sealed class BookmarkState extends Equatable {
  const BookmarkState();
  
  @override
  List<Object> get props => [];
}

final class BookmarkInitialState extends BookmarkState {}

final class BookmarkLoadingState extends BookmarkState {}

final class BookmarkLoadedState extends BookmarkState {
  final List<MovieEntity> movies;

  const BookmarkLoadedState(this.movies);

  @override
  List<Object> get props => [movies];
}

final class BookmarkAddedState extends BookmarkState {
  final MovieEntity movie;

  const BookmarkAddedState(this.movie);

  @override
  List<Object> get props => [movie];
}

final class BookmarkRemovedState extends BookmarkState {
  final MovieEntity movie;

  const BookmarkRemovedState(this.movie);

  @override
  List<Object> get props => [movie];
}

final class BookmarkErrorState extends BookmarkState {
  final String message;

  const BookmarkErrorState(this.message);

  @override
  List<Object> get props => [message];
}

