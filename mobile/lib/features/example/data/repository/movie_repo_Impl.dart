import 'package:dartz/dartz.dart';
import 'package:mobile/core/Errors/Failure.dart';
import 'package:mobile/features/example/domain/entities/movie.dart';
import 'package:mobile/features/example/domain/repositories/movie_repo.dart';
import "../datasources/remote_data_source_impl.dart";

class MovieRepoImpl implements MovieRepo {
  @override
  Future<Either<Failure, List<Movie>>> getMovies() async {
    RemoteDataSourceImpl remote = RemoteDataSourceImpl();
    return await remote.getMovies();
  }

  @override
  Future<Either<Failure, List<Movie>>> movieDetail(String id) {
    // TODO: implement movieDetail
    throw UnimplementedError();
  }

  @override
  Future<Either<Failure, List<Movie>>> searchMovies(String s) async {
    RemoteDataSourceImpl remote = RemoteDataSourceImpl();
    return await remote.searchMovies(s);
  }
  
  @override
  Future<Either<Failure, List<Movie>>> getBookMark() async {
   RemoteDataSourceImpl remote = RemoteDataSourceImpl();
   return await remote.getBookMarks();
  }
  
  @override
  Future<Either<Failure, void>> setBookMark(Movie movie) async {
    RemoteDataSourceImpl remote = RemoteDataSourceImpl();
   return await remote.setBookMark(movie);
  }
}
