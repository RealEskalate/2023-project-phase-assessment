import 'package:equatable/equatable.dart';

class Movie extends Equatable {
  final String id;
  final String title;
  final String description;
  final String duration;
  final String image;
  final String category;
  final double rating;
  final DateTime createdAt;

  const Movie({
    required this.id,
    required this.title,
    required this.description,
    required this.duration,
    required this.image,
    required this.category,
    required this.rating,
    required this.createdAt,
  });

  @override
  List<Object?> get props =>
      [id, title, description, duration, image, category];
}
