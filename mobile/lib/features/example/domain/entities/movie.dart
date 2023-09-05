import 'package:equatable/equatable.dart';

class Movie extends Equatable {
  final String title;
  final double rating;
  final String image;
  final String duration;
  final String description;
  final String id;

  Movie({
    required this.title,
    required this.rating,
    required this.image,
    required this.duration,
    required this.description,
    required this.id,
  });

  @override
  List<Object> get props => [title, rating, image, duration, description, id];
}
