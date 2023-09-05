import 'dart:convert';

import 'package:shared_preferences/shared_preferences.dart';

import '../../../../../core/constants/constants.dart';
import '../../../../../core/error/exception.dart';
import '../../models/movie_model.dart';
import 'movie_local_datasource.dart';

class MovieLocalDataSourceImpl extends MovieLocalDataSource {
  final SharedPreferences sharedPreferences;

  MovieLocalDataSourceImpl({required this.sharedPreferences});

  @override
  Future<void> cacheMovie(MovieModel movie) async {
    final movies = await getMovies();

    final movieIndex = movies.indexWhere((element) => element.id == movie.id);

    // If movie is not in the list, add it
    if (movieIndex == -1) {
      movies.add(movie);
    }

    // If movie is in the list, replace it
    else {
      movies[movieIndex] = movie;
    }

    await cacheMovies(movies);
  }

  @override
  Future<void> cacheMovies(List<MovieModel> movies) async {
    final jsonEncoded = jsonEncode(movies);

    await sharedPreferences.setString(
        AppConstants.movieCacheSharedPreferenceKey, jsonEncoded);
  }

  @override
  Future<MovieModel> getMovie(String id) async {
    final movies = await getMovies();

    for (final movie in movies) {
      if (movie.id == id) {
        return movie;
      }
    }

    throw const CacheException();
  }

  @override
  Future<List<MovieModel>> getMovies() async {
    final jsonEncoded =
        sharedPreferences.getString(AppConstants.movieCacheSharedPreferenceKey);

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
  Future<List<MovieModel>> searchMovies(String query) async {
    final movies = await getMovies();

    return movies
        .where((MovieModel movie) =>
            movie.title.toLowerCase().startsWith(query.toLowerCase()))
        .toList();
  }
}
