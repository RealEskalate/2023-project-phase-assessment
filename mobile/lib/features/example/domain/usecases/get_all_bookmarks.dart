import 'package:dartz/dartz.dart';
import '../../data/models/movie.dart' as moviemodel;

import '../../../../core/error/failure.dart';
import '../entities/movie.dart';
import '../repositories/repository.dart';

class GetBookmarkUseCase {
  final MovieRepository repository;

  GetBookmarkUseCase(this.repository);

  Future<Either<Failure, List<moviemodel.MovieModel>>> call() async {
    return await repository.getAllBookmarks();
  }
}
