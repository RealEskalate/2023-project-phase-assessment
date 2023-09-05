import 'package:dartz/dartz.dart';
import 'package:mobile/core/errors/failure.dart';
import 'package:mobile/core/usecase/usecase.dart';
import 'package:mobile/features/example/domain/entities/movie.dart';
import 'package:mobile/features/example/domain/repositories/movie_repository.dart';

class GetMovieBySearch extends UseCase<List<Movie>, String> {
  final MovieRepository repository;

  GetMovieBySearch({required this.repository});
  @override
  Future<Either<Failure, List<Movie>>> call(String params) async {
    return await repository.getMovieBySearch(params);
  }
}
