import 'package:dartz/dartz.dart';
import 'package:mobile/features/example/data/models/movie_model.dart';
import '../../../../core/Error/failures.dart';

abstract class MovieRepository {
  Future<Either<Faliure, List<MovieModel>>> getMovie();
  Future<Either<Faliure, List<MovieModel>>> searchMovie(String query);
}
