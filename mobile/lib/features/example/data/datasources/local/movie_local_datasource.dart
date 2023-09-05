import 'package:mobile/features/example/data/models/movie_model.dart';

abstract class LocalDatasource {
  Future<MovieModel> getMovie(String id);
  Future<List<MovieModel>> getMovies();
  Future<void> cacheMovie(MovieModel movie);
  Future<void> cacheMovies(List<MovieModel> movies);
  Future<List<MovieModel>> getBookmarkedMovies();
  Future<void> addMovieToBookmarks(MovieModel movie);
  Future<MovieModel> removeMovieFromBookmarks(String movieId);
}
