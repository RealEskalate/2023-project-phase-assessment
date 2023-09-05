import '../../models/movie_model.dart';

abstract class MovieRemoteDataSource {
  Future<List<MovieModel>> getAllMovies();
  Future<List<MovieModel>> searchMovies(String title);
  Future<MovieModel> getMovie(String id);
}
