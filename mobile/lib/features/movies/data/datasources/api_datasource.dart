import 'package:dartz/dartz.dart';
import 'package:mobile/features/movies/domain/entities/movie.dart';

abstract class MovieRemoteDataSource {
  Future<List<Movie>> getAllMovies();
  Future<Movie> getSingleMovie(String movieId);
  Future<List<Movie>> searchMovies(String query);
  // get tags
}
