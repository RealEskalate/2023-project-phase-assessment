import 'package:dartz/dartz.dart';
import 'package:mobile/features/movie-detail/data/datasource/remote/remore_datasource.dart';

import '../../../../core/network/network_info.dart';
import '../../domain/repository/movie_detail_repository.dart';
import '../../../../core/errors/failures/failure.dart';
import '../../domain/entity/movie.dart';

class MovieDetailRepositoryImpl extends MovieDetailRepository {
  final RemoteDatasource remoteDatasource;
  final NetworkInfo networkInfo;

  MovieDetailRepositoryImpl(
      {required this.networkInfo, required this.remoteDatasource});
  Future<Either<Failure, Movie>> getMovie(String id) async {
    if (await networkInfo.isConnected) {
      final movie = await remoteDatasource.getMovie(id);
      return Right(movie);
    } else {
      return Left(ServerFailure(message: 'No internet connection'));
    }
  }
}
