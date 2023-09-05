import 'package:mobile/features/get_all_movie/data/repositories/movies_repositories.dart';
import 'package:mobile/features/get_all_movie/domain/entities/movie_entities.dart';

class GetAllMoviesUseCase {
  final MovieRepository movieRepository;

  GetAllMoviesUseCase(this.movieRepository);

  Future<List<MovieEntities>> execute() async {
    return movieRepository.getAllMovies();
  }
}
