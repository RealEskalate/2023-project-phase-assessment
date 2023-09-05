import 'package:dartz/dartz.dart';
import 'package:mobile/core/error/failure.dart';
import 'package:mobile/core/usecase/usecase.dart';
import 'package:mobile/features/movies/domain/repositories/movie_repository.dart';

import '../entities/movie.dart';

class GetSavedMovies implements UseCase<List<Movie>, NoParams> {
  final MovieRepository repository;

  GetSavedMovies(this.repository);

  @override
  Future<Either<Failure, List<Movie>>> call(NoParams params) async {
    return await repository.getSavedMovies();
  }
}
