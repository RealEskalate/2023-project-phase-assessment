import 'dart:developer';
import 'dart:io';
import 'package:mobile/features/example/data/datasources/api_data_source.dart';
import 'package:mobile/features/example/data/models/model.dart';
import 'package:mobile/features/example/domain/entities/movie.dart';
import 'package:mobile/features/example/data/repository/movie_repository_impl.dart';
import 'package:path/path.dart';
import 'package:async/async.dart';

import 'package:dartz/dartz.dart';
import 'package:http/http.dart';

import '../../../../core/error/failure.dart';
import '../../domain/repositories/movie_repository.dart';

class MovieRepositoryImpl implements MovieRepository {
  final MovieRemoteDataSource remoteDataSource;

  MovieRepositoryImpl({required this.remoteDataSource});

  // @override
  // Future<Either<Failure, List<Movie>>> getAllMovies() async {
  //   try {
  //     final movies = await remoteDataSource.getAllMovies();

  //     return Right(movies);
  //   } catch (e) {
  //     log("Error fetching articles repo-: $e");
  //     return const Left(ServerFailure('error here'));
  //   }
  //   // TODO: implement getAllMovies
  //   throw UnimplementedError();
  // }

  // @override
  // Future<Either<Failure, Movie>> getSingleMovie(String movieId) async {
  //   // TODO: implement getSingleMovie
  //   throw UnimplementedError();
  // }

  @override
  Future<Either<Failure, List<Movie>>> searchMovie(String query) async {
    // TODO: implement searchMovie
    throw UnimplementedError();
  }

  @override
  Future<MovieEntity> addToBookmarks({required String category, required String title, required String description, required String duration, required String image, required double rating, required DateTime createdAt, required String id}) {
    // TODO: implement addToBookmarks
    throw UnimplementedError();
  }

  @override
  Future<List<MovieEntity>> getBookmarks() {
    // TODO: implement getBookmarks
    throw UnimplementedError();
  }

  @override
  Future<void> removeFromBookmarks(String id) {
    // TODO: implement removeFromBookmarks
    throw UnimplementedError();
  }
  
  @override
  Future<List<MovieEntity>> getAllMovies() {
    // TODO: implement getAllMovies
    throw UnimplementedError();
  }
  
  @override
  Future<MovieEntity> getSingleMovie(String id) {
    // TODO: implement getSingleMovie
    throw UnimplementedError();
  }
}
