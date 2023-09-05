part of 'bookmark_bloc.dart';

sealed class BookmarkEvent extends Equatable {
  const BookmarkEvent();

  @override
  List<Object> get props => [];
}

final class GetBookmarksEvent extends BookmarkEvent {}

final class AddToBookmarkEvent extends BookmarkEvent {
  final MovieEntity movie;

  const AddToBookmarkEvent(this.movie);

  @override
  List<Object> get props => [movie];
}

final class RemoveFromBookmarkEvent extends BookmarkEvent {
  final String id;

  const RemoveFromBookmarkEvent(this.id);

  @override
  List<Object> get props => [id];
}

