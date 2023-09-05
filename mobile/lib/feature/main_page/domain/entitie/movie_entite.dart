import 'package:equatable/equatable.dart';

class MovieEntitie extends Equatable {
  final String catagory, title, description, duaration, image;
  final int rating;
  final DateTime? createdAt;

  const MovieEntitie({
    required this.catagory,
    required this.title,
    required this.description,
    required this.duaration,
    required this.image,
    required this.rating,
    this.createdAt,
  });

  @override
  List<Object?> get props => [catagory, title, description, duaration, image, rating];
}
