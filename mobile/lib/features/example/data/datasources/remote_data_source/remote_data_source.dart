import 'package:mobile/features/example/data/models/movie_model.dart';

abstract class RemoteSource{
  Future<List<MovieModel>> getAllMovies();
  Future<MovieModel> getOneMovie(String? id);
}