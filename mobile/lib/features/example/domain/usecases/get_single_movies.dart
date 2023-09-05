import 'package:dartz/dartz.dart';

import '../../../../core/error/failure.dart';
import '../entities/movie.dart';
import '../repositories/repository.dart';

class GetSingleMovieUseCase {
  final MovieRepository repository;

  GetSingleMovieUseCase(this.repository);

  Future<Either<Failure, Movie>> call(String movieId) async {
    return await repository.getSingleMovie(movieId);
  }
}
