import 'package:dartz/dartz.dart';

import '../../../../core/error/failure.dart';
import '../../../../core/usecase/usecase.dart';

import '../entities/movie.dart';
import '../repositories/movie_repository.dart';

class GetAllMovies implements UseCase<List<Movie>, NoParams> {
  final MovieRepository repository;

  GetAllMovies(this.repository);

  @override
  Future<Either<Failure, List<Movie>>> call(NoParams params) async {
    return await repository.getMovies();
  }
}
