import 'package:dartz/dartz.dart';

import '../entities/movie.dart';
import '../../../../core/errors/failures/failure.dart';

abstract class MovieRepository {
  Future<Either<Failure, List<Movie>>> getAllMovie();
  Future<Either<Failure, List<Movie>>> searchMovie(String searchTerm);
  Future<Either<Failure, List<Movie>>> getFavorites();
  Future addFavorite(String id);
}
