import '../../models/movie_model.dart';

abstract class RemoteDataSource {
  Future<MovieModel> getMovie(String id);
  Future<List<MovieModel>> getMovies();
  Future<List<MovieModel>> filterMovies(String query);
}