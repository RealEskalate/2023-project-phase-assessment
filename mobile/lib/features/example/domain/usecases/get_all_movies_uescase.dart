import 'package:dartz/dartz.dart';
import 'package:mobile/features/example/data/models/model.dart';

import '../../../../core/error/failure.dart';
import '../entities/movie.dart';
import '../repositories/movie_repository.dart';

class GetAllMoviesUseCase {
  final MovieRepository repository;

  GetAllMoviesUseCase(this.repository);

  Future<List<MovieEntity>> call() async {
    return await repository.getAllMovies();
  }
}
