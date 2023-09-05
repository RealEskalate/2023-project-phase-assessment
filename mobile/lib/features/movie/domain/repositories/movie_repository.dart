import 'package:dartz/dartz.dart';

import '../../../../core/error/failure.dart';
import '../entities/movie_entity.dart';

abstract class MovieRepository {
  Future<Either<Failure, List<MovieEntity>>> getAllMovies();

  Future<Either<Failure, MovieEntity>> getMovie(String movieId);

  Future<Either<Failure, List<MovieEntity>>> searchMovies(String queryParams);

  Future<Either<Failure, void>> bookmarkMovie(MovieEntity movieEntity);

  Future<Either<Failure, void>> removeMovieFromBookmark(
      MovieEntity movieEntity);

  Future<Either<Failure, List<MovieEntity>>> getBookmarkedMovies();
}
