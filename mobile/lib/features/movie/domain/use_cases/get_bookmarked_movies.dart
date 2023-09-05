import 'package:dartz/dartz.dart';

import '../../../../core/error/failure.dart';
import '../entities/movie_entity.dart';
import '../repositories/movie_repository.dart';
import 'use_case.dart';

class GetBookmarkedMoviesUseCase extends UseCase<List<MovieEntity>, NoParams> {
  final MovieRepository repository;

  GetBookmarkedMoviesUseCase({required this.repository});

  @override
  Future<Either<Failure, List<MovieEntity>>> call(NoParams params) async {
    return await repository.getBookmarkedMovies();
  }
}
