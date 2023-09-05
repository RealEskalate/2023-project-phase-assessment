part of 'bookmark_bloc.dart';

sealed class BookmarkState extends Equatable {
  const BookmarkState();
  
  @override
  List<Object> get props => [];
}

final class BookmarkInitial extends BookmarkState {}


class Bookmarking extends BookmarkState{}
class Bookmarked extends BookmarkState{}
class BookmarkFailed extends BookmarkState{}