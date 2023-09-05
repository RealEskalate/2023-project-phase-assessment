import 'package:dartz/dartz.dart';
import 'package:mobile/core/error/failure.dart';

import '../repositories/movie_repository.dart';

class RemoveFromBookmarksUseCase {
  final MovieRepository repository;

  RemoveFromBookmarksUseCase(this.repository);

  Future<Either<Failure, void>> call(String id) async {
    try {
      await repository.removeFromBookmarks(id);
      return Right(null);
    } catch (e) {
      return Left(ServerFailure('Error removing movie from bookmarks'));
    }
  }
}
