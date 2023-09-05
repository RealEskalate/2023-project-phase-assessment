import '../../domain/entities/movie.dart';

class MovieModel extends Movie {
  MovieModel({
    required super.id,
    required super.category,
    required super.title,
    required super.description,
    required super.duration,
    required super.image,
    required super.rating,
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

  Map<String, dynamic> toJson() {
    return {
      'id': id,
      'category': category,
      'title': title,
      'description': description,
      'duration': duration,
      'image': image,
      'rating': rating
    };
  }
}
