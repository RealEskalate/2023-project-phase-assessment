import '../../domain/entities/movie.dart';

class MovieModel extends Movie {
  const MovieModel({
    required super.id,
    required super.title,
    required super.category,
    required super.description,
    required super.duration,
    required super.image,
    required super.rating,
    required super.createdAt,
  });

  factory MovieModel.fromJson(Map<String, dynamic> json) {
    return MovieModel(
      id: json['id'],
      title: json['title'],
      category: json['category'],
      description: json['description'],
      duration: json['duration'],
      image: json['image'],
      rating: json['rating'],
      createdAt: DateTime.parse(json['createdAt']),
    );
  }

  Map<String, dynamic> toJson() {
    return {
      'id': super.id,
      'title': super.title,
      'category': super.category,
      'description': super.description,
      'duration': super.duration,
      'image': super.image,
      'rating': super.rating,
      'createdAt': super.createdAt.toIso8601String(),
    };
  }
}
