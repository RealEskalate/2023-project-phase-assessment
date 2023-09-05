import 'package:bloc/bloc.dart';
import 'package:equatable/equatable.dart';
import 'package:mobile/features/movies/domain/entities/movie.dart';
import 'package:mobile/features/movies/domain/repositories/movies_repository.dart';

part 'bookmark_state.dart';

class BookmarkCubit extends Cubit<BookmarkState> {
  MoviesRepository moviesRepository;
  BookmarkCubit({required this.moviesRepository}) : super(BookmarkInitial());
  void bookMarkMovie(Movie movie){
    moviesRepository.bookmarkMovie(movie);
    var result = moviesRepository.isBookmarked(movie);
    emit(BookMarkLoaded(movies: movie, isBookmarked: result));
  }
  void loadedBookMark(Movie movie){
    var result = moviesRepository.isBookmarked(movie);
    emit(BookMarkLoaded(movies: movie, isBookmarked: result));
  }
}
