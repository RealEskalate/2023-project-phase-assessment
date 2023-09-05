import 'dart:convert';

import 'package:mobile/features/example/data/models/movie_model.dart';
import 'package:mobile/features/example/domain/entities/MovieEntity.dart';
import 'package:shared_preferences/shared_preferences.dart';

import '../../../../core/errors/exception.dart';

const CACHED_MOVIE = 'CACHED_MOVIE';
const CACHED_ALL_MOVIE = 'CACHED_ALL_MOVIE';
const BOOKED_MOVIE = 'BOOKED_MOVIE';

abstract class MovieLocalDataSource {
  Future<MovieEntity> getSingleMovie(String id);
  Future<List<MovieModel>> getAllMovies();
  Future<void> cachMovie(MovieModel movie);
  Future<void> cacheMovies(List<MovieModel> movies);
  Future<void> addToBookmark(MovieModel movie);
  Future<List<MovieModel>> getBookmarkedArticles();
  Future<MovieModel> removeFromBookmark(String Id);

}

class MovieLocalDataSourceImpl extends MovieLocalDataSource {
  final SharedPreferences sharedPreferences;

  MovieLocalDataSourceImpl({required this.sharedPreferences});

  @override
  Future<void> cacheMovies(List<MovieModel> movies) async {
    final my_movies = jsonEncode(movies);

    await sharedPreferences.setString(CACHED_ALL_MOVIE, my_movies);
  }

  @override
  Future<void> cachMovie(MovieModel movie) async {
    final movies = await getAllMovies();

    final articleIndex = movies.indexWhere((element) => element.id == movie.id);

    if (articleIndex == -1) {
      movies.add(movie);
    } else {
      movies[articleIndex] = movie;
    }

    await cacheMovies(movies);
  }

  @override
  Future<List<MovieModel>> getAllMovies() async {
    final all_movies = sharedPreferences.getString(CACHED_ALL_MOVIE);

    if (all_movies != null) {
      final List<dynamic> jsonDecoded = jsonDecode(all_movies);
      final articles = jsonDecoded
          .map<MovieModel>((map) => MovieModel.fromJson(map))
          .toList();

      return articles;
    }

    return <MovieModel>[];
  }

  @override
  Future<MovieModel> getSingleMovie(String id) async {
    final movies = await getAllMovies();

    for (final movie in movies) {
      if (movie.id == id) {
        return movie;
      }
    }

    throw CacheException();
  }

   Future<void> _cacheBookmarks(List<MovieModel> articles) async {
    final jsonEncoded = jsonEncode(articles);
    await sharedPreferences.setString(BOOKED_MOVIE, jsonEncoded);
  }  

  @override
  Future<void> addToBookmark(MovieModel movieModel) async {
    final movies = await getBookmarkedArticles();

    final movieIndex =
        movies.indexWhere((element) => element.id == movieModel.id);

    // If article is not in the list, add it
    if (movieIndex == -1) {
      movies.add(movieModel);
    }

    // If article is in the list, replace it
    else {
      movies[movieIndex] = movieModel;
    }

    await _cacheBookmarks(movies);
  }

  @override
  Future<List<MovieModel>> getBookmarkedArticles() async {
    final jsonEncoded = sharedPreferences.getString(BOOKED_MOVIE);

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
  Future<MovieModel> removeFromBookmark(String Id) async {
    final articles = await getBookmarkedArticles();

    final filteredMovies =
        articles.where((movie) => movie.id != Id);

    await _cacheBookmarks(filteredMovies.toList());

    return articles.firstWhere((article) => article.id == Id);
  }
}

