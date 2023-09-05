import 'dart:convert';

import 'package:mobile/core/errors/exception.dart';
import 'package:mobile/features/example/data/models/movie_model.dart';
import 'package:http/http.dart' as http;

abstract class MovieRemoteDataSource {
  Future<List<MovieModel>> getAllMovies();
  Future<MovieModel> getSingleMovie(String id);
  Future<List<MovieModel>> filteredMovies(String title);
}

class MovieRemoteDataSourceImpl extends MovieRemoteDataSource {
  final http.Client client;
  MovieRemoteDataSourceImpl({required this.client});

  @override
  Future<List<MovieModel>> getAllMovies() async {
    final response = await client.get(
      Uri.parse("https://film-db.onrender.com/api/v1/article"),
      headers: {"Content-Type": "application/json"},
    );

    if (response.statusCode == 200) {
      final tasks = json.decode(response.body)["data"] as List;
      return tasks.map((movie) => MovieModel.fromJson(movie)).toList();
    } else {
      throw ServerException();
    }
  }

  @override
  Future<List<MovieModel>> filteredMovies(String title) async {
    try {
      final response = await client.get(
        Uri.parse('https://film-db.onrender.com/api/v1/article/'),
        headers: {
          'Content-Type': 'Application/json'
        },
      );

      if (response.statusCode == 200) {
        try {
          final decoded = jsonDecode(response.body)['data'];

          final articleModel =
              decoded.map<MovieModel>((e) => MovieModel.fromJson(e)).toList();

          return articleModel;
        } on FormatException {
          throw ServerException();
        }
      } else {
        throw ServerException();
      }
    } catch (e) {
      throw ServerException();
    }
  }

  @override
  Future<MovieModel> getSingleMovie(String id) async {
    final response = await client.get(
      Uri.parse(
          "ttps://film-db.onrender.com/api/v1/article/64f61804c4ee2805e925b7cd$id"),
      headers: {"Content-Type": "application/json"},
    );

    if (response.statusCode == 200) {
      return MovieModel.fromJson(json.decode(response.body));
    } else {
      throw ServerException();
    }
  }
}
