import '../../domain/entities/movie.dart';

class MovieModel extends Movie {
  const MovieModel({
    required String id,
    required String title,
    required String description,
    required String duration,
    required String image,
    required String category,
    required double rating,
    required DateTime createdAt,
  }) : super(
          id: id,
          title: title,
          description: description,
          duration: duration,
          image: image,
          category: category,
          rating: rating,
          createdAt: createdAt,
        );

  factory MovieModel.fromJson(Map<String, dynamic> json) {
    return MovieModel(
      id: json['id'],
      title: json['title'],
      description: json['description'],
      duration: json['duration'],
      image: json['image'],
      category: json['category'],
      rating: json['rating'],
      createdAt: DateTime.parse(json['createdAt']),
    );
  }

  Map<String, dynamic> toJson() {
    return {
      'id': id,
      'title': title,
      'description': description,
      'duration': duration,
      'image': image,
      'category': category,
      'rating': rating,
      'createdAt': createdAt.toIso8601String(),
    };
  }
}
