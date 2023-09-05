import 'package:dartz/dartz.dart';

import '../../../../core/error/failure.dart';
import '../entities/movie.dart';
import '../repositories/repository.dart';

class GetMoviesUseCase {
  final MovieRepository repository;

  GetMoviesUseCase(this.repository);

  Future<Either<Failure, List<Movie>>> call() async {
    return await repository.getAllMovies();
  }
}
