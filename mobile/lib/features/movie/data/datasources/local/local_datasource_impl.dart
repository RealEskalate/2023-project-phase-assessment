import 'dart:convert';

import 'package:shared_preferences/shared_preferences.dart';

import '../../../../../core/constants/constants.dart';
import '../../../../../core/error/exceptions.dart';
import '../../models/movie_model.dart';
import 'local_datasource.dart';

class LocalDataSourceImpl extends LocalDataSource {
  final SharedPreferences sharedPreferences;

  LocalDataSourceImpl({required this.sharedPreferences});

  @override
  Future<void> cacheBookMarkedMovie(MovieModel movie) async {
    final movies = await getCachedBookMarkedMovies();

    final movieIndex = movies.indexWhere((element) => element.id == movie.id);

    if (movieIndex == -1) {
      movies.add(movie);
    } else {
      movies[movieIndex] = movie;
    }

    await cacheMovies(movies);
  }

  @override
  Future<void> cacheBookMarkedMovies(List<MovieModel> movies) async {
    final jsonEncoded = jsonEncode(movies);

    await sharedPreferences.setString(CACHED_BOOKMARKED_MOVIES, jsonEncoded);
  }

  @override
  Future<void> cacheMovie(MovieModel movie) async {
    final movies = await getCachedMovies();

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

    await sharedPreferences.setString(CACHED_MOVIES, jsonEncoded);
  }

  @override
  Future<List<MovieModel>> getCachedBookMarkedMovies() async {
    final jsonEncoded = sharedPreferences.getString(CACHED_BOOKMARKED_MOVIES);

    if (jsonEncoded != null) {
      final List<dynamic> jsonDecoded = jsonDecode(jsonEncoded);
      final movies =
          jsonDecoded.map<MovieModel>((e) => MovieModel.fromJson(e)).toList();

      return movies;
    } else {
      return <MovieModel>[];
    }
  }

  @override
  Future<List<MovieModel>> getCachedMovies() async {
    final jsonEncoded = sharedPreferences.getStringList(CACHED_MOVIES);

    if (jsonEncoded != null) {
      final movies =
          jsonEncoded.map((e) => MovieModel.fromJson(json.decode(e))).toList();

      return movies;
    } else {
      throw const CacheException(message: 'No movies cached');
    }
  }

  @override
  Future<MovieModel> removeBookMarkedMovie(MovieModel movie) async {
    final bookmarkedMovies = await getCachedBookMarkedMovies();

    final filteredMovies =
        bookmarkedMovies.where((movie) => movie.id != movie.id);

    await cacheBookMarkedMovies(filteredMovies.toList());

    return bookmarkedMovies.firstWhere((movie) => movie.id == movie.id);
  }

  @override
  Future<MovieModel> getMovie(String id) async {
    final movies = await getCachedMovies();

    for (final movie in movies) {
      if (movie.id == id) {
        return movie;
      }
    }
    throw const CacheException(message: 'Movie not found');
  }
}
