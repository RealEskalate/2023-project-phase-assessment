import 'package:dartz/dartz.dart';
import 'package:mobile/core/error/failure.dart';
import 'package:mobile/features/example/domain/entities/movie.dart';

import '../repositories/movie_repository.dart';

class GetBookmarksUseCase {
  final MovieRepository repository;

  GetBookmarksUseCase(this.repository);

  Future<Either<Failure, List<MovieEntity>>> call() async {
    try {
      final bookmarks = await repository.getBookmarks();
      return Right(bookmarks);
    } catch (e) {
      return Left(ServerFailure('Error fetching bookmarks'));
    }
  }
}
