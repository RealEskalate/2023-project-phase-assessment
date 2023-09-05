import 'package:dartz/dartz.dart';

import '../../../../core/error/failure.dart';
import '../entities/movie_entity.dart';
import '../repositories/movie_repository.dart';
import 'use_case.dart';

class RemoveFromBookmarkMovieUseCase
    extends UseCase<void, RemoveFromBookmarkMovieParam> {
  final MovieRepository repository;

  RemoveFromBookmarkMovieUseCase({required this.repository});

  @override
  Future<Either<Failure, void>> call(
      RemoveFromBookmarkMovieParam params) async {
    return await repository.removeMovieFromBookmark(params.movieEntity);
  }
}

class RemoveFromBookmarkMovieParam {
  final MovieEntity movieEntity;

  RemoveFromBookmarkMovieParam({required this.movieEntity});
}
