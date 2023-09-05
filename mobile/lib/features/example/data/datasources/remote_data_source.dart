import 'dart:convert';
import 'dart:developer';
import 'package:http/http.dart' as http;
import 'package:dartz/dartz.dart';
import 'package:mobile/core/error/failure.dart';
import 'package:mobile/features/example/data/datasources/datasource_api.dart';
import 'package:mobile/features/example/domain/entities/movie.dart';

class MovieRemoteDataSourceImp implements MovieRemoteDataSource {
  final String baseUrl;

  MovieRemoteDataSourceImp({required this.baseUrl});
  Future<dynamic> _fetchData(String endpoint) async {
    log("fetching: $baseUrl/$endpoint");
    try {
      final response = await http.get(
        Uri.parse('$baseUrl/$endpoint'),
        headers: {'Content-Type': 'application/json'},
      );

      final responseData = json.decode(response.body);

      if (response.statusCode == 200 && responseData['success'] == true) {
        return responseData['data'];
      } else {
        log("error: $responseData");
        final errorMessage =
            responseData['message'] as String? ?? 'Unknown error';
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
        //      log(blogData.toString());
        movies.add(Movie.fromJson(movieData));
      }
      return movies;
    } catch (e) {
      log("Error fetching movies: $e");
      throw Exception('An error occurred: $e');
    }
  }

  @override
  Future<Either<Failure, Movie>> getSingleMovie(String movieId) {
    // TODO: implement getSingleMovie
    throw UnimplementedError();
  }

  @override
  Future<List<Movie>> searchMovie(String key) {
    // TODO: implement searchMovie
    throw UnimplementedError();
  }
}
