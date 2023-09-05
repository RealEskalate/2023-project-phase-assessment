// ignore_for_file: public_member_api_docs, sort_constructors_first
class Movie {
  final String id;
  final String category;
  final String title;
  final String description;
  final String duration;
  final String image;
  final String rating;
  final String createdAt;
  final bool isBookmarked;

  Movie({
    required this.id,
    required this.category,
    required this.title,
    required this.description,
    required this.duration,
    required this.image,
    required this.rating,
    required this.createdAt,
    this.isBookmarked = false,
  });

  
  
}
