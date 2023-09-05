import 'package:dartz/dartz.dart';
import 'package:second/feature/main_page/domain/repository/movie_repository.dart';

import '../../../../core/error/failure.dart';
import '../entitie/movie_entite.dart';

class GetSearchUseCase{
  final  MovieRepository repository;
  GetSearchUseCase(this.repository);

  Future<Either<Failure, List<MovieEntitie>>> call({required String movieName}) async{
    return await repository.getSearchedMovie(movieName: movieName);
  }
}