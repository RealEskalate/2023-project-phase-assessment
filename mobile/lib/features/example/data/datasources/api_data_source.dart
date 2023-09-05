import 'package:dartz/dartz.dart';
import 'package:mobile/features/example/data/models/model.dart';

abstract class MovieRemoteDataSource {
  Future<List<Movie>> getAllMovies();
  Future<Movie> getSingleMovie(String movieId);
  Future<List<Movie>> searchMovies(String query);
  // get tags
}
