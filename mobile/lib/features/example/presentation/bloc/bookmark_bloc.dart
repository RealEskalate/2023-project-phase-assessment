import 'package:bloc/bloc.dart';
import 'package:equatable/equatable.dart';
import 'package:mobile/features/example/domain/entities/movie_entity.dart';

import '../../../../core/usecase/usecase.dart';
import '../../domain/usecases/usecases.dart';

part 'bookmark_event.dart';
part 'bookmark_state.dart';

class BookmarkBloc extends Bloc<BookmarkEvent, BookmarkState> {
  final AddToBookmark addToBookmark;
  final RemoveFromBookmark removeFromBookmark;
  final GetBookmarks getBookmarks;

  BookmarkBloc({
    required this.addToBookmark,
    required this.removeFromBookmark,
    required this.getBookmarks,
  }) : super(BookmarkInitialState()) {
    on<GetBookmarksEvent>(_getBookmarks);
    on<AddToBookmarkEvent>(_addToBookmark);
    on<RemoveFromBookmarkEvent>(_removeFromBookmark);
  }

  Future<void> _getBookmarks(
      GetBookmarksEvent event, Emitter<BookmarkState> emit) async {
    emit(BookmarkLoadingState());

    final result = await getBookmarks(NoParams());

    result.fold(
      (failure) => emit(
        BookmarkErrorState(
          failure.toString(),
        ),
      ),
      (articles) => emit(
        BookmarkLoadedState(articles),
      ),
    );
  }

  Future<void> _addToBookmark(
      AddToBookmarkEvent event, Emitter<BookmarkState> emit) async {
    emit(BookmarkLoadingState());

    final result = await addToBookmark(AddToBookmarkParams(movie: event.movie));

    result.fold(
      (failure) => emit(
        BookmarkErrorState(
          failure.toString(),
        ),
      ),
      (article) => emit(
        BookmarkAddedState(article),
      ),
    );
  }

  Future<void> _removeFromBookmark(
      RemoveFromBookmarkEvent event, Emitter<BookmarkState> emit) async {
    emit(BookmarkLoadingState());

    final result =
        await removeFromBookmark(RemoveFromBookmarkParams(id: event.id));

    result.fold(
      (failure) => emit(
        BookmarkErrorState(
          failure.toString(),
        ),
      ),
      (article) => emit(
        BookmarkRemovedState(article),
      ),
    );
  }
}
