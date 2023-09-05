import 'package:dartz/dartz.dart';
import 'package:equatable/equatable.dart';
import 'package:mobile/features/example/domain/entities/movie_entity.dart';
import 'package:mobile/features/example/domain/repositories/movie_repository.dart';

import '../../../../core/error/failure.dart';
import '../../../../core/usecase/usecase.dart';

class AddToBookmark extends UseCase<MovieEntity, AddToBookmarkParams> {
  final MovieRepository _articleRepository;

  AddToBookmark(this._articleRepository);

  @override
  Future<Either<Failure, MovieEntity>> call(AddToBookmarkParams params) async {
    return await _articleRepository.addToBookmark(params.movie);
  }
}

class AddToBookmarkParams extends Equatable {
  final MovieEntity movie;

  const AddToBookmarkParams({required this.movie});

  @override
  List<Object?> get props => [movie];
}
