

import 'package:dartz/dartz.dart';
import 'package:mobile/core/errors/Failure.dart';
import 'package:mobile/features/HomePage/data/models/movie_data_model.dart';
import 'package:mobile/features/HomePage/domain/repositories/movie_repository.dart';

import '../../../../core/errors/exceptions.dart';
import '../datasources/remote_data_source.dart';

class MovieRepositoryImpl extends MovieRepository{
  final RemoteDataSource dataSource;
  MovieRepositoryImpl(this.dataSource);
  @override
  Future<Either<Failure, List<Data>>> getMovies() async{
      try {
      return Right(await dataSource.getMovies());
    } on ServerException {
      return Left(ServerFailure());
    }
  }

  @override
  List<Object?> get props =>[];
  
  @override
  Future<Either<Failure, List<Data>>> searchMovies(String param) async{
    try {
      return Right(
          await dataSource.searchMovies(param));
    } on ServerException {
      return Left(ServerFailure());
    }
  } 
}