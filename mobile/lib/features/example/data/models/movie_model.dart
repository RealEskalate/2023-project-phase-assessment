class MovieModel {
  final String title;
  final String description;
  final String image;
  final String duration;
  final String category;
  final String rating;

  MovieModel({
    required this.title,
    required this.description,
    required this.image,
    required this.duration,
    required this.category,
    required this.rating,
  });

  Map<String, dynamic> toJson() {
    return {
      'title': title,
      'description': description,
      'image': image,
      'duration': duration,
      'category': category,
      'rating': rating,
    };
  }

  factory MovieModel.fromJson(Map<String, dynamic> json) {
    return MovieModel(
      title: json['title'],
      description: json['description'],
      image: json['image'],
      duration: json['duration'],
      category: json['category'],
      rating: json['rating'],
    );
  }
}