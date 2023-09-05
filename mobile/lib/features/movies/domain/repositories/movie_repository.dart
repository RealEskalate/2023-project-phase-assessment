import 'package:dartz/dartz.dart';
import 'package:mobile/core/error/failure.dart';

import '../entities/movie.dart';

abstract class MovieRepository {
  Future<Either<Failure, List<Movie>>> getAllMovies();
  Future<Either<Failure, Movie>> getMovie(String id);
  Future<Either<Failure, List<Movie>>> searchMovies(String title);

  Future<Either<Failure, List<Movie>>> getSavedMovies();
  Future<Either<Failure, Movie>> addToSaved(Movie movie);
  Future<Either<Failure, Movie>> removeFromSaved(String movieId);
}
