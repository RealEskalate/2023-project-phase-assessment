import 'package:dartz/dartz.dart';
import 'package:mobile/core/errors/failure.dart';
import 'package:mobile/features/example/domain/entities/MovieEntity.dart';

abstract class MovieRepository {
  Future<Either<Failure, List<MovieEntity>>> getAllMovies();
  Future<Either<Failure, MovieEntity>> getSingleMovie(String id);
  Future<Either<Failure, MovieEntity>> addToBookmark(MovieEntity movie);
  Future<Either<Failure, List<MovieEntity>>> filteredMovies(String title);

} 
