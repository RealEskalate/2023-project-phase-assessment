import 'dart:io';

import '../bloc_event.dart';

class AddBookmarkEvent extends MovieEvent {
  final String id;
  final String title;
  final String category;
  final String description;
  final String duration;
  final String image;
  final double rating;
  final String createdAt;

  const AddBookmarkEvent({
    required this.id,
    required this.title,
    required this.category,
    required this.description,
    required this.duration,
    required this.image,
    required this.rating,
    required this.createdAt,
  });

  @override
  List<Object> get props => [];
}
