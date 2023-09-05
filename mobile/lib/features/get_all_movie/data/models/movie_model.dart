import 'package:mobile/features/get_all_movie/domain/entities/movie_entities.dart';

class MovieModel {
  final String id;
  final String category;
  final String title;
  final String description;
  final String duration;
  final String image;
  final double rating;

  MovieModel({
    required this.id,
    required this.category,
    required this.title,
    required this.description,
    required this.duration,
    required this.image,
    required this.rating,
  });

  factory MovieModel.fromJson(Map<String, dynamic> json) {
    return MovieModel(
      id: json['id'],
      category: json['category'],
      title: json['title'],
      description: json['description'],
      duration: json['duration'],
      image: json['image'],
      rating: json['rating'].toDouble(),
    );
  }

  MovieEntities toEntity() {
    return MovieEntities(
      id: id,
      category: category,
      title: title,
      description: description,
      duration: duration,
      image: image,
      rating: rating,
    );
  }
}
