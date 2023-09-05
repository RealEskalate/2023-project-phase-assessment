import 'package:dartz/dartz.dart';

import '../../../../core/error/failure.dart';
import '../../../../core/network/network_info.dart';
import '../../domain/entities/movie.dart';
import '../../domain/repositories/movie_repository.dart';
import '../datasources/local_datasource/movie_local_datasource.dart';
import '../datasources/remote_datasource/movie_remote_datasource.dart';

class MovieRepositoryImpl extends MovieRepository {
  final MovieLocalDataSource localDataSource;
  final MovieRemoteDataSource remoteDataSource;
  final NetworkInfo networkInfo;

  MovieRepositoryImpl(
      {required this.localDataSource,
      required this.remoteDataSource,
      required this.networkInfo});

  @override
  Future<Either<Failure, Movie>> getMovie(String id) async {
    if (await networkInfo.isConnected) {
      try {
        final movie = await remoteDataSource.getMovie(id);
        await localDataSource.cacheMovie(movie);
        return Right(movie);
      } catch (e) {
        try {
          final movie = await localDataSource.getMovie(id);
          return Right(movie);
        } catch (e) {
          return Left(CacheFailure());
        }
      }
    } else {
      try {
        final movie = await localDataSource.getMovie(id);
        return Right(movie);
      } catch (e) {
        return Left(CacheFailure());
      }
    }
  }

  @override
  Future<Either<Failure, List<Movie>>> getMovies() async {
    if (await networkInfo.isConnected) {
      try {
        final movies = await remoteDataSource.getMovies();
        await localDataSource.cacheMovies(movies);
        return Right(movies);
      } catch (e) {
        final movies = await localDataSource.getMovies();
        return Right(movies);
      }
    } else {
      final movies = await localDataSource.getMovies();
      return Right(movies);
    }
  }

  @override
  Future<Either<Failure, List<Movie>>> searchMovies(String query) async {
    if (await networkInfo.isConnected) {
      try {
        final movies = await remoteDataSource.searchMovies(query);

        return Right(movies);
      } catch (e) {
        final movies = await localDataSource.searchMovies(query);

        return Right(movies);
      }
    } else {
      final movies = await localDataSource.searchMovies(query);
      return Right(movies);
    }
  }
}
