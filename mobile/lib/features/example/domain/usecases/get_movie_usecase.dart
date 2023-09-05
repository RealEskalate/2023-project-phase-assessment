import 'package:dartz/dartz.dart';
import 'package:mobile/core/Error/failures.dart';
import 'package:mobile/core/Usecase/usecase.dart';
import 'package:mobile/features/example/data/models/movie_model.dart';
import 'package:mobile/features/example/domain/repositories/movie_repositry.dart';

class GetMovieUseCase implements UseCase<NoParams, List<MovieModel>> {
  final MovieRepository repository;

  GetMovieUseCase(this.repository);

  @override
  Future<Either<Faliure, List<MovieModel>>> call(NoParams params) async {
    return await repository.getMovie();
  }
}

