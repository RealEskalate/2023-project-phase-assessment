import 'package:dartz/dartz.dart';
import 'package:equatable/equatable.dart';

import '../../../../core/error/failures.dart';
import '../../../../core/usecase/usecase.dart';
import '../entities/movie.dart';
import '../repositories/movie_repository.dart';

class FilterMovies extends UseCase<List<Movie>, FilterParams> {
  final MovieRepository repository;

  FilterMovies({required this.repository});

  @override
  Future<Either<Failure, List<Movie>>> call(FilterParams params) async {
    return await repository.filterMovies(params.query);
  }
}

class FilterParams extends Equatable {
  final String query;

  const FilterParams({required this.query});

  @override
  List<Object?> get props => [query];
}
