import 'package:dartz/dartz.dart';
import 'package:equatable/equatable.dart';
import 'package:mobile/features/example/domain/entities/movie_entity.dart';
import 'package:mobile/features/example/domain/repositories/movie_repository.dart';

import '../../../../core/error/failure.dart';
import '../../../../core/usecase/usecase.dart';

class FilterMovies implements UseCase<List<MovieEntity>, FilterParams> {
  final MovieRepository repository;

  FilterMovies(this.repository);

  @override
  Future<Either<Failure, List<MovieEntity>>> call(FilterParams params) async {
    return await repository.filterMovies(params.searchParams);
  }
}

class FilterParams extends Equatable {
  final String searchParams;

  const FilterParams({required this.searchParams});

  @override
  List<Object?> get props => [searchParams];
}
