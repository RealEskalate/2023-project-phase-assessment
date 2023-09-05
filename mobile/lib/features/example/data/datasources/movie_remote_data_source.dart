import 'dart:convert';

import 'package:mobile/core/errors/exception.dart';
import 'package:mobile/features/example/data/models/movie_model.dart';
import 'package:mobile/features/example/domain/entities/movie.dart';
import 'package:http/http.dart' as http;

abstract class MovieRemoteDataSource {
  Future<List<Movie>> getMovie();
  Future<List<Movie>> getMovieBySearch(String searchParams);
  Future<Movie> getMovieById(String id);
}

class MovieRemoteDataSourceImpl implements MovieRemoteDataSource {
  final http.Client client;
  final String url = 'https://film-db.onrender.com/api/v1/article';

  MovieRemoteDataSourceImpl({required this.client});

  @override
  Future<List<Movie>> getMovie() async {
    final result = await client.get(Uri.parse(url));

    if (result.statusCode == 200) {
      final jsonResponse = jsonDecode(result.body)["data"];
      final List<MovieModel> movies =
          jsonResponse.map<MovieModel>((e) => MovieModel.fromJson(e)).toList();
      return movies;
    } else {
      throw ServerException(
          statusCode: 400, message: "Could not connect to the internet");
    }
  }

  @override
  Future<Movie> getMovieById(String id) async {
    final movieUrl = "$url/$id";
    final result = await client.get(Uri.parse(movieUrl));
    if (result.statusCode == 200) {
      final jsonResponse = jsonDecode(result.body)["data"];
      final MovieModel movie = MovieModel.fromJson(jsonResponse);
      return movie;
    } else {
      throw ServerException(
          statusCode: 400, message: "Could not connect to the internet");
    }
  }

  @override
  Future<List<Movie>> getMovieBySearch(String searchParams) async {
    final moviesUrl = "$url?searchParams=$searchParams";
    final result = await client.get(Uri.parse(moviesUrl));
    if (result.statusCode == 200) {
      final jsonResponse = jsonDecode(result.body)["data"];
      final List<MovieModel> movies =
          jsonResponse.map<MovieModel>((e) => MovieModel.fromJson(e)).toList();
      return movies;
    } else {
      throw ServerException(
          statusCode: 400, message: "Could not connect to the internet");
    }
  }
}
