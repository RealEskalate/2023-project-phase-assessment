import '../../models/movie_model.dart';
abstract class RemoteDatasource {
  Future<MovieModel> getMovie(String id);
}
