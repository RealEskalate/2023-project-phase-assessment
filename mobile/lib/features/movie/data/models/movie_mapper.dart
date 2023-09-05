import '../../domain/entities/movie.dart';

extension MovieMapper on Movie {
  Movie toMovieEntity() {
    return Movie(
      id: id,
      title: title,
      description: description,
      duration: duration,
      image: image,
      rating: rating,
      createdAt: createdAt,
      category: category,
    );
  }
}
