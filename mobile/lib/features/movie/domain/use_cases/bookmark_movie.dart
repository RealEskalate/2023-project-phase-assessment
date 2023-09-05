import 'package:dartz/dartz.dart';

import '../../../../core/error/failure.dart';
import '../entities/movie_entity.dart';
import '../repositories/movie_repository.dart';
import 'use_case.dart';

class BookmarkMovieUseCase extends UseCase<void, BookmarkMovieParam> {
  final MovieRepository repository;

  BookmarkMovieUseCase({required this.repository});

  @override
  Future<Either<Failure, void>> call(BookmarkMovieParam params) async {
    return await repository.bookmarkMovie(params.movieEntity);
  }
}

class BookmarkMovieParam {
  final MovieEntity movieEntity;

  BookmarkMovieParam({required this.movieEntity});
}
