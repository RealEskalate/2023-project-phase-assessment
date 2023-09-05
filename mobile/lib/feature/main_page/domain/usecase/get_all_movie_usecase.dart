import 'package:dartz/dartz.dart';
import 'package:second/feature/main_page/domain/repository/movie_repository.dart';

import '../../../../core/error/failure.dart';
import '../entitie/movie_entite.dart';

class GetAllMoviesUseCase{
  final  MovieRepository repository;
  GetAllMoviesUseCase(this.repository);

  Future<Either<Failure, List<MovieEntitie>>> call() async{
    return await repository.getAllMovie();
  }
}