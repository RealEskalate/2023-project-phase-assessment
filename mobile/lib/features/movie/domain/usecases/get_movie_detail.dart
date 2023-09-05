import 'package:dartz/dartz.dart';
import 'package:equatable/equatable.dart';

import '../../../../core/error/failure.dart';

import '../../../../core/usecase/usecase.dart';
import '../entities/movie.dart';
import '../repositories/movie_repository.dart';

class GetMovieDetail implements UseCase<Movie, GetMovieParams> {
  final MovieRepository repository;

  GetMovieDetail(this.repository);

  @override
  Future<Either<Failure, Movie>> call(GetMovieParams params) async {
    return await repository.getMovie(params.id);
  }
}

class GetMovieParams extends Equatable {
  final String id;

  const GetMovieParams({required this.id});

  @override
  List<Object?> get props => [id];
}
