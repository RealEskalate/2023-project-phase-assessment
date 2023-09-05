import 'package:dartz/dartz.dart';
import 'package:mobile/core/errors/failure.dart';
import 'package:mobile/core/network/network_info.dart';
import 'package:mobile/features/example/data/datasources/movie_local_data_source.dart';
import 'package:mobile/features/example/data/datasources/movie_remote_datasource.dart';
import 'package:mobile/features/example/data/models/movie_model.dart';
import 'package:mobile/features/example/domain/entities/MovieEntity.dart';
import 'package:mobile/features/example/domain/repositories/movie_repository.dart';

class MovieRepositoryImpl implements MovieRepository {
  final MovieLocalDataSource localDataSource;
  final MovieRemoteDataSource remoteDataSource;
  final NetworkInfo networkInfo;

  MovieRepositoryImpl(
      {required this.localDataSource,
      required this.remoteDataSource,
      required this.networkInfo});

  @override
  Future<Either<Failure, List<MovieEntity>>> getAllMovies() async {
    if (await networkInfo.isConnected) {
      try {
        final movies = await remoteDataSource.getAllMovies();
        await localDataSource.cacheMovies(movies);
        return Right(movies);
      } catch (e) {
        final movies = await localDataSource.getAllMovies();
        return Right(movies);
      }
    } else {
      final articles = await localDataSource.getAllMovies();
      return Right(articles);
    }
  }

  @override
  Future<Either<Failure, MovieEntity>> getSingleMovie(String id) async {
    if (await networkInfo.isConnected) {
      try {
        final movie = await remoteDataSource.getSingleMovie(id);
        await localDataSource.cachMovie(movie);
        return Right(movie);
      } catch (e) {
        try {
          final movie = await localDataSource.getSingleMovie(id);
          return Right(movie);
        } catch (e) {
          return Left(CacheFailure());
        }
      }
    } else {
      try {
        final article = await localDataSource.getSingleMovie(id);
        return Right(article);
      } catch (e) {
        return Left(CacheFailure());
      }
    }
  }

  @override
  Future<Either<Failure, MovieEntity>> addToBookmark(MovieEntity movie) async {
    await localDataSource.addToBookmark(movie as MovieModel);
    return Right(movie);
  }

   @override
  Future<Either<Failure, List<MovieEntity>>> filteredMovies (String title) async {
    if (await networkInfo.isConnected) {
      try {
        final movies = await remoteDataSource.filteredMovies(title);

        return Right(movies);
      } catch (e) {
        final articles = await localDataSource.getAllMovies();
        return Right(articles);
      }
    } else {
      final movies = await localDataSource.getSingleMovie(title);
      return Right([movies]);
    }
  }
}
