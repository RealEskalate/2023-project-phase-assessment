import 'package:dartz/dartz.dart';
import 'package:mobile/core/error/exceptions.dart';
import 'package:mobile/core/error/failure.dart';
import 'package:mobile/core/utils/typedef.dart';
import 'package:mobile/features/movie/domain/entities/movie.dart';

import '../../domain/repository/movie_repo.dart';
import '../datasources/remote_data_sources.dart';

class MovieRepositoryImp extends MovieRepository {
  final MovieRemoteDataSource _remoteDataSource;
  MovieRepositoryImp(this._remoteDataSource);

  @override
  ResultFuture<List<Movie>> getMovies() async {
    try {
      final result = await _remoteDataSource.getMovies();
      return Right(result);
    } on ServerException catch (e) {
      return Left(ServerFailure(
        message: e.message,
        statusCode: e.statusCode,
      ));
    }
  }
}
