import 'package:dartz/dartz.dart';
import 'package:equatable/equatable.dart';
import 'package:mobile/core/errors/failure.dart';
import 'package:mobile/core/usecase/usecase.dart';
import 'package:mobile/features/example/domain/entities/MovieEntity.dart';
import 'package:mobile/features/example/domain/repositories/movie_repository.dart';

class GetSingleMovie extends Usecase<MovieEntity, Params> {
  final MovieRepository repository;

  GetSingleMovie(this.repository);

  
  @override
  Future<Either<Failure, MovieEntity>> call(Params params) async{
   return await repository.getSingleMovie(params.id);
  }
}

class Params {
  final String id;
  Params({required this.id});
}