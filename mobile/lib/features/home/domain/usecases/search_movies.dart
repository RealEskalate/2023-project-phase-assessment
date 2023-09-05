import 'package:dartz/dartz.dart';

import '../../../../core/errors/failures/failure.dart';
import '../../data/repositories/movie_repository_impl.dart';
import '../entities/movie.dart';
import '../repositories/movie_repository.dart';

class SearchForMovies {
  MovieRepository repository;
  SearchForMovies(this.repository);
  Future<Either<Failure, List<Movie>>> call(String term) async {
    final movies = await repository.searchMovies(term);
    return movies;
  }
}
