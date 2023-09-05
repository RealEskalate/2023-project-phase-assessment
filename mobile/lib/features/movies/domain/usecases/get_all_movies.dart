import 'package:dartz/dartz.dart';

import '../../../../core/error/failure.dart';
import '../entities/movie.dart';
import '../repositories/movie_repository.dart';

class GetAllMoviesUseCase {
  final MovieRepository repository;

  GetAllMoviesUseCase(this.repository);

  Future<Either<Failure, List<Movie>>> call() async {
    return await repository.getAllMovies();
  }
}
