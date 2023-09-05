part of 'bookmark_cubit.dart';

sealed class BookmarkState extends Equatable {
  const BookmarkState();

  @override
  List<Object> get props => [];
}

final class BookmarkInitial extends BookmarkState {

}
final class BookMarkLoaded extends BookmarkState {
  final Movie movies;
  final bool isBookmarked;
  const BookMarkLoaded({required this.movies, required this.isBookmarked});
  @override
  List<Object> get props => [movies, isBookmarked];
}
