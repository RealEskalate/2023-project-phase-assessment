import 'package:dartz/dartz.dart';
import 'package:equatable/equatable.dart';

import '../../../../core/error/failure.dart';
import '../../../../core/usecase/usecase.dart';

import '../entities/movie.dart';
import '../repositories/movie_repository.dart';

class SearchMovies implements UseCase<List<Movie>, SearchParams> {
  final MovieRepository repository;

  SearchMovies(this.repository);

  @override
  Future<Either<Failure, List<Movie>>> call(SearchParams params) async {
    return await repository.searchMovies(params.query);
  }
}

class SearchParams extends Equatable {
  final String query;

  const SearchParams({required this.query});

  @override
  List<Object?> get props => [query];
}
