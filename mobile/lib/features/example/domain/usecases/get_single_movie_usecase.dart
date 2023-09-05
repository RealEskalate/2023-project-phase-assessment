import 'package:dartz/dartz.dart';
import 'package:mobile/features/example/data/models/model.dart';

import '../../../../core/error/failure.dart';
import '../entities/movie.dart';
import '../repositories/movie_repository.dart';

class GetArticleUseCase {
  final MovieRepository repository;

  GetArticleUseCase(this.repository);

  Future<MovieEntity> call(String movieId) async {
    return await repository.getSingleMovie(movieId);
  }
}
