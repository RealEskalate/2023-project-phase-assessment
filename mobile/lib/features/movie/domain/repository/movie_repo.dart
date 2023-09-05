import 'package:mobile/core/utils/typedef.dart';

import '../entities/movie.dart';

abstract class MovieRepository {
  ResultVoid createUser({
    required String category,
    required String image,
    required String createdAt,
  });

  ResultFuture<List<Movie>> getMovies();
}
