import '../../../domain/entities/movie.dart';
import '../bloc_state.dart';
import '../../../data/models/movie.dart' as moviemodel;

class BookmarkLoading extends MoviesState {}

class BookmarkError extends MoviesState {
  final String errorMessage;

  BookmarkError(this.errorMessage);

  @override
  List<Object> get props => [errorMessage];
}

class LoadedBookmarksState extends MoviesState {
  final List<moviemodel.MovieModel> movie;

  const LoadedBookmarksState(this.movie);

  @override
  List<Object> get props => [movie];
}
