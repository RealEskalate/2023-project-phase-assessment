import 'package:equatable/equatable.dart';

class Movie extends Equatable {
  final String id;
  final String category;
  final String title;
  final String description;
  final String duration;
  final String image;
  final double rating;

  const Movie({
    required this.id,
    required this.category,
    required this.title,
    required this.description,
    required this.duration,
    required this.image,
    required this.rating,
  });

  static get empty => const Movie(
        id: '',
        category: '',
        title: '',
        description: '',
        duration: '',
        image: '',
        rating: 0,
      );

  @override
  List<Object?> get props => [
        id,
        category,
        title,
        description,
        duration,
        image,
        rating,
      ];
}
