import '../models/movie_model.dart';

abstract class MovieRemoteDataSource {
  Future<List<MovieModel>> getAllMovies();

  Future<MovieModel> getMovie(String movieId);

  Future<List<MovieModel>> searchMovies(String queryParams);
}
