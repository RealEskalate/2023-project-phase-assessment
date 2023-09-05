
import 'package:dartz/dartz.dart';
import 'package:equatable/equatable.dart';

import '../../../../core/exceptions/Failure.dart';
import '../../../../core/usecases/usecase.dart';
import '../entities/movie.dart';
import '../repositories/movie_repository.dart';


class SearchMovies extends UseCase<List<Movie>, SearchParams> {
  final MovieRepository repository;
  SearchMovies(this.repository);

  @override
  Future<Either<Failure, List<Movie>>> call(SearchParams params) async{
    return await repository.searchMovies(params.query);
  }
}

class SearchParams extends Equatable {
  final String query;

  const SearchParams(this.query);

  @override
  List<Object?> get props => [query];
}