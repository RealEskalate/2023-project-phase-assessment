import 'package:second/feature/main_page/data/model/movie_model.dart';
import 'package:shared_preferences/shared_preferences.dart';

abstract class MovieLocalDataSource {
  SharedPreferences get sharedPreferences;
  Future<List<MovieModel>> getBookMarkMovies();
}

class MovieLocalDataSourceImpl implements MovieLocalDataSource {
  @override
  final SharedPreferences sharedPreferences;

  MovieLocalDataSourceImpl({required this.sharedPreferences});
  
  @override
  Future<List<MovieModel>> getBookMarkMovies() {

  }
}
