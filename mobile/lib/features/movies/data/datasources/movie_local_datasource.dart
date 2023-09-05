import 'dart:convert';

import 'package:mobile/features/movies/domain/entities/movie.dart';
import 'package:shared_preferences/shared_preferences.dart';
abstract class MovieBookmarkDataSource {
  List<Movie> getBookmarkedMovies();
  void toggleBookmark(Movie movie);
}
class MovieBookmarkDataSourceImpl implements MovieBookmarkDataSource {
  static const keyBookmarkedMovies = "BOOKMARKED_MOVIES";

  final SharedPreferences prefs;

  MovieBookmarkDataSourceImpl(this.prefs);

  List<Movie> getBookmarkedMovies() {
    final jsonList = prefs.getStringList(keyBookmarkedMovies);
    return jsonList?.map((json) => Movie.fromJson(jsonDecode(json))).toList() ??
        [];
  }

  void _saveBookmarkedMovies(List<Movie> movies) {
    final jsonList = movies.map((movie) => jsonEncode(movie.toJson())).toList();
    prefs.setStringList(keyBookmarkedMovies, jsonList);
  }

  void toggleBookmark(Movie movie) {
    print(movie.title);
    final currentList = getBookmarkedMovies();

    if (currentList.contains(movie)) {
      // Movie already bookmarked, remove it
      currentList.remove(movie);
    } else {
      // Movie not bookmarked, add it
      currentList.add(movie);
    }

    _saveBookmarkedMovies(currentList);
  }
}
