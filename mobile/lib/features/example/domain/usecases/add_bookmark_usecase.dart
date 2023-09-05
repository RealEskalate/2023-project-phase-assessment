
import 'dart:developer';

import 'package:dartz/dartz.dart';
import 'package:mobile/core/error/failure.dart';
import 'package:mobile/features/example/domain/entities/movie.dart';

import '../repositories/movie_repository.dart';

class AddBookmarkUseCase {
  final MovieRepository repository;

  AddBookmarkUseCase(this.repository);

  Future<Either<Failure, MovieEntity>> call(AddBookmarkParams params) async {
    try {
      final movie = await repository.addToBookmarks(
        category: params.category, 
        title: params.title, 
        description: params.description, 
        duration: params.duration, 
        image: params.image, 
        rating: params.rating, 
        createdAt: params.createdAt, 
        id: params.id,

        
      );
      log("Usecase Bookmaek created $movie");
      return Right(movie);
    } catch (e) {
      return Left(ServerFailure('Error adding movie to bookmarks'));
    }
  }
}

class AddBookmarkParams {
  final String category;
  final String title;
  final String description;
  final String duration;
  final String image;
  final double rating;
  final DateTime createdAt;
  final String id;

  AddBookmarkParams({
    required this.category,
    required this.title,
    required this.description,
    required this.duration,
    required this.image,
    required this.rating,
    required this.createdAt,
    required this.id,
  });
}