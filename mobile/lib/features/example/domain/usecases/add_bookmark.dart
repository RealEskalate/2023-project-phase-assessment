import 'dart:developer';
import 'dart:io';
import 'package:dartz/dartz.dart';
import '../entities/movie.dart';
import '../repositories/repository.dart';
import '../../../../core/error/failure.dart';

class AddBookmarkUseCase {
  final MovieRepository repository;

  AddBookmarkUseCase(this.repository);

  Future<Either<Failure, bool>> call(AddBookmarkParams params) async {
    print("add bookmark usecase");
    //  return await repository.createArticle(article);
    try {
      final article = await repository.addBookmark(
        id: params.id,
        category: params.category,
        title: params.title,
        description: params.description,
        duration: params.duration,
        image: params.image,
        rating: params.rating,
        createdAt: params.createdAt,
      );
      log("Usecase Bookmark created $article");
      return const Right(true);
    } catch (e) {
      return const Left(ServerFailure('Error creating article'));
    }
  }
}

class AddBookmarkParams {
  final String id;
  final String title;
  final String category;
  final String description;
  final String duration;
  final String image;
  final double rating;
  final String createdAt;

  AddBookmarkParams({
    required this.id,
    required this.title,
    required this.category,
    required this.description,
    required this.duration,
    required this.image,
    required this.rating,
    required this.createdAt,
  });
}
