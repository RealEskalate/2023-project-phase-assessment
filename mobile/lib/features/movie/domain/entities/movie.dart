import 'package:equatable/equatable.dart';

class Movie extends Equatable {
  final String id;
  final String category;
  final String description;
  final String title;
  final String duration;
  final String rating;
  final String image;
  final String createdAt;
  Movie({
    required this.id,
    required this.category,
    required this.description,
    required this.title,
    required this.duration,
    required this.rating,
    required this.image,
    required this.createdAt,
  });

  Movie.empty()
      : this(
          id: "-1",
          image: "_empty.image",
          category: "_empty.category",
          description: "_empty.description",
          title: "_empty.title",
          duration: "_empty.duration",
          rating: "_empty.rating",
          createdAt: "_empty.createdAt",
        );

  @override
  List<Object?> get props => [id, category, createdAt, title, duration];
}
