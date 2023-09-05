import 'package:dartz/dartz.dart';
import 'package:mobile/core/Errors/Failure.dart';
import 'package:mobile/features/example/data/repository/movie_repo_Impl.dart';
import 'package:mobile/features/example/domain/entities/movie.dart';

class GetMoviesUsercase {
  MovieRepoImpl repo;
  GetMoviesUsercase(this.repo);
    Future<Either<Failure, List<Movie>>> call() async {
    return await repo.getMovies();
  }
}
