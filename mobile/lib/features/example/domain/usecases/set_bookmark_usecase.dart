import 'package:dartz/dartz.dart';
import 'package:mobile/core/Errors/Failure.dart';
import 'package:mobile/features/example/data/repository/movie_repo_Impl.dart';
import 'package:mobile/features/example/domain/entities/movie.dart';

class SetBookMarkUsecase {
  MovieRepoImpl repo;
  SetBookMarkUsecase(this.repo);
    Future<Either<Failure,void>> call(Movie m) async {
    return await repo.setBookMark(m);
  }
}
