import 'package:dartz/dartz.dart';

import '../../../../core/errors/failures/failure.dart';
import '../entity/movie.dart';
abstract class MovieDetailRepository{
  Future<Either<Failure, Movie>> getMovie(String id);
}