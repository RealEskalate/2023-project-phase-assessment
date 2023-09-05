import 'package:mobile/features/example/domain/entities/Movie.dart';

class MovieModel extends Movie {

   MovieModel({
    required String id,
    required String category,
    required String title,
    required String description,
    required String duration,
    required String image,
    required String rating,
    required String createdAt,
  }) : super(
          id: id,
          category: category,
          title: title,
          description: description,
          duration: duration,
          image: image,
          rating: rating,
          createdAt: createdAt,
        );
 

  factory MovieModel.fromJson(Map<String, dynamic> json) {
    return MovieModel(
      id: json['id'].toString(),
      category: json['category'].toString(),
      title: json['title'].toString() ,
      description: json['description'].toString() ,
      duration: json['duration'].toString(),
      createdAt: json['createdAt'].toString(),
      image: json['image'].toString(),
      rating: json['rating'].toString(),
    );
  }

  Map<String, dynamic> toJson() {
    return {
      'id': id,
      'category': category,
      'title': title,
      'description': description,
      'duration': duration,
      'createdAt': createdAt,
      'image': image,
      'rating': rating,
    };
  }
}
