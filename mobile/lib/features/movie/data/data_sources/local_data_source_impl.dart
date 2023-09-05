import 'dart:convert';

import 'package:shared_preferences/shared_preferences.dart';

import '../../../../core/error/exception.dart';
import '../models/movie_model.dart';
import 'local_data_source.dart';

const CACHED_MOVIES = 'cached_movies';
const CACHED_MOVIE = 'cached_movie';

const BOOKMARKED_MOVIES = 'bookmarked_movies';

class MovieLocalDataSourceImpl implements MovieLocalDataSource {
  final SharedPreferences sharedPreferences;

  MovieLocalDataSourceImpl({required this.sharedPreferences});

  @override
  Future<List<MovieModel>> getAllMovies() {
    final jsonString = sharedPreferences.getString(CACHED_MOVIES);
    if (jsonString != null) {
      final List<MovieModel> movies = [];
      for (var item in json.decode(jsonString)) {
        movies.add(MovieModel.fromJson(item));
      }
      return Future.value(movies);
    } else {
      throw const CacheException();
    }
  }

  @override
  Future<MovieModel> getMovie(String movieId) {
    final jsonString = sharedPreferences.getString(CACHED_MOVIE);
    if (jsonString != null) {
      final List<MovieModel> movies = [];
      for (var item in json.decode(jsonString)) {
        movies.add(MovieModel.fromJson(item));
      }
      return Future.value(
          movies.firstWhere((element) => element.id == movieId));
    } else {
      throw const CacheException();
    }
  }

  @override
  Future<void> cacheMovies(List<MovieModel> moviesToCache) {
    return sharedPreferences.setStringList(
      CACHED_MOVIES,

      // convert the list of movies to json string
      moviesToCache.map((e) => json.encode(e.toJson())).toList(),
    );
  }

  @override
  Future<void> cacheMovie(MovieModel movieToCache) {
    return sharedPreferences.setString(
      CACHED_MOVIE,
      json.encode(
        movieToCache.toJson(),
      ),
    );
  }

  @override
  Future<void> bookmarkMovie(MovieModel movie) {
    // get all bookmarked movies from shared preferences and add the new movie to the list
    // then save the list back to shared preferences

    final jsonString = sharedPreferences.getStringList(BOOKMARKED_MOVIES);

    if (jsonString != null) {
      final List<MovieModel> movies = [];
      for (var item in jsonString) {
        movies.add(MovieModel.fromJson(json.decode(item)));
      }
      movies.add(movie);
      return sharedPreferences.setStringList(
        BOOKMARKED_MOVIES,
        movies.map((e) => json.encode(e.toJson())).toList(),
      );
    } else {
      return sharedPreferences.setStringList(
        BOOKMARKED_MOVIES,
        [json.encode(movie.toJson())],
      );
    }
  }

  @override
  Future<List<MovieModel>> getBookmarkedMovies() {
    final jsonString = sharedPreferences.getStringList(BOOKMARKED_MOVIES);

    if (jsonString != null) {
      final List<MovieModel> movies = [];
      for (var item in jsonString) {
        movies.add(MovieModel.fromJson(json.decode(item)));
      }
      return Future.value(movies);
    } else {
      throw const CacheException();
    }
  }

  @override
  Future<void> removeMovieFromBookmark(MovieModel movie) {
    final jsonString = sharedPreferences.getStringList(BOOKMARKED_MOVIES);

    if (jsonString != null) {
      final List<MovieModel> movies = [];
      for (var item in jsonString) {
        movies.add(MovieModel.fromJson(json.decode(item)));
      }
      movies.removeWhere((element) => element.id == movie.id);
      return sharedPreferences.setStringList(
        BOOKMARKED_MOVIES,
        movies.map((e) => json.encode(e.toJson())).toList(),
      );
    } else {
      throw const CacheException();
    }
  }
}
