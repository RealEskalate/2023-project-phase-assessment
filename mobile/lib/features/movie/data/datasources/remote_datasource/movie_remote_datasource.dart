import '../../models/movie_model.dart';

abstract class MovieRemoteDataSource {
  Future<List<MovieModel>> getMovies();
  Future<MovieModel> getMovie(String id);
  Future<List<MovieModel>> searchMovies(String query);
}
