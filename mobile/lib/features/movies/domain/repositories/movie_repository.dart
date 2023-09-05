import 'package:dartz/dartz.dart';

import '../../../../core/error/failure.dart';
import '../entities/movie.dart';

abstract class MovieRepository {
  Future<Either<Failure, List<Movie>>> getAllMovies();
  Future<Either<Failure, List<Movie>>> getSearchMovies();
  Future<Either<Failure, Movie>> getMovieDetail(Movie movie);
}
