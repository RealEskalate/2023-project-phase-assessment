// ignore_for_file: public_member_api_docs, sort_constructors_first
import 'package:dartz/dartz.dart';

import 'package:mobile/core/error/failure.dart';
import 'package:mobile/features/movie/data/data_sources/local_data_source.dart';
import 'package:mobile/features/movie/data/models/movie_model.dart';
import 'package:mobile/features/movie/domain/entities/movie_entity.dart';
import 'package:mobile/features/movie/domain/repositories/movie_repository.dart';

import '../../../../core/error/exception.dart';
import '../../../../core/network/network_info.dart';
import '../data_sources/remote_data_source.dart';

class MovieRepositoryImpl implements MovieRepository {
  final MovieRemoteDataSource remoteDataSource;
  final MovieLocalDataSource localDataSource;
  final NetworkInfo networkInfo;
  MovieRepositoryImpl({
    required this.remoteDataSource,
    required this.localDataSource,
    required this.networkInfo,
  });

  @override
  Future<Either<Failure, List<MovieEntity>>> getAllMovies() async {
    if (await networkInfo.isConnected) {
      try {
        final remoteMovies = await remoteDataSource.getAllMovies();
        localDataSource.cacheMovies(remoteMovies);
        return Right(remoteMovies);
      } on ServerException {
        return Left(ServerFailure(message: "Server Failure"));
      } on NetworkException {
        return Left(ConnectionFailure(message: "Messge Failure"));
      }
    } else {
      try {
        final localMovies = await localDataSource.getAllMovies();
        return Right(localMovies);
      } on CacheException {
        return Left(CacheFailure(message: "Cache Failure"));
      } on NetworkException {
        return Left(ConnectionFailure(message: "Connection Faulire"));
      }
    }
  }

  @override
  Future<Either<Failure, MovieEntity>> getMovie(String movieId) async {
    if (await networkInfo.isConnected) {
      try {
        final remoteMovie = await remoteDataSource.getMovie(movieId);
        localDataSource.cacheMovie(remoteMovie);
        return Right(remoteMovie);
      } on ServerException {
        return Left(ServerFailure(message: "Server Faulure"));
      } on NetworkException {
        return Left(ConnectionFailure(message: "Connectin Failure"));
      }
    } else {
      try {
        final localMovie = await localDataSource.getMovie(movieId);
        return Right(localMovie);
      } on CacheException {
        return Left(CacheFailure(message: "CacheFailure"));
      } on NetworkException {
        return Left(ConnectionFailure(message: "connection failure"));
      }
    }
  }

  @override
  Future<Either<Failure, void>> bookmarkMovie(MovieEntity movieEntity) async {
    try {
      MovieModel movieModel = MovieModel(
        id: movieEntity.id,
        title: movieEntity.title,
        description: movieEntity.description,
        category: movieEntity.category,
        duration: movieEntity.duration,
        rating: movieEntity.rating,
        image: movieEntity.image,
        createdAt: movieEntity.createdAt,
      );

      await localDataSource.bookmarkMovie(movieModel);
      return const Right(null);
    } on CacheException {
      return Left(CacheFailure(message: "cache failure"));
    }
  }

  @override
  Future<Either<Failure, List<MovieEntity>>> getBookmarkedMovies() async {
    try {
      final bookmarks = await localDataSource.getBookmarkedMovies();
      return Right(bookmarks);
    } on CacheException {
      return Left(CacheFailure(message: "cache failure"));
    }
  }

  @override
  Future<Either<Failure, void>> removeMovieFromBookmark(
      MovieEntity movieEntity) async {
    try {
      MovieModel movieModel = MovieModel(
        id: movieEntity.id,
        title: movieEntity.title,
        description: movieEntity.description,
        category: movieEntity.category,
        duration: movieEntity.duration,
        rating: movieEntity.rating,
        image: movieEntity.image,
        createdAt: movieEntity.createdAt,
      );

      localDataSource.removeMovieFromBookmark(movieModel);
      return const Right(null);
    } on CacheException {
      return Left(CacheFailure(message: "cache failure"));
    }
  }

  @override
  Future<Either<Failure, List<MovieEntity>>> searchMovies(
      String queryParams) async {
    if (await networkInfo.isConnected) {
      try {
        final remoteMovies = await remoteDataSource.searchMovies(queryParams);
        localDataSource.cacheMovies(remoteMovies);
        return Right(remoteMovies);
      } on ServerException {
        return Left(ServerFailure(message: "Server Failure"));
      } on NetworkException {
        return Left(ConnectionFailure(message: "connection faulire"));
      }
    }
    return Left(ConnectionFailure(message: "connection faulire"));
  }
}
