import 'package:dartz/dartz.dart';
import 'package:mobile/features/example/domain/entities/movie_entity.dart';
import 'package:mobile/features/example/domain/repositories/movie_repository.dart';

import '../../../../core/error/failure.dart';
import '../../../../core/usecase/usecase.dart';

class GetAllMovies implements UseCase<List<MovieEntity>, NoParams> {
  final MovieRepository repository;

  GetAllMovies(this.repository);

  @override
  Future<Either<Failure, List<MovieEntity>>> call(NoParams params) async {
    return await repository.getAllMovies();
  }
}

