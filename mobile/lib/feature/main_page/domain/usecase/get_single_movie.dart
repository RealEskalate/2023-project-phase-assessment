import 'package:dartz/dartz.dart';
import 'package:second/feature/main_page/domain/repository/movie_repository.dart';

import '../../../../core/error/failure.dart';
import '../entitie/movie_entite.dart';

class GetSingleUseCase{
  final  MovieRepository repository;
  GetSingleUseCase(this.repository);

  Future<Either<Failure, MovieEntitie>> call({required String id}) async{
    return await repository.getSingleMovie(id: id);
  }
}