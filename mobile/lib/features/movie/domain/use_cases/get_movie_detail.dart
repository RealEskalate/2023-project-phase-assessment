import 'package:dartz/dartz.dart';

import '../../../../core/error/failure.dart';
import '../entities/movie_entity.dart';
import '../repositories/movie_repository.dart';
import 'use_case.dart';

class GetMovieDetailUseCase extends UseCase<MovieEntity, GetMovieParams> {
  final MovieRepository repository;

  GetMovieDetailUseCase({required this.repository});

  @override
  Future<Either<Failure, MovieEntity>> call(GetMovieParams params) async {
    return await repository.getMovie(params.movieId);
  }
}

class GetMovieParams {
  final String movieId;

  GetMovieParams({required this.movieId});
}
