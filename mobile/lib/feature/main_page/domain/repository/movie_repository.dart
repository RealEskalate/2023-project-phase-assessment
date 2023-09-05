import 'package:dartz/dartz.dart';
import 'package:second/feature/main_page/domain/entitie/movie_entite.dart';

import '../../../../core/error/failure.dart';

abstract class MovieRepository {
  Future<Either<Failure, List<MovieEntitie>>> getAllMovie();
  Future<Either<Failure, MovieEntitie>> getSingleMovie({required String id});
  Future<Either<Failure, List<MovieEntitie>>> getSearchedMovie({required String movieName});
  Future<Either<Failure, List<MovieEntitie>>> getBookMarkedMovie();
}
