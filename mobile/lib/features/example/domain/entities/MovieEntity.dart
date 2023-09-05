import 'package:equatable/equatable.dart';

class MovieEntity extends Equatable {
 final String? sId;
  final String? category;
  final String? title;
  final String? description;
  final String? duration;
  final String? image;
  final double? rating;
  final String? createdAt;
  final int? iV;
  final String? id;

  MovieEntity({
    this.sId,
    this.category,
    this.title,
    this.description,
    this.duration,
    this.image,
    this.rating,
    this.createdAt,
    this.iV,
    this.id,
  });
  @override
  List<Object?> get props => [
        sId,
        category,
        title,
        description,
        duration,
        image,
        rating,
        createdAt,
        iV,
        id
      ];
}
