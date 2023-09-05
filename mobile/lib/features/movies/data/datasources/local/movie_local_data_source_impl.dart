import 'dart:convert';

import 'package:mobile/core/error/exception.dart';
import 'package:shared_preferences/shared_preferences.dart';

import 'package:mobile/features/movies/data/datasources/local/movie_local_data_source.dart';
import 'package:mobile/features/movies/data/models/movie_model.dart';

class MovieLocalDataSourceImpl extends MovieLocalDataSource {
  final savedKey = 'SAVED_MOVIES';
  final movieKey = 'MOVIES';

  final SharedPreferences sharedPreferences;

  MovieLocalDataSourceImpl(this.sharedPreferences);

  @override
  Future<void> addToSaved(MovieModel movie) async {
    final movies = await getSavedMovies();

    final movieIndex = movies.indexWhere((element) => element.id == movie.id);

    if (movieIndex == -1) {
      movies.add(movie);
    } else {
      movies[movieIndex] = movie;
    }

    await _cacheMovies(movies);
  }

 
  @override
  Future<MovieModel> getMovie(String id) async {
    final movies = await getMovies();

    for (final movie in movies) {
      if (movie.id == id) {
        return movie;
      }
    }

    throw const CacheException(message: 'error');
  }

  @override
  Future<List<MovieModel>> getSavedMovies() async {
    final jsonEncoded = sharedPreferences.getString(savedKey);

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
  Future<MovieModel> removeFromSaved(String movieId) async {
    final movies = await getSavedMovies();

    final filteredMovies = movies.where((movie) => movie.id != movieId);

    await _cacheMovies(filteredMovies.toList());

    return movies.firstWhere((movie) => movie.id == movieId);
  }

  Future<void> _cacheMovies(List<MovieModel> movies) async {
    final jsonEncoded = jsonEncode(movies);

    await sharedPreferences.setString(movieKey, jsonEncoded);
  }

  @override
  Future<void> cacheMovie(MovieModel movie) async {
    final movies = await getMovies();

    final movieIndex = movies.indexWhere((element) => element.id == movie.id);

    if (movieIndex == -1) {
      movies.add(movie);
    } else {
      movies[movieIndex] == movie;
    }

    await cacheMovies(movies);
  }

  @override
  Future<void> cacheMovies(List<MovieModel> movies) async {
    final jsonEncoded = jsonEncode(movies);

    await sharedPreferences.setString(movieKey, jsonEncoded);
  }

  @override
  Future<List<MovieModel>> getMovies() async {
    final jsonEncoded = sharedPreferences.getString(movieKey);

    if (jsonEncoded != null) {
      final List<dynamic> jsonDecoded = jsonDecode(jsonEncoded);
      final movies = jsonDecoded
          .map<MovieModel>((map) => MovieModel.fromJson(map))
          .toList();

      return movies;
    }

    return <MovieModel>[];
  }
}
