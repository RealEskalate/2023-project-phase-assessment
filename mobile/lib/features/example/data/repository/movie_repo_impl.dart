import 'package:mobile/features/example/data/datasources/remote_data_source/remote_data_source.dart';
import 'package:mobile/features/example/domain/entities/Movie.dart';
import 'package:mobile/features/example/domain/repositories/movie_repository.dart';

class MovieRepoImpl implements MovieRepository{

  final RemoteSource remoteSource;

  MovieRepoImpl({required this.remoteSource});

  @override
  Future<List<Movie>> getAllMovies() async {
    // print("repo");
    final data = await remoteSource.getAllMovies();
    return data;
  }

  Future<Movie> getOneMovie(String? id) async {
    final data = remoteSource.getOneMovie(id);
    return data;
  }
}