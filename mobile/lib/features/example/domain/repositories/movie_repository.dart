import 'package:dartz/dartz.dart';
import 'package:mobile/features/example/domain/entities/movie_entity.dart';

import '../../../../core/error/failure.dart';

abstract class MovieRepository {
  Future<Either<Failure, MovieEntity>> getMovie(String id);
  Future<Either<Failure, List<MovieEntity>>> getAllMovies();
  Future<Either<Failure, List<MovieEntity>>> filterMovies(String searchParams);

  Future<Either<Failure, List<MovieEntity>>> getBookmarkedMovies();
  Future<Either<Failure, MovieEntity>> addToBookmark(MovieEntity movie);
  Future<Either<Failure, MovieEntity>> removeFromBookmark(String movieId);
}
