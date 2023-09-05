import 'dart:convert';

import 'package:http/http.dart' as http;
import 'package:mobile/features/movies/data/datasources/remote/movie_remote_data_source.dart';
import 'package:mobile/features/movies/data/models/movie_model.dart';

class MovieRemoteDataSourceImpl extends MovieRemoteDataSource {
  final http.Client client;
  final String apiBaseUrl;

  MovieRemoteDataSourceImpl(this.client, this.apiBaseUrl);

  @override
  Future<List<MovieModel>> getAllMovies() async {
    final response = await client.get(Uri.parse('$apiBaseUrl/api/v1/article'));

    if (response.statusCode == 200) {
      final List<dynamic> jsonList = json.decode(response.body);
      return jsonList.map((json) => MovieModel.fromJson(json)).toList();
    } else {
      throw Exception('Failed to load movies');
    }
  }

  @override
  Future<MovieModel> getMovie(String id) async {
    final response = await client.get(Uri.parse('$apiBaseUrl/api/v1/article/$id'));

    if (response.statusCode == 200) {
      final Map<String, dynamic> jsonData = json.decode(response.body);
      return MovieModel.fromJson(jsonData);
    } else {
      throw Exception('Failed to load movie');
    }
  }

  @override
  Future<List<MovieModel>> searchMovies(String title) async {
    final response = await client.get(Uri.parse('$apiBaseUrl/api/v1/article?searchParams=$title'));

    if (response.statusCode == 200) {
      final List<dynamic> jsonList = json.decode(response.body);
      return jsonList.map((json) => MovieModel.fromJson(json)).toList();
    } else {
      throw Exception('Failed to search articles');
    }
  }
}
