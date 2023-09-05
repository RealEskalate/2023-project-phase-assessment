import 'package:dartz/dartz.dart';
import '../../../../core/error/failure.dart';
import '../../domain/entities/movie.dart';
import '../models/movie.dart';

abstract class MovieRemoteDataSource {
  Future<List<Movie>> getAllMovies();
  Future<List<Movie>> searchMovie(String key);
  Future<Either<Failure, Movie>> getSingleMovie(String movieId);
}

abstract class MoviesLocalDataSource {
  Future<Either<Failure, List<MovieModel>>> getAllMovies();
  Future<Either<Failure, List<MovieModel>>> getAllBookmarks();
  Future<List<MovieModel>> searchMovie(String tag, String key);
  Future<Either<Failure, MovieModel>> getSingleMovie(String movieId);
  Future<Either<Failure, bool>> addBookmark(Map<String, dynamic> movieData);
}
