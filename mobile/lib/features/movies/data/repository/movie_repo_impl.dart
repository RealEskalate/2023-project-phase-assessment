import 'dart:developer';
import 'dart:io';
import 'package:mobile/features/movies/data/datasources/api_datasource.dart';
import 'package:mobile/features/movies/domain/entities/movie.dart';
import 'package:path/path.dart';
import 'package:async/async.dart';

import 'package:dartz/dartz.dart';
import 'package:http/http.dart';

import '../../../../core/error/failure.dart';
import '../../domain/repositories/movie_repository.dart';

class MovieRepositoryImpl implements MovieRepository {
  final MovieRemoteDataSource remoteDataSource;

  MovieRepositoryImpl({required this.remoteDataSource});

  @override
  Future<Either<Failure, List<Movie>>> getAllMovies() async {
    try {
      final movies = await remoteDataSource.getAllMovies();

      return Right(movies);
    } catch (e) {
      log("Error fetching movies repo-: $e");
      return const Left(ServerFailure('Zerubabel was here'));
    }
    // TODO: implement getAllMovies
  }

  @override
  Future<Either<Failure, Movie>> getSingleMovie(String movieId) async {
    // TODO: implement getSingleMovie
    throw UnimplementedError();
  }

  @override
  Future<Either<Failure, List<Movie>>> searchMovie(String query) async {
    // TODO: implement searchMovie
    throw UnimplementedError();
  }
}
