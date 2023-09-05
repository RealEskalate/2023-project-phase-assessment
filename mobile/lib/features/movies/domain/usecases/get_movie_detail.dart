import 'package:dartz/dartz.dart';
import 'package:mobile/features/movies/domain/repositories/movie_repository.dart';

import '../../../../core/error/failure.dart';
import '../entities/movie.dart';

class GetMovieDetail {
  final MovieRepository movieRepository;

  GetMovieDetail(this.movieRepository);

  Future<Either<Failure, Movie>> call({required Movie movie}) {
    return movieRepository.getMovieDetail(movie);
  }
}
