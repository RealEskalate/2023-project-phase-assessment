import '../models/movie_model.dart';

abstract class MovieLocalDataSource {
  Future<List<MovieModel>> getAllMovies();

  Future<MovieModel> getMovie(String movieId);

  Future<void> cacheMovies(List<MovieModel> movies);

  Future<void> cacheMovie(MovieModel movie);

  Future<void> bookmarkMovie(MovieModel movie);

  Future<void> removeMovieFromBookmark(MovieModel movie);

  Future<List<MovieModel>> getBookmarkedMovies();
}
