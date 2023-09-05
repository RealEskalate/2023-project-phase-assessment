// ignore_for_file: public_member_api_docs, sort_constructors_first
import 'package:equatable/equatable.dart';

class MovieEntity extends Equatable {
  final String id;
  final String title;
  final String category;
  final String description;
  final String duration;
  final String image;
  final String createdAt;
  final String rating;

  const MovieEntity({
    required this.id,
    required this.title,
    required this.category,
    required this.description,
    required this.duration,
    required this.image,
    required this.createdAt,
    required this.rating,
  });

  @override
  List<Object?> get props =>
      [id, title, category, description, duration, image, createdAt, rating];
}
