import 'package:dartz/dartz.dart';

import 'package:mobile/core/error/failure.dart';
import 'package:mobile/core/network/network_info.dart';
import 'package:mobile/features/example/data/datasources/local/movie_local_datasource.dart';
import 'package:mobile/features/example/data/datasources/remote/movie_remote_datasource.dart';
import 'package:mobile/features/example/data/models/movie_model.dart';

import 'package:mobile/features/example/domain/entities/movie_entity.dart';

import '../../domain/repositories/movie_repository.dart';

class MovieRepositoryImpl implements MovieRepository {
  final LocalDatasource localDatasource;
  final RemoteDatasource remoteDatasource;
  final NetworkInfo networkInfo;

  MovieRepositoryImpl({
    required this.localDatasource,
    required this.remoteDatasource,
    required this.networkInfo,
  });

  @override
  Future<Either<Failure, List<MovieEntity>>> filterMovies(
      String searchParams) async {
    if (await networkInfo.isConnected) {
      try {
        final movies = await remoteDatasource.filterMovies(searchParams);
        return Right(movies);
      } catch (e) {
        final movies = await localDatasource.getMovies();
        return Right(movies);
      }
    } else {
      final movies = await localDatasource.getMovies();
      return Right(movies);
    }
  }

  @override
  Future<Either<Failure, List<MovieEntity>>> getAllMovies() async {
    if (await networkInfo.isConnected) {
      try {
        final movies = await remoteDatasource.getAllMovies();
        await localDatasource.cacheMovies(movies);
        return Right(movies);
      } catch (e) {
        final movies = await localDatasource.getMovies();
        return Right(movies);
      }
    } else {
      final movies = await localDatasource.getMovies();
      return Right(movies);
    }
  }

  @override
  Future<Either<Failure, MovieEntity>> getMovie(String id) async {
    if (await networkInfo.isConnected) {
      try {
        final movie = await remoteDatasource.getMovie(id);
        await localDatasource.cacheMovie(movie);
        return Right(movie);
      } catch (e) {
        try {
          final movie = await localDatasource.getMovie(id);
          return Right(movie);
        } catch (e) {
          return Left(CacheFailure());
        }
      }
    } else {
      try {
        final movie = await localDatasource.getMovie(id);
        return Right(movie);
      } catch (e) {
        return Left(CacheFailure());
      }
    }
  }

  @override
  Future<Either<Failure, MovieEntity>> addToBookmark(MovieEntity movie) async {
    final movieModel = MovieModel(
      id: movie.id,
      title: movie.title,
      category: movie.category,
      description: movie.description,
      image: movie.image,
      createdAt: movie.createdAt,
      duration: movie.duration,
      rating: movie.rating,
    );
    localDatasource.addMovieToBookmarks(movieModel);
    return Right(movie);
  }

  @override
  Future<Either<Failure, MovieEntity>> removeFromBookmark(
      String movieId) async {
    final movie = await localDatasource.removeMovieFromBookmarks(movieId);
    return Right(movie);
  }

  @override
  Future<Either<Failure, List<MovieEntity>>> getBookmarkedMovies() async {
    final movies = await localDatasource.getBookmarkedMovies();
    return Right(movies);
  }
}
