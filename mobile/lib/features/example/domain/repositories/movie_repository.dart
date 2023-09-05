import '../../../../core/exceptions/Failure.dart';
import '../entities/movie.dart';
import 'package:dartz/dartz.dart';


abstract class MovieRepository{
  Future<Either<Failure, List<Movie>>> getMovies();
  Future<Either<Failure, List<Movie>>> searchMovies(String query);

} 