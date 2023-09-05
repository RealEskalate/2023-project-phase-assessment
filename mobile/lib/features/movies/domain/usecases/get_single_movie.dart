import 'package:dartz/dartz.dart';

import '../../../../core/error/failure.dart';
import '../entities/movie.dart';
import '../repositories/movie_repository.dart';

class GetArticleUseCase {
  final MovieRepository repository;

  GetArticleUseCase(this.repository);

  Future<Either<Failure, Movie>> call(String movieId) async {
    return await repository.getSingleMovie(movieId);
  }
}
