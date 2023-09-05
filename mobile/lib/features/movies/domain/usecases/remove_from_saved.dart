import 'package:dartz/dartz.dart';
import 'package:equatable/equatable.dart';

import 'package:mobile/core/error/failure.dart';
import 'package:mobile/features/movies/domain/repositories/movie_repository.dart';

import '../../../../core/usecase/usecase.dart';
import '../entities/movie.dart';

class RemoveFromSaved extends UseCase<Movie, RemoveFromSavedParams> {
  final MovieRepository repository;

  RemoveFromSaved(this.repository);

  @override
  Future<Either<Failure, Movie>> call(RemoveFromSavedParams params) async {
    return await repository.removeFromSaved(params.id);
  }
}

class RemoveFromSavedParams extends Equatable {
  final String id;

  RemoveFromSavedParams(this.id);

  @override
  List<Object?> get props => [id];
}
