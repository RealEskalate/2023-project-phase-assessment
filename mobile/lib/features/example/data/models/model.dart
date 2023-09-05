class Movie {
  final String category;
  final String title;
  final String description;
  final String duration;
  final String image;
  final double rating;
  final DateTime createdAt;
  final String id;

  Movie({
    required this.category,
    required this.title,
    required this.description,
    required this.duration,
    required this.image,
    required this.rating,
    required this.createdAt,
    required this.id,
  });

  factory Movie.fromJson(Map<String, dynamic> json) {
    return Movie(
      category: json['category'],
      title: json['title'],
      description: json['description'],
      duration: json['duration'],
      image: json['image'],
      rating: json['rating'].toDouble(),
      createdAt: DateTime.parse(json['createdAt']),
      id: json['id'],
    );
  }

  Map<String, dynamic> toJson() {
    return {
      'category': category,
      'title': title,
      'description': description,
      'duration': duration,
      'image': image,
      'rating': rating,
      'createdAt': createdAt.toIso8601String(),
      'id': id,
    };
  }
}
