import 'package:dartz/dartz.dart';

import '../../../../../core/exceptions/Failure.dart';
import '../../../domain/entities/movie.dart';

abstract class MovieRemoteDataSource{
  Future<Either<Failure ,List<Movie>>> getMovies();
  Future<Either <Failure , List<Movie>>> seachMovies(String query);
}