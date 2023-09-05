import 'package:dartz/dartz.dart';

import '../../../../core/error/failures.dart';
import '../../../../core/usecase/usecase.dart';
import '../entities/movie.dart';
import '../repositories/movie_repository.dart';

class GetBookMarkedMovies extends UseCase<List<Movie>, NoParams> {
  final MovieRepository repository;

  GetBookMarkedMovies({required this.repository});

  @override
  Future<Either<Failure, List<Movie>>> call(NoParams params) async {
    return await repository.getBookMarkedMovies();
  }
}