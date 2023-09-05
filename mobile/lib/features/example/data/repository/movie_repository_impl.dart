import 'package:dartz/dartz.dart';
import 'package:mobile/core/exceptions/Failure.dart';
import 'package:mobile/features/example/data/datasources/remote_datasources/movie_remote_datasource.dart';
import 'package:mobile/features/example/data/datasources/remote_datasources/movie_remote_datasource_impl.dart';
import 'package:mobile/features/example/domain/entities/movie.dart';
import 'package:mobile/features/example/domain/repositories/movie_repository.dart';

class MovieRempositoryImpl extends MovieRepository{
  final MovieRemoteDataSource remoteDataSource;
  MovieRempositoryImpl({
  required this.remoteDataSource
  });
  @override
  Future<Either<Failure, List<Movie>>> getMovies() {
    final movieResponse = remoteDataSource.getMovies();
    return movieResponse;
  }
  

  @override
  Future<Either<Failure, List<Movie>>> searchMovies(String query) {
   final movieResponse = remoteDataSource.getMovies();
    return movieResponse;
  }

}