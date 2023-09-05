import 'package:mobile/features/example/domain/entities/movie.dart';

class MovieModel extends Movie {
  MovieModel({
    required super.title,
    required super.rating,
    required super.image,
    required super.duration,
    required super.description,
    required super.id,
  });
  factory MovieModel.fromJson(Map<String, dynamic> jsonMap) {
    return MovieModel(
      title: jsonMap["title"],
      rating: jsonMap["rating"],
      image: jsonMap["image"],
      duration: jsonMap["duration"],
      description: jsonMap["description"],
      id: jsonMap["id"],
    );
  }
}
