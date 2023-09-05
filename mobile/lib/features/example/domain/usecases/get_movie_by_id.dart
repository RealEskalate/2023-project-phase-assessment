import 'package:dartz/dartz.dart';
import 'package:mobile/core/errors/failure.dart';
import 'package:mobile/core/usecase/usecase.dart';
import 'package:mobile/features/example/domain/entities/movie.dart';
import 'package:mobile/features/example/domain/repositories/movie_repository.dart';

class GetMovieById extends UseCase<Movie, String> {
  final MovieRepository repository;

  GetMovieById({required this.repository});

  @override
  Future<Either<Failure, Movie>> call(String id) async {
    return await repository.getMovieById(id);
  }
}
