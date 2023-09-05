import 'package:dartz/dartz.dart';
import 'package:equatable/equatable.dart';
import 'package:mobile/core/error/failure.dart';
import 'package:mobile/core/usecase/usecase.dart';
import 'package:mobile/features/movies/domain/repositories/movie_repository.dart';

import '../entities/movie.dart';

class SearchMovies implements UseCase<List<Movie>, SearchParams> {
  final MovieRepository repository;

  SearchMovies(this.repository);

  @override
  Future<Either<Failure, List<Movie>>> call(SearchParams params) async {
    return await repository.searchMovies(params.title);
  }
}

class SearchParams extends Equatable {
  final String title;

  SearchParams(this.title);

  @override
  List<Object?> get props => [title];
}
