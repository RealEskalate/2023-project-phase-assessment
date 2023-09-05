class Movie {
  final String id;
  final String category;
  final String title;
  final String description;
  final String duration;
  final String image;
  final double rating;
  final DateTime createdAt;

  Movie({
    required this.id,
    required this.category,
    required this.title,
    required this.description,
    required this.duration,
    required this.image,
    required this.rating,
    required this.createdAt,
  });

  factory Movie.fromJson(Map<String, dynamic> json) {
    return Movie(
      id: json['_id'],
      category: json['category'],
      title: json['title'],
      description: json['description'],
      duration: json['duration'],
      image: json['image'],
      rating: json['rating'].toDouble(),
      createdAt: json['createdAt'],
    );
  }
}
