import 'package:dartz/dartz.dart';
import 'package:mobile/core/failure.dart';
import 'package:mobile/features/movies/domain/entities/movie.dart';

abstract class MoviesRepository {
  Future<Either<Failure, List<Movie>>> getMovies({searchParams = String,});
  bool isBookmarked(Movie movie);
  void bookmarkMovie(Movie movie);
  void unBookmarkMovie(Movie movie);
  List<Movie> getBookmarkedMovies();
}