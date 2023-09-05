import 'package:dartz/dartz.dart';
import 'package:mobile/core/error/failure.dart';
import 'package:mobile/features/movies/data/datasources/local/movie_local_data_source.dart';
import 'package:mobile/features/movies/data/datasources/remote/movie_remote_data_source.dart';
import 'package:mobile/features/movies/data/models/movie_model.dart';
import 'package:mobile/features/movies/domain/entities/movie.dart';
import 'package:mobile/features/movies/domain/repositories/movie_repository.dart';

import '../../../../core/network/network_info.dart';

class MovieRepositoryImpl extends MovieRepository {
  final MovieLocalDataSource localDataSource;
  final MovieRemoteDataSource remoteDataSource;
  final NetworkInfo networkInfo;

  MovieRepositoryImpl(
      {required this.localDataSource,
      required this.remoteDataSource,
      required this.networkInfo});

  @override
  Future<Either<Failure, Movie>> addToSaved(Movie movie) async {
    await localDataSource.addToSaved(movie as MovieModel);
    return Right(movie);
  }

  @override
  Future<Either<Failure, List<Movie>>> getAllMovies() async {
    if (await networkInfo.isConnected) {
      try {
        final movies = await remoteDataSource.getAllMovies();
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
  Future<Either<Failure, List<Movie>>> getSavedMovies() async {
    final movies = await localDataSource.getSavedMovies();
    return Right(movies);
  }

  @override
  Future<Either<Failure, Movie>> removeFromSaved(String movieId) async {
    final movie = await localDataSource.removeFromSaved(movieId);
    return Right(movie);
  }

  @override
  Future<Either<Failure, List<Movie>>> searchMovies(String title) async {
    if (await networkInfo.isConnected) {
      try {
        final movies = await remoteDataSource.searchMovies(title);

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
}
