import 'package:shared_preferences/shared_preferences.dart';

abstract class MovieLocalDataSource {
  Future<String> setBookMark(String id);
}

class MovieLocalDataSourceImpl extends MovieLocalDataSource {
  final SharedPreferences _sharedPreferences;

  MovieLocalDataSourceImpl({required SharedPreferences sharedPreferences})
      : _sharedPreferences = sharedPreferences;

  @override
  Future<String> setBookMark(String id) async {
    final bookmarkedMovies = _sharedPreferences.getStringList("MOVIES");
    if (bookmarkedMovies == null) {
      await _sharedPreferences.setStringList("MOVIE", [id]);
    } else if (bookmarkedMovies.contains(id)) {
      bookmarkedMovies.remove(id);
      await _sharedPreferences.setStringList("MOVIE", bookmarkedMovies);
    } else {
      bookmarkedMovies.add(id);
      await _sharedPreferences.setStringList("MOVIE", bookmarkedMovies);
    }
    return id;
  }
}
