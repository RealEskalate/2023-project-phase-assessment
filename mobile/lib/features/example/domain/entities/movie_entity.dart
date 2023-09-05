// features/domain/entities/movie_entity.dart

class MovieEntity {
  final String? id;
  final String? title;
  final String? description;
  final String? duration;
  final String? image;
  final double? rating;

  MovieEntity({
    this.id,
    this.title,
    this.description,
    this.duration,
    this.image,
    this.rating,
  });

  static fromJson(movieData) {}
}
