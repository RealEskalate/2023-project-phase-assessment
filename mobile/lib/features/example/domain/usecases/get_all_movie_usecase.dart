//get all movies usecase 

import 'package:dartz/dartz.dart';
import 'package:mobile/core/errors/failure.dart';
import 'package:mobile/core/usecase/usecase.dart';
import 'package:mobile/features/example/domain/entities/MovieEntity.dart';
import 'package:mobile/features/example/domain/repositories/movie_repository.dart';
class GetAllMovies extends Usecase<List<MovieEntity>, NoParams>{
  final MovieRepository repository;

  GetAllMovies(this.repository);

  
  @override
  Future<Either<Failure, List<MovieEntity>>> call(NoParams params) async{
    return await repository.getAllMovies();
  }
}
