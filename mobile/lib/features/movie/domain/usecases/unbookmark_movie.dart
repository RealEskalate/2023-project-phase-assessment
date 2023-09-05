import 'package:dartz/dartz.dart';
import 'package:equatable/equatable.dart';

import '../../../../core/error/failures.dart';
import '../../../../core/usecase/usecase.dart';
import '../entities/movie.dart';
import '../repositories/movie_repository.dart';

class UnBookMarkMovie extends UseCase<Movie, UnBookMarkParams> {
  final MovieRepository repository;

  UnBookMarkMovie({required this.repository});

  @override
  Future<Either<Failure, Movie>> call(UnBookMarkParams params) async {
    return await repository.unBookMarkMovie(params.movie);
  }
}

class UnBookMarkParams extends Equatable {
  final Movie movie;

  const UnBookMarkParams({required this.movie});

  @override
  List<Object?> get props => [movie];
}