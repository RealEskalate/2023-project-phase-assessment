import 'package:dartz/dartz.dart';
import 'package:equatable/equatable.dart';

import 'package:mobile/core/error/failure.dart';

import '../../../../core/usecase/usecase.dart';
import '../entities/movie.dart';
import '../repositories/movie_repository.dart';

class GetMovie implements UseCase<Movie, GetParams> {
  final MovieRepository repository;

  GetMovie(this.repository);

  @override
  Future<Either<Failure, Movie>> call(GetParams params) async {
    return await repository.getMovie(params.id);
  }
}

class GetParams extends Equatable {
  final String id;

  GetParams(this.id);

  @override
  List<Object?> get props => [id];
}
