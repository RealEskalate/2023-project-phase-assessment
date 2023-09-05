import 'package:dartz/dartz.dart';
import 'package:mobile/core/errors/failure.dart';
import 'package:mobile/core/usecase/usecase.dart';
import 'package:mobile/features/example/domain/entities/movie.dart';
import 'package:mobile/features/example/domain/repositories/movie_repository.dart';

class GetMovies extends UseCase<List<Movie>, NoParams> {
  final MovieRepository repository;

  GetMovies({required this.repository});

  @override
  Future<Either<Failure, List<Movie>>> call(NoParams params) async {
    return await repository.getMovies();
  }
}
