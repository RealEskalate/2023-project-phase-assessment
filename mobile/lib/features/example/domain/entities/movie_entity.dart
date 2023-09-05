import 'package:equatable/equatable.dart';

class MovieEntity extends Equatable {
  final String id;
  final String category;
  final String title;
  final String description;
  final String duration;
  final String image;
  final String rating;
  final DateTime createdAt;

  const MovieEntity({
    required this.id,
    required this.category,
    required this.title,
    required this.description,
    required this.duration,
    required this.image,
    required this.rating,
    required this.createdAt,
  });

  @override
  List<Object?> get props => [
        id,
        category,
        title,
        description,
        duration,
        image,
        rating,
        createdAt,
      ];
}
