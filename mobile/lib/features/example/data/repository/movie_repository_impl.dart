import 'package:dartz/dartz.dart';
import 'package:mobile/core/Error/failures.dart';
import 'package:mobile/features/example/data/datasources/movie_remote_data_source_impl.dart';
import 'package:mobile/features/example/data/models/movie_model.dart';
import 'package:mobile/features/example/domain/repositories/movie_repositry.dart';

class MovieRepositoryImpl implements MovieRepository {
  final MovieRemoteDataSource remoteDataSource;

  MovieRepositoryImpl(this.remoteDataSource);

  @override
  Future<Either<Faliure, List<MovieModel>>> getMovie() async {
    
    return await remoteDataSource.getMovie();
  }

  @override
  Future<Either<Faliure, List<MovieModel>>> searchMovie(String query) async {
   return remoteDataSource.searchMovie(query);
  }
}
