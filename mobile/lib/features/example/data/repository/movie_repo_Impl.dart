import 'package:dartz/dartz.dart';
import 'package:mobile/core/Errors/Failure.dart';
import 'package:mobile/features/example/data/datasources/remote_data_source.dart';
import 'package:mobile/features/example/domain/entities/movie.dart';
import 'package:mobile/features/example/domain/repositories/movie_repo.dart';
import "../datasources/remote_data_source_impl.dart";

class MovieRepoImpl implements MovieRepo {
  
  MovieRepoImpl(this.remote);
  
  RemoteDataSource remote;

  @override
  Future<Either<Failure, List<Movie>>> getMovies() async {
    return await remote.getMovies();
  }


  @override
  Future<Either<Failure, List<Movie>>> searchMovies(String s) async {
    return await remote.searchMovies(s);
  }
  
  @override
  Future<Either<Failure, List<Movie>>> getBookMark() async {
   return await remote.getBookMarks();
  }
  
  @override
  Future<Either<Failure, void>> setBookMark(Movie movie) async {
   return await remote.setBookMark(movie);
  }
}
