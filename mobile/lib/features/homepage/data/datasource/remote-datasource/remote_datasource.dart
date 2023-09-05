import 'package:mobile/features/homepage/data/models/movie_model.dart';

abstract class RemoteDatasource {
  Future<List<MovieModel>> getAllMovies();
  Future<List<MovieModel>> searchMovies(String searchTerm);
}
