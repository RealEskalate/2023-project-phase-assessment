import 'package:dartz/dartz.dart';
import 'package:mobile/features/movies/domain/repositories/movie_repository.dart';

import '../../../../core/error/failure.dart';
import '../entities/movie.dart';

class GetSearchMovies {
  final MovieRepository movieRepository;

  GetSearchMovies(this.movieRepository);
  
  Future<Either<Failure, List<Movie>>> call() async {
    return movieRepository.getSearchMovies();
  }
}
