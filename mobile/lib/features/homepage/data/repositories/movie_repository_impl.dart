import 'package:dartz/dartz.dart';
import 'package:mobile/features/homepage/data/datasource/local-datasource/local_datasource.dart';
import 'package:mobile/features/movie-detail/data/datasource/remote/remore_datasource.dart';

import '../../../../core/network/network_info.dart';
import '../../domain/repositories/movie_repository.dart';
import '../../domain/entities/movie.dart';
import '../../../../core/errors/failures/failure.dart';

class MovieRepositoryImpl extends MovieRepository {
  final RemoteDatasource remoteDatasource;
  final LocalDatasource localDatasource;
  final NetworkInfo networkInfo;

  MovieRepositoryImpl(
      {required this.remoteDatasource,
      required this.localDatasource,
      required this.networkInfo});

  @override
  Future<Either<Failure, List<Movie>>> getAllMovie() async {
    if (await networkInfo.isConnected){

    }else{
      return Left(ServerFailure(message: 'No internet connection'));
    }
    throw UnimplementedError();
  }

  @override
  Future<Either<Failure, List<Movie>>> searchMovie(String searchTerm) async {
    if (await networkInfo.isConnected) {
    } else {
      return Left(ServerFailure(message: 'No internet connection'));
    }
    throw UnimplementedError();
  }

  @override
  Future<Either<Failure, List<Movie>>> getFavorites() async {
    throw UnimplementedError();
  }
  
  @override
  Future addFavorite(String id) async {
    // TODO: implement addFavorite
    throw UnimplementedError();
  }
}
