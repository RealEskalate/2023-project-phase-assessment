import '../../models/movie_model.dart';

abstract class MovieLocalDataSource {
  Future<MovieModel> getMovie(String id);
  Future<List<MovieModel>> getMovies();

  Future<void> cacheMovie(MovieModel movie);
  Future<void> cacheMovies(List<MovieModel> movies);

  Future<List<MovieModel>> getSavedMovies();
  Future<void> addToSaved(MovieModel movie);
  Future<MovieModel> removeFromSaved(String movieId);
}
