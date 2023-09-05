import 'dart:convert';

import 'package:mobile/core/utils/typedef.dart';

import '../../domain/entities/movie.dart';

class MovieModel extends Movie {
  MovieModel({
    required super.id,
    required super.category,
    required super.description,
    required super.title,
    required super.duration,
    required super.rating,
    required super.image,
    required super.createdAt,
  });

  MovieModel.empty()
      : this(
          id: "-1",
          category: "_empty.category",
          description: "_empty.description",
          title: "_empty.title",
          duration: "_empty.duration",
          rating: "_empty.rating",
          image: "_empty.image",
          createdAt: "_empty.createdAt",
        );

  factory MovieModel.fromJson(String source) =>
      MovieModel.fromMap(jsonDecode(source) as DataMap);

  MovieModel.fromMap(DataMap map)
      : this(
          id: map["id"].toString(),
          category: map["category"].toString(),
          description: map["description"].toString(),
          title: map["title"].toString(),
          duration: map["duration"].toString(),
          rating: map["rating"].toString(),
          image: map["image"].toString(),
          createdAt: map["createdAt"].toString(),
        );

  MovieModel copyWith({
    String? category,
    String? description,
    String? title,
    String? duration,
    String? rating,
    String? image,
    String? createdAt,
  }) {
    return MovieModel(
      id: id,
      category: category ?? this.category,
      description: description ?? this.description,
      title: title ?? this.title,
      duration: duration ?? this.duration,
      rating: rating ?? this.rating,
      image: image ?? this.image,
      createdAt: createdAt ?? this.createdAt,
    );
  }

  DataMap toMap() => {
        "id": id,
        "category": category,
        "description": description,
        "title": title,
        "duration": duration,
        "rating": rating,
        "image": image,
        "createdAt": createdAt,
      };

  String toJson() => jsonEncode(toMap());
}
