import 'package:equatable/equatable.dart';

class MovieEntity extends Equatable {
  String id;
  String title;
  String duration;
  double rating;

  MovieEntity(
      {required this.id,
      required this.title,
      required this.duration,
      required this.rating}): super();
  @override
  List<Object?> get props => [];
}
