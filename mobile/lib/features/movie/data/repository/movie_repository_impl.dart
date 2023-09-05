import '../../../../core/error/failures.dart';
import '../../../../core/network/network_info.dart';
import '../../domain/entities/movie.dart';
import 'package:dartz/dartz.dart';

import '../../domain/repositories/movie_repository.dart';
import '../datasources/local/local_datasource.dart';
import '../datasources/remote/remote_datasource.dart';
import '../models/movie_mapper.dart';

class MovieRepositoryImpl implements MovieRepository {
  final RemoteDataSource remoteDataSource;
  final LocalDataSource localDataSource;
  final NetworkInfo networkInfo;

  const MovieRepositoryImpl({
    required this.remoteDataSource,
    required this.localDataSource,
    required this.networkInfo,
  });

  @override
  Future<Either<Failure, Movie>> bookMarkMovie(Movie movie) async {
    await localDataSource.cacheBookMarkedMovie(movie.toMovieModel());
    return Right(movie);
  }

  @override
  Future<Either<Failure, List<Movie>>> filterMovies(String query) async {
    if (await networkInfo.isConnected) {
      try {
        final movies = await remoteDataSource.filterMovies(query);
        return Right(movies);
      } catch (e) {
        final movies = await localDataSource.getCachedMovies();
        return Right(movies);
      }
    } else {
      final movies = await localDataSource.getCachedMovies();
      return Right(movies);
    }
  }

  @override
  Future<Either<Failure, List<Movie>>> getBookMarkedMovies() async {
    final movies = await localDataSource.getCachedBookMarkedMovies();
    return Right(movies);
  }

  @override
  Future<Either<Failure, Movie>> getMovie(String id) async {
    if (await networkInfo.isConnected) {
      try {
        final movie = await remoteDataSource.getMovie(id);
        await localDataSource.cacheMovie(movie);
        return Right(movie);
      } catch (e) {
        final movie = await localDataSource.getMovie(id);
        return Right(movie);
      }
    } else {
      final movie = await localDataSource.getMovie(id);
      return Right(movie);
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
        final movies = await localDataSource.getCachedMovies();
        return Right(movies);
      }
    } else {
      final movies = await localDataSource.getCachedMovies();
      return Right(movies);
    }
  }

  @override
  Future<Either<Failure, Movie>> unBookMarkMovie(Movie movie) async {
    final removedMovie =
        await localDataSource.removeBookMarkedMovie(movie.toMovieModel());
    return Right(removedMovie);
  }
}
