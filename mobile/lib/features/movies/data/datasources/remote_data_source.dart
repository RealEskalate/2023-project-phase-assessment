import 'dart:convert';
import 'dart:developer';

import 'package:dartz/dartz.dart';
import 'package:http/http.dart' as http;
import 'package:mobile/features/movies/data/datasources/api_datasource.dart';
import 'package:mobile/features/movies/domain/entities/movie.dart';
import 'package:shared_preferences/shared_preferences.dart';

class RemoteDataSource implements MovieRemoteDataSource {
  final String baseUrl;

  RemoteDataSource({required this.baseUrl});

  Future<dynamic> _fetchData(String endpoint, [String query = '']) async {
    log("fetching: $baseUrl/$endpoint");
    // SharedPreferences prefs = await SharedPreferences.getInstance();

    try {
      var response;
      response = await http.get(
        Uri.parse('$baseUrl/$endpoint'),
        headers: {
          'Content-Type': 'application/json',
        },
      );
      final responseData = json.decode(response.body);
      // log('response: $responseData');

      if (responseData['success'] == true) {
        // log("fetched: $responseData");
        return responseData['data'];
      } else {
        log("error: $responseData");
        final errorMessage =
            responseData['message'] as String? ?? 'Unknown error - here';
        throw Exception(errorMessage);
      }
    } catch (e) {
      log("error:: $e");
      throw Exception('An error occurred: $e');
    }
  }

  @override
  Future<List<Movie>> getAllMovies() async {
    final responseData = await _fetchData('article');

    List<Movie> movies = [];
    try {
      for (var movieData in responseData) {
        // log(movieData.toString());
        log("added movie");
        try {
          movies.add(Movie.fromJson(movieData));
        } catch (e) {
          log("unk err while adding: $e");
        }
        log("Check 2");
      }
      return movies;
    } catch (e) {
      log("Error fetching movies: $e");
      throw Exception('An error occurred: $e');
    }
    // TODO: implement getAllMovies
  }

  @override
  Future<Movie> getSingleMovie(String movieId) {
    // TODO: implement getSingleMovie
    throw UnimplementedError();
  }

  @override
  Future<List<Movie>> searchMovies(String query) {
    // TODO: implement searchMovi
    throw UnimplementedError();
  }
}
