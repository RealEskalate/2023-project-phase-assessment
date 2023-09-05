import 'package:dartz/dartz.dart';
import 'package:mobile/core/failure.dart';
import 'package:mobile/features/movies/domain/entities/movie.dart';
import 'package:mobile/features/movies/domain/repositories/movies_repository.dart';

class GetMoviesUseCase {
  final MoviesRepository _moviesRepository;

  GetMoviesUseCase(this._moviesRepository);

  Future<Either<Failure, List<Movie>>> execute([searchParams= String]) async {
    if(searchParams != null){
      return await _moviesRepository.getMovies(searchParams: searchParams);
    }
    return await _moviesRepository.getMovies();
  }
}