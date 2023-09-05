import 'dart:developer';

import 'package:mobile/features/example/domain/repositories/repository.dart';

import '../../domain/entities/movie.dart';
import 'package:dartz/dartz.dart';
import '../../../../core/error/failure.dart';
import '../datasources/datasource_api.dart';
import '../models/movie.dart' as moviemodel;

class MoviesRepositoryImp implements MovieRepository {
  final MovieRemoteDataSource remoteDataSource;
  final MoviesLocalDataSource localDataSource;

  MoviesRepositoryImp(
      {required this.remoteDataSource, required this.localDataSource});

  @override
  Future<Either<Failure, bool>> addBookmark(
      {required String id,
      required String title,
      required String category,
      required String description,
      required String duration,
      required String image,
      required double rating,
      required String createdAt}) async {
    try {
      log("Converting image to multipart");

      final movieData = {
        "id": id,
        "title": title,
        "category": category,
        "description": description,
        "duration": duration,
        "image": image,
        "rating": rating.toDouble(),
        "createdAt": createdAt,
      };
      log('Saving movie From Repo imp');
      final response = await localDataSource.addBookmark(movieData);
      log('Saving movie repo = received');

      return Right(response as bool);
    } catch (e) {
      return const Left(ServerFailure('Error creating movies'));
    }
  }

  @override
  Future<Either<Failure, List<moviemodel.MovieModel>>> getAllBookmarks() async {
    try {
      final movies = await localDataSource.getAllBookmarks();

      return movies;
    } catch (e) {
      log("Error fetching movies : $e");
      return const Left(ServerFailure('Error fetching movies'));
    }
  }

  @override
  Future<Either<Failure, List<Movie>>> getAllMovies() async {
    try {
      final movies = await remoteDataSource.getAllMovies();

      return Right(movies);
    } catch (e) {
      log("Error fetching movies-: $e");
      return const Left(ServerFailure('Error fetching movies'));
    }
  }

  @override
  Future<Either<Failure, Movie>> getSingleMovie(String movieId) {
    // TODO: implement getSingleMovie
    throw UnimplementedError();
  }

  @override
  Future<Either<Failure, List<Movie>>> searchMovie(String tag, String key) {
    // TODO: implement searchMovie
    throw UnimplementedError();
  }
}
