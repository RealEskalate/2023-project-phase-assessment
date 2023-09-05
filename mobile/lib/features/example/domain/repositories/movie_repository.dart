import 'package:mobile/features/example/domain/entities/movie.dart';

abstract class MovieRepository {
  Future<List<MovieEntity>> getAllMovies();
  Future<MovieEntity> getSingleMovie(String id);
  Future<List<MovieEntity>> getBookmarks();
  Future<MovieEntity> addToBookmarks({
    required String category,
    required String title,
    required String description,
    required String duration,
    required String image,
    required double rating,
    required DateTime createdAt,
    required String id,
  });
  Future<void> removeFromBookmarks(String id);
}
