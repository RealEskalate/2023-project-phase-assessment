import 'package:dartz/dartz.dart';
import 'package:mobile/core/errors/exception.dart';
import 'package:mobile/core/errors/failure.dart';
import 'package:mobile/core/network/network_info.dart';
import 'package:mobile/features/example/data/datasources/movie_local_data_source.dart';
import 'package:mobile/features/example/data/datasources/movie_remote_data_source.dart';
import 'package:mobile/features/example/domain/entities/movie.dart';
import 'package:mobile/features/example/domain/repositories/movie_repository.dart';

class MovieRepositoryImpl extends MovieRepository {
  final NetworkInfo networkInfo;
  final MovieLocalDataSource localDataSource;
  final MovieRemoteDataSource remoteDataSource;

  MovieRepositoryImpl(
      {required this.networkInfo,
      required this.localDataSource,
      required this.remoteDataSource});

  @override
  Future<Either<Failure, Movie>> getMovieById(String id) async {
    try {
      final remoteMovie = await remoteDataSource.getMovieById(id);
      return Right(remoteMovie);
    } on ServerException {
      return Left(ServerFailure(
        message: "No Connection",
        statusCode: 400,
      ));
    }
  }

  @override
  Future<Either<Failure, List<Movie>>> getMovieBySearch(
      String searchParams) async {
    try {
      final remoteMovie = await remoteDataSource.getMovieBySearch(searchParams);
      return Right(remoteMovie);
    } on ServerException {
      return Left(ServerFailure(
        message: "No Connection",
        statusCode: 400
      ));
    }
  }

  @override
  Future<Either<Failure, List<Movie>>> getMovies() async {
    try {
      final remoteMovie = await remoteDataSource.getMovie();
      return Right(remoteMovie);
    } on ServerException {
      return Left(ServerFailure(statusCode: 400, message: "No Connection"));
    }
  }
}
