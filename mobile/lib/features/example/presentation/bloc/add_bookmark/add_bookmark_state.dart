import '../bloc_state.dart';

class AddingBookmarkState extends MoviesState {
  const AddingBookmarkState();

  @override
  List<Object> get props => [];
}

class AddedBookmarkState extends MoviesState {
  final bool isAdded;
  const AddedBookmarkState(this.isAdded);

  @override
  List<Object> get props => [];
}

class AddBookmarkError extends MoviesState {
  final String errorMessage;

  const AddBookmarkError(this.errorMessage);

  @override
  List<Object> get props => [errorMessage];
}
