import 'package:mobile/features/get_all_movie/domain/entities/movie_entities.dart';

abstract class MovieRepository {
  Future<List<MovieEntities>> getAllMovies();
  Future<MovieEntities> getMovieDetail(String movieId);
}
