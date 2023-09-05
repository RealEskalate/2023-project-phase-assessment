import 'package:dartz/dartz.dart';
import 'package:equatable/equatable.dart';
import 'package:mobile/core/usecase/usecase.dart';
import 'package:mobile/features/example/domain/entities/MovieEntity.dart';
import 'package:mobile/features/example/domain/repositories/movie_repository.dart';

import '../../../../core/errors/failure.dart';

class AddToBookmark extends Usecase<MovieEntity, AddToBookmarkParams> {
  final MovieRepository _movieRepository;

  AddToBookmark(this._movieRepository);

  @override
  Future<Either<Failure, MovieEntity>> call(AddToBookmarkParams params) async {
    return await _movieRepository.addToBookmark(params.movieEntity);
  }
}

class AddToBookmarkParams extends Equatable {
  final MovieEntity movieEntity;

  const AddToBookmarkParams({required this.movieEntity});

  @override
  List<Object?> get props => [movieEntity];
}