import 'package:dartz/dartz.dart';
import 'package:equatable/equatable.dart';
import 'package:mobile/core/Error/failures.dart';
import 'package:mobile/core/Usecase/usecase.dart';
import 'package:mobile/features/example/data/models/movie_model.dart';
import 'package:mobile/features/example/domain/repositories/movie_repositry.dart';

class SearchMovieUseCase implements UseCase<SearchParams, List<MovieModel>> {
  final MovieRepository repository;

  SearchMovieUseCase(this.repository);

  @override
  Future<Either<Faliure, List<MovieModel>>> call(SearchParams params) async {
    return await repository.searchMovie(params.query);
  }
}

class SearchParams extends Equatable {
  final String query;
  const SearchParams({required this.query});

  @override
  List<Object?> get props => [query];
}
