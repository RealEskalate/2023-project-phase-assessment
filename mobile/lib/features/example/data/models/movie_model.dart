import 'package:mobile/features/example/domain/entities/movie_entity.dart';

class MovieModel extends MovieEntity {
  const MovieModel({
    required super.id,
    required super.title,
    required super.category,
    required super.description,
    required super.image,
    required super.createdAt,
    required super.duration,
    required super.rating,
  });

  factory MovieModel.fromJson(Map<String, dynamic> json) {
    return MovieModel(
      id: json['id'],
      title: json['title'],
      category: json['category'],
      description: json['descripition'],
      image: json['image'],
      createdAt: DateTime.parse(json['createdAt']),
      duration: json['duration'],
      rating: json['rating'],
    );
  }

  Map<String, dynamic> toJson() {
    return {
      'id': id,
      'title': title,
      'category': category,
      'description': description,
      'duration': duration,
      'createdAt': createdAt.toIso8601String(),
      'image': image,
      'rating': rating,
    };
  }
}
