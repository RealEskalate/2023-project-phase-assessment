import 'package:dartz/dartz.dart';
import 'package:equatable/equatable.dart';
import 'package:mobile/core/error/failure.dart';
import 'package:mobile/core/usecase/usecase.dart';
import 'package:mobile/features/movies/domain/repositories/movie_repository.dart';

import '../entities/movie.dart';

class AddToSaved extends UseCase<Movie, AddToSavedParams> {
  final MovieRepository repository;

  AddToSaved(this.repository);

  @override
  Future<Either<Failure, Movie>> call(AddToSavedParams params) async {
    return await repository.addToSaved(params.movie);
  }
}

class AddToSavedParams extends Equatable {
  final Movie movie;

  AddToSavedParams(this.movie);

  @override
  List<Object?> get props => [movie];
}
