import '../../domain/entities/movie.dart';
import 'movie_model.dart';

extension MovieMapper on Movie {
  MovieModel toMovieModel() {
    return MovieModel(
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
