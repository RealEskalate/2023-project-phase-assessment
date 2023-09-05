import 'package:dartz/dartz.dart';
import 'package:mobile/core/errors/failure.dart';
import 'package:mobile/features/example/domain/entities/movie.dart';

abstract class MovieRepository {
  Future<Either<Failure, List<Movie>>> getMovies();
  Future<Either<Failure, Movie>> getMovieById(String id);
  Future<Either<Failure, List<Movie>>> getMovieBySearch(String searchParams);
}
