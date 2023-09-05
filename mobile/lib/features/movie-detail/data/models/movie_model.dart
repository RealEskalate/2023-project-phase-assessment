import '../../domain/entity/movie.dart';

class MovieModel extends Movie {
  MovieModel(
      {required super.id,
      required super.category,
      required super.Title,
      required super.Description,
      required super.Duration,
      required super.image});

  factory MovieModel.fromJson(Map<String, dynamic> json) {
    return MovieModel(
        id: json['id'],
        category: json['category'],
        Title: json['Title'],
        Description: json['Description'],
        Duration: json['Duration'],
        image: json['image']);
  }
}
