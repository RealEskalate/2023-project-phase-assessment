import 'dart:convert';

import 'package:mobile/features/example/data/datasources/local/movie_local_datasource.dart';
import 'package:mobile/features/example/data/models/movie_model.dart';
import 'package:shared_preferences/shared_preferences.dart';

import '../../../../../core/error/exception.dart';

class LocalDatasourceImpl implements LocalDatasource {
  final SharedPreferences sharedPreferences;
  final movieKey = "movie_key";
  final bookmarkKey = "bookmark_key";

  LocalDatasourceImpl({required this.sharedPreferences});

  @override
  Future<void> cacheMovie(MovieModel movie) async {
    final movies = await getMovies();
    final movieIndex = movies.indexWhere((element) => element.id == movie.id);

    if (movieIndex == -1) {
      movies.add(movie);
    } else {
      movies[movieIndex] = movie;
    }

    await cacheMovies(movies);
  }

  @override
  Future<void> cacheMovies(List<MovieModel> movies) async {
    final jsonEncoded = jsonEncode(movies);

    await sharedPreferences.setString(movieKey, jsonEncoded);
  }

  @override
  Future<MovieModel> getMovie(String id) async {
    final movies = await getMovies();

    for (final movie in movies) {
      if (movie.id == id) {
        return movie;
      }
    }

    throw const CacheException(message: 'Operation Failed.');
  }

  @override
  Future<List<MovieModel>> getMovies() async {
    final jsonEncoded = sharedPreferences.getString(movieKey);

    if (jsonEncoded != null) {
      final List<dynamic> jsonDecoded = jsonDecode(jsonEncoded);
      final movies = jsonDecoded
          .map<MovieModel>((movie) => MovieModel.fromJson(movie))
          .toList();

      return movies;
    }

    return <MovieModel>[];
  }

  @override
  Future<List<MovieModel>> getBookmarkedMovies() async {
    final jsonEncoded = sharedPreferences.getString(bookmarkKey);

    if (jsonEncoded != null) {
      final List<dynamic> jsonDecoded = jsonDecode(jsonEncoded);
      final movies = jsonDecoded
          .map<MovieModel>((map) => MovieModel.fromJson(map))
          .toList();

      return movies;
    }

    return <MovieModel>[];
  }

  @override
  Future<void> addMovieToBookmarks(MovieModel movie) async {
    final movies = await getBookmarkedMovies();

    final movieIndex = movies.indexWhere((element) => element.id == movie.id);

    if (movieIndex == -1) {
      movies.add(movie);
    } else {
      movies[movieIndex] = movie;
    }

    final jsonEncoded = jsonEncode(movies);
    await sharedPreferences.setString(bookmarkKey, jsonEncoded);
  }

  @override
  Future<MovieModel> removeMovieFromBookmarks(String movieId) async {
    final movies = await getBookmarkedMovies();

    final filteredMovies = movies.where((movie) => movie.id != movieId);

    final encodedMovies = jsonEncode(filteredMovies.toList());
    await sharedPreferences.setString(bookmarkKey, encodedMovies);

    return movies.firstWhere((movie) => movie.id == movieId);
  }
}
