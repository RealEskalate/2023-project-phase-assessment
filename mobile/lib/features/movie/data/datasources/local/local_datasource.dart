import '../../models/movie_model.dart';

abstract class LocalDataSource {
  Future<MovieModel> getMovie(String id);

  Future<List<MovieModel>> getCachedMovies();
  Future<void> cacheMovie(MovieModel movie);
  Future<void> cacheMovies(List<MovieModel> movies);

  Future<void> getCachedBookMarkedMovies();
  Future<void> cacheBookMarkedMovie(MovieModel movie);
  Future<MovieModel> removeBookMarkedMovie(MovieModel movie);
  Future<void> cacheBookMarkedMovies(List<MovieModel> movie);
}