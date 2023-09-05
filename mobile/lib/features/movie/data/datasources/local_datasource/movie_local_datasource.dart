import '../../models/movie_model.dart';

abstract class MovieLocalDataSource {
  Future<void> cacheMovies(List<MovieModel> movies);
  Future<void> cacheMovie(MovieModel movie);
  Future<List<MovieModel>> getMovies();
  Future<MovieModel> getMovie(String id);
  Future<List<MovieModel>> searchMovies(String query);
}
