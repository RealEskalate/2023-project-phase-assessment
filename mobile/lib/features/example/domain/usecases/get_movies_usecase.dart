import 'package:dartz/dartz.dart';
import 'package:mobile/core/Errors/Failure.dart';
import 'package:mobile/features/example/data/repository/movie_repo_Impl.dart';
import 'package:mobile/features/example/domain/entities/movie.dart';
import 'package:mobile/features/example/domain/repositories/movie_repo.dart';

class GetMoviesUsercase {
  MovieRepo repo;
  GetMoviesUsercase(this.repo);
  
  Future<Either<Failure, List<Movie>>> call() async {
    return await repo.getMovies();
  }
}
