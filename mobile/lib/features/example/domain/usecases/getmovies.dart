import 'package:dartz/dartz.dart';
import 'package:mobile/features/example/data/datasources/remote_data_source.dart';
import 'package:mobile/features/example/data/models/film_models.dart';

class FetchMoviesUseCase {
  final UserApiDataSource dataSource;

  FetchMoviesUseCase({required this.dataSource});

  Future<Either<Exception, List<Movie>>> execute() async {
    try {
      final movies = await dataSource.fetchMovies();
      return Right(movies);
    } catch (e) {
      return Left(Exception('Failed to fetch movies: $e'));
    }
  }
}
