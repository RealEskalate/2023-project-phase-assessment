import 'dart:convert';
import 'dart:developer';
import 'dart:io';
import 'package:dartz/dartz.dart';
import 'package:shared_preferences/shared_preferences.dart';
import '../../../../core/error/failure.dart';
import '../models/movie.dart';
import 'datasource_api.dart';

class MovieLocalDataSourceImp implements MoviesLocalDataSource {
  static const String _bookmarkKey = 'bookmarked_movies';
  final SharedPreferences sharedPreferences;

  MovieLocalDataSourceImp({required this.sharedPreferences});

  @override
  Future<Either<Failure, bool>> addBookmark(
    Map<String, dynamic> movieData,
  ) async {
    try {
      // Get the existing list of bookmarked Movies from SharedPreferences
      final List<String>? bookmarkedMoviesJson =
          sharedPreferences.getStringList(_bookmarkKey);

      // Convert the existing JSON list to a List<Map<String, dynamic>>
      final List<Map<String, dynamic>> bookmarkedMovies = bookmarkedMoviesJson
              ?.map((e) => Map<String, dynamic>.from(json.decode(e)))
              .toList() ??
          [];

      // Add the new MovieData to the list
      bookmarkedMovies.add(movieData);

      // Log messages for debugging
      log("local_data+layer: BookMark Added $bookmarkedMovies");

      // Convert the updated list to JSON strings
      final List<String> updatedBookmarkedMoviesJson =
          bookmarkedMovies.map((e) => json.encode(e)).toList();

      // Save the updated list back to SharedPreferences
      await sharedPreferences.setStringList(
          _bookmarkKey, updatedBookmarkedMoviesJson);

      log("local_data+layer: BookMark Added $bookmarkedMovies");

      return const Right(true); // Successfully bookmarked
    } catch (e) {
      // Log the error
      log('local datasource Bookmark creating error: $e');
      throw Exception('local datasource Bookmark creating error: $e');
    }
  }

  Future<Either<Failure, bool>> clearBookmarks() async {
    try {
      // Remove the bookmarked movies from SharedPreferences
      await sharedPreferences.remove(_bookmarkKey);
      return Right(true); // Successfully cleared bookmarks
    } catch (e) {
      throw Exception('local datasource Bookmark clearing error: $e');
    }
  }

  @override
  Future<Either<Failure, List<MovieModel>>> getAllBookmarks() async {
    //clearBookmarks();
    try {
      // Get the list of bookmarked movies JSON from SharedPreferences
      final List<String>? bookmarkedMoviesJson =
          sharedPreferences.getStringList(_bookmarkKey);
      log("fetched: $bookmarkedMoviesJson");

      // If there are no bookmarks, return an empty list
      if (bookmarkedMoviesJson == null) {
        return Right([]);
      }

      // Parse each JSON string into a Map<String, dynamic>
      final List<dynamic> bookmarkedMovies = bookmarkedMoviesJson
          .map<Map<String, dynamic>>(
              (e) => json.decode(e) as Map<String, dynamic>)
          .toList();

      log("Convereted: $bookmarkedMovies");
      // Convert each Map<String, dynamic> into a Movie model
      // final List<Movie> bookmarkedMovieModels = bookmarkedMovies
      //     .map((movieData) => Movie.fromJson(
      //         movieData)) // Assuming you have a fromJson constructor for Movie
      //     .toList();
      //  return Right(bookmarkedMovieModels);

      List<MovieModel> movies = [];

      for (var movieData in bookmarkedMovies) {
        //      log(blogData.toString());
        movies.add(MovieModel.fromJson(movieData));
      }
      log("Bookmark Movies ------------------- : $movies");
      return Right(movies);
    } catch (e) {
      throw Exception('local datasource Bookmark fetching error: $e');
    }
  }

  @override
  Future<Either<Failure, List<MovieModel>>> getAllMovies() {
    // TODO: implement getAllMovies
    throw UnimplementedError();
  }

  @override
  Future<Either<Failure, MovieModel>> getSingleMovie(String movieId) {
    // TODO: implement getSingleMovie
    throw UnimplementedError();
  }

  @override
  Future<List<MovieModel>> searchMovie(String tag, String key) {
    // TODO: implement searchMovie
    throw UnimplementedError();
  }
}
