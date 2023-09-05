import 'package:dartz/dartz.dart';
import 'package:equatable/equatable.dart';
import 'package:mobile/features/example/domain/entities/movie_entity.dart';
import 'package:mobile/features/example/domain/repositories/movie_repository.dart';

import '../../../../core/error/failure.dart';
import '../../../../core/usecase/usecase.dart';

class RemoveFromBookmark implements UseCase<MovieEntity, RemoveFromBookmarkParams> {
  final MovieRepository repository;

  const RemoveFromBookmark(this.repository);

  @override
  Future<Either<Failure, MovieEntity>> call(RemoveFromBookmarkParams params) async {
    return await repository.removeFromBookmark(params.id);
  }
}

class RemoveFromBookmarkParams extends Equatable {
  final String id;

  const RemoveFromBookmarkParams({required this.id});

  @override
  List<Object?> get props => [id];
}
