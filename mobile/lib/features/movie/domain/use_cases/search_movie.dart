import 'package:dartz/dartz.dart';

import '../../../../core/error/failure.dart';
import '../entities/movie_entity.dart';
import '../repositories/movie_repository.dart';
import 'use_case.dart';

class SearchMoviesUseCase
    extends UseCase<List<MovieEntity>, SearchMoviesParams> {
  final MovieRepository repository;

  SearchMoviesUseCase({required this.repository});

  @override
  Future<Either<Failure, List<MovieEntity>>> call(
      SearchMoviesParams params) async {
    return await repository.searchMovies(params.queryParams);
  }
}

class SearchMoviesParams {
  final String queryParams;
  SearchMoviesParams({required this.queryParams});
}
