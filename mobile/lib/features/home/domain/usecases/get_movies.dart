import 'package:dartz/dartz.dart';
import 'package:mobile/core/errors/failures/failure.dart';
import 'package:mobile/features/home/data/datasources/movie_remote_datasource.dart';
import 'package:mobile/features/home/data/repositories/movie_repository_impl.dart';
import 'package:mobile/features/home/domain/repositories/movie_repository.dart';

import '../entities/movie.dart';

class GetMovies {
  final MovieRepository repository;
  GetMovies(this.repository);

  Future<Either<Failure, List<Movie>>> call() async {
    final movies = await repository.getMovies();
    return movies;
  }
}
