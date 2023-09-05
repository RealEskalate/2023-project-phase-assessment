import 'package:dartz/dartz.dart';

import 'package:second/core/error/failure.dart';
import 'package:second/feature/main_page/data/data_source/remote_data_source.dart';

import 'package:second/feature/main_page/domain/entitie/movie_entite.dart';

import '../../../../core/error/exception.dart';
import '../../domain/repository/movie_repository.dart';

class MovieRepositoryImpl implements MovieRepository {
  final MovieRemoteDataSource movieRemoteDataSource;

  MovieRepositoryImpl({required this.movieRemoteDataSource});
  @override
  Future<Either<Failure, List<MovieEntitie>>> getAllMovie() async {
    try {
      return Right(await movieRemoteDataSource.getAllMovieRemote());
    } on ServerException catch (e) {
      return Left(
        ServerFailure(
          message: "the server does not work know",
          statusCode: e.statusCode,
        ),
      );
    } on NetworkConnectionException {
      return const Left(NetworkConnectionFailure(
        message: "there is no connection",
        statusCode: 400,
      ));
    }
  }

  @override
  Future<Either<Failure, List<MovieEntitie>>> getBookMarkedMovie() {
    // TODO: implement getBookMarkedMovie
    throw UnimplementedError();
  }

  @override
  Future<Either<Failure, List<MovieEntitie>>> getSearchedMovie(
      {required String movieName}) async{
    try {
      return Right(await movieRemoteDataSource.getSearchedMovieRemote(movieName: movieName));
    } on ServerException catch (e) {
      return Left(
        ServerFailure(
          message: "the server does not work know",
          statusCode: e.statusCode,
        ),
      );
    } on NetworkConnectionException {
      return const Left(NetworkConnectionFailure(
        message: "there is no connection",
        statusCode: 400,
      ));
    }
  }

  @override
  Future<Either<Failure, MovieEntitie>> getSingleMovie({required String id}) async{
    try {
      return Right(await movieRemoteDataSource.getSingleMovieRemote(id: id));
    } on ServerException catch (e) {
      return Left(
        ServerFailure(
          message: "the server does not work know",
          statusCode: e.statusCode,
        ),
      );
    } on NetworkConnectionException {
      return const Left(NetworkConnectionFailure(
        message: "there is no connection",
        statusCode: 400,
      ));
    }
  }
}
