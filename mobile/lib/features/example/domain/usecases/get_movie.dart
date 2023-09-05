import 'package:dartz/dartz.dart';
import 'package:equatable/equatable.dart';
import 'package:mobile/features/example/domain/entities/movie_entity.dart';
import 'package:mobile/features/example/domain/repositories/movie_repository.dart';

import '../../../../core/error/failure.dart';
import '../../../../core/usecase/usecase.dart';

class GetMovie implements UseCase<MovieEntity, GetParams> {
  final MovieRepository repository;

  GetMovie(this.repository);

  @override
  Future<Either<Failure, MovieEntity>> call(GetParams params) async {
    return await repository.getMovie(params.id);
  }

}

class GetParams extends Equatable{
  final String id;

  const GetParams({required this.id});
  
  @override
  List<Object?> get props => [id];
}