import 'package:second/feature/main_page/domain/entitie/movie_entite.dart';

class MovieModel extends MovieEntitie {
  final String id;
  const MovieModel({
    required super.createdAt,
    required this.id,
    required super.catagory,
    required super.title,
    required super.description,
    required super.duaration,
    required super.image,
    required super.rating,
  });

  factory MovieModel.fromJson(Map<String, dynamic> json) {
    return MovieModel(
      id: json["id"],
      catagory: json["category"],
      title: json['title'],
      description: json['description'],
      duaration: json['duration'],
      image: json["image"],
      rating: json['rating'],
      createdAt: json['createdAt'],
    );
  }
}
