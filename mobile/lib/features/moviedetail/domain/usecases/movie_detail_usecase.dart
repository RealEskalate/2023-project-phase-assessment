import 'package:mobile/features/moviedetail/data/repositories/movie_detail_repo_impl.dart';
import 'package:mobile/features/get_all_movie/domain/entities/movie_entities.dart';

class GetMovieDetailUseCase {
  final MovieRepositoryImpl movieRepository;

  GetMovieDetailUseCase(this.movieRepository);

  Future<MovieEntities> execute(String movieId) async {
    return movieRepository.getMovieDetail(movieId);
  }
}
