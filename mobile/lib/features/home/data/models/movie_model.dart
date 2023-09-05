import '../../domain/entities/movie.dart';

class MovieModel extends Movie {
  MovieModel(super.title, super.description, super.duration, super.image,
      super.rating, super.id);

  factory MovieModel.fromJson(Map<String, dynamic> json) {
    try {
      final MovieModel model = MovieModel(
          json["title"]!.toString(),
          json["description"]!.toString(),
          json["duration"]!.toString(),
          json["image"]!.toString(),
          json["rating"]!.toString(),
          json["id"]!.toString());
      return model;
    } catch (e) {
      print(e);
    }
    throw ("error happened");
  }

  Map<String, dynamic> toJson(MovieModel movie) {
    return {
      "title": movie.title,
      "description": movie.description,
      "rating": movie.rating,
      "id": movie.id,
      "image": movie.image,
      "duration": movie.duration
    };
  }
}
