import 'package:mobile/features/get_all_movie/data/models/movie_model.dart';
import 'package:mobile/features/get_all_movie/domain/entities/movie_entities.dart';
import 'package:mobile/features/search/data/datasources/search_remote_data_source.dart';
import 'package:mobile/features/search/domain/entities/search_entities.dart';

class SearchRepositoryImpl implements SearchRepository {
  final SearchRemoteDataSource remoteDataSource;

  SearchRepositoryImpl(this.remoteDataSource);

  @override
  Future<List<MovieEntities>> searchMovies(String searchTerm) async {
    final List<MovieModel> movieModels =
        await remoteDataSource.searchMoviesData(searchTerm);
    return movieModels.map((movieModel) => movieModel.toEntity()).toList();
  }
}

class SearchRepository {}
