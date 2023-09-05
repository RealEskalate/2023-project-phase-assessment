import 'package:equatable/equatable.dart';

class Movie extends Equatable {
  final String id;
  final String title;
  final String category;
  final String description;
  final String duration;
  final String image;
  final double rating;
  final DateTime createdAt;

  const Movie({
    required this.id,
    required this.title,
    required this.category,
    required this.description,
    required this.duration,
    required this.image,
    required this.rating,
    required this.createdAt,
  });
  
  @override
  List<Object?> get props => [
    id,
    title,
    category,
    description,
    duration,
    image,
    rating,
    createdAt,
  ];
}
