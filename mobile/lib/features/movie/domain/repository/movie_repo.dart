import 'package:mobile/core/utils/typedef.dart';

import '../entities/movie.dart';

abstract class MovieRepository {
  

  ResultFuture<List<Movie>> getMovies();
}
