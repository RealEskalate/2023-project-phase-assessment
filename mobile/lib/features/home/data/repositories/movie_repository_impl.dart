import 'package:dartz/dartz.dart';
import 'package:mobile/core/errors/failures/connection_failure.dart';
import 'package:mobile/core/errors/failures/failure.dart';
import 'package:mobile/features/home/domain/entities/movie.dart';
import 'package:mobile/features/home/domain/repositories/movie_repository.dart';

import '../../../../injection/injection_container.dart';
import '../datasources/movie_remote_datasource.dart';

class MovieRepositoryImpl extends MovieRepository {
  MovieRemoteDataource remoteDataource = sl();

  @override
  Future<Either<Failure, List<Movie>>> getMovies() async {
    try {
      final List<Movie> movies = await remoteDataource.getMovies();
      return Right(movies);
    } catch (e) {
      return Left(ConnectionFailure());
    }
  }

  @override
  Future<Either<Failure, List<Movie>>> searchMovies(String term) async {
    try {
      final List<Movie> movies = await remoteDataource.searchMovies(term);
      return Right(movies);
    } catch (e) {
      return Left(ConnectionFailure());
    }
  }
}
