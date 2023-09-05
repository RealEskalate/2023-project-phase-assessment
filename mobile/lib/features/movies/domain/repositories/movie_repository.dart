import '../../../../core/error/failure.dart';
import 'package:dartz/dartz.dart';

import '../entities/movie.dart';

abstract class MovieRepository {
  Future<Either<Failure, List<Movie>>> getAllMovies();
  Future<Either<Failure, Movie>> getSingleMovie(String movieId);
  Future<Either<Failure, List<Movie>>> searchMovie(String query);
}
