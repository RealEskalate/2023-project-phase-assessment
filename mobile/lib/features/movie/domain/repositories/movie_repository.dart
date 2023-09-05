import 'package:dartz/dartz.dart';

import '../../../../core/error/failure.dart';
import '../entities/movie.dart';

abstract class MovieRepository {
  Future<Either<Failure, List<Movie>>> getMovies();
  Future<Either<Failure, Movie>> getMovie(String id);
  Future<Either<Failure, List<Movie>>> searchMovies(String query);
}
