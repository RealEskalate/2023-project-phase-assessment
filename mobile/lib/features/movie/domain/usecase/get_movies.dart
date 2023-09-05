import 'package:mobile/core/usecase/usecase.dart';
import 'package:mobile/core/utils/typedef.dart';

import '../entities/movie.dart';
import '../repository/movie_repo.dart';

class GetMovies extends UsecaseWithoutParams<List<Movie>> {
  final MovieRepository _movieRepository;

  GetMovies(this._movieRepository);

  @override
  ResultFuture<List<Movie>> call() => _movieRepository.getMovies();
}
