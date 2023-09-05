import 'package:mobile/features/movie/domain/entities/movie_entity.dart';

class MovieModel extends MovieEntity {
  const MovieModel({
    required String id,
    required String title,
    required String category,
    required String description,
    required String duration,
    required String image,
    required String createdAt,
    required String rating,
  }) : super(
          id: id,
          title: title,
          category: category,
          description: description,
          duration: duration,
          image: image,
          createdAt: createdAt,
          rating: rating,
        );

  factory MovieModel.fromJson(Map<String, dynamic> json) {
    return MovieModel(
      id: json['_id'],
      title: json['title'],
      category: json['category'],
      description: json['description'],
      duration: json['duration'],
      image: json['image'],
      createdAt: json['createdAt'],
      rating: json['rating'],
    );
  }

  Map<String, dynamic> toJson() {
    return {
      '_id': id,
      'title': title,
      'category': category,
      'description': description,
      'duration': duration,
      'image': image,
      'createdAt': createdAt,
      'rating': rating,
    };
  }
}
