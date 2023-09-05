import '../../models/movie_model.dart';

abstract class RemoteDatasource {
  Future<MovieModel> getMovie(String id);
  Future<List<MovieModel>> getAllMovies();
  Future<List<MovieModel>> filterMovies(String searchParams);
}
