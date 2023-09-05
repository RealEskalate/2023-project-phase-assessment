import 'package:mobile/features/search/domain/entities/search_entities.dart';

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
      id: json['_id'],
      category: json['category'],
      title: json['title'],
      description: json['description'],
      duration: json['duration'],
      image: json['image'],
      rating: json['rating'].toDouble(),
    );
  }

  Movie toEntity() {
    return Movie(
      id: this.id,
      category: this.category,
      title: this.title,
      description: this.description,
      duration: this.duration,
      image: this.image,
      rating: this.rating,
    );
  }
}
