import 'dart:convert';

import 'package:mobile/core/errors/failures/exception.dart';
import 'package:mobile/features/homepage/data/models/movie_model.dart';
import 'package:http/http.dart' as http;

import 'remote_datasource.dart';

class RemoteDatasourceImpl extends RemoteDatasource {
  final http.Client client;

  RemoteDatasourceImpl({required this.client});
  @override
  Future<List<MovieModel>> getAllMovies() async {
    final response = await client.get(
        Uri.parse(
            "https://film-db.onrender.com/api/v1/article"),
        headers: {'Content-Type': 'application/json'});
    if (response.statusCode == 200) {
      final decoded = jsonDecode(response.body)['data'];
      final movies =
          decoded.map<MovieModel>((m) => MovieModel.fromJson(m)).toList();
      return movies;
    } else {
      throw ServerException();
    }
  }

  @override
  Future<List<MovieModel>> searchMovies(String searchTerm) async {
    final response = await client.get(
        Uri.parse(
            "https://film-db.onrender.com/api/v1/article?searchParams=$searchTerm"),
        headers: {'Content-Type': 'application/json'});
    if (response.statusCode == 200) {
      final decoded = jsonDecode(response.body)['data'];
      final movies =
          decoded.map<MovieModel>((m) => MovieModel.fromJson(m)).toList();
      return movies;
    } else {
      throw ServerException();
    }
  }
}
