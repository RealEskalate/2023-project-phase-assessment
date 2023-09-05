
import 'package:dartz/dartz.dart';
import 'package:mobile/core/Errors/Failure.dart';
import 'package:mobile/features/example/domain/entities/movie.dart';

abstract class RemoteDataSource{
  Future<Either<Failure,List<Movie>>> getMovies();
  Future<Either<Failure,List<Movie>>> searchMovies(String s);
  Future<Either<Failure,List<Movie>>> movieDetail(String id);
  Future<Either<Failure,void>> setBookMark(Movie movie);
  Future<Either<Failure,List<Movie>>> getBookMarks();

}