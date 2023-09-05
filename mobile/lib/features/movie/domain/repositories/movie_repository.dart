import 'package:dartz/dartz.dart';

import '../../../../core/error/failures.dart';
import '../entities/movie.dart';

abstract class MovieRepository {
  Future<Either<Failure, List<Movie>>> getMovies();
  Future<Either<Failure, Movie>> getMovie();
  Future<Either<Failure, List<Movie>>> filterMovies(String query);
  Future<Either<Failure, Movie>> bookmarkMovie(Movie movie);
  Future<Either<Failure, Movie>> unbookmarkMovie(Movie movie);
  Future<Either<Failure, List<Movie>>> getBookmarkedMovies();
}
