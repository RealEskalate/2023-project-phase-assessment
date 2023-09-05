import 'package:mobile/features/get_all_movie/data/datasources/remote_data_source.dart';
import 'package:mobile/features/get_all_movie/data/models/movie_model.dart';
import 'package:mobile/features/get_all_movie/domain/entities/movie_entities.dart';

abstract class MovieRepository {
  Future<List<MovieEntities>> getAllMovies();
}

class MovieRepositoryImpl implements MovieRepository {
  final MovieRemoteDataSource remoteDataSource;

  MovieRepositoryImpl(this.remoteDataSource);

  @override
  Future<List<MovieEntities>> getAllMovies() async {
    final List<MovieModel> movieModels =
        await remoteDataSource.getAllMoviesData();
    return movieModels.map((movieModel) => movieModel.toEntity()).toList();
  }
}
