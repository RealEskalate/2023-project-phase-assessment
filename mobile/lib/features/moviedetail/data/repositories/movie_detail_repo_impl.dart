import 'package:mobile/features/get_all_movie/data/repositories/movies_repositories.dart';
import 'package:mobile/features/get_all_movie/domain/entities/movie_entities.dart';
import 'package:mobile/features/moviedetail/data/datasources/remote_data_sources.dart';

class MovieRepositoryImpl implements MovieRepository {
  final MovieProvider movieProvider;

  MovieRepositoryImpl(this.movieProvider);

  @override
  Future<MovieEntities> getMovieDetail(String movieId) async {
    final movieData = await movieProvider.getMovieDetailData(movieId);
    return MovieEntities(
      id: movieData['_id'],
      category: movieData['category'],
      title: movieData['title'],
      description: movieData['description'],
      duration: movieData['duration'],
      image: movieData['image'],
      rating: movieData['rating'].toDouble(),
    );
  }

  @override
  Future<List<MovieEntities>> getAllMovies() {
    // TODO: implement getAllMovies
    throw UnimplementedError();
  }
}
