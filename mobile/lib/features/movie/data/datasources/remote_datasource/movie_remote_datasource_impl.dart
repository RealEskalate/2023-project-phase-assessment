import 'dart:convert';

import 'package:http/http.dart' as http;

import '../../../../../core/constants/constants.dart';
import '../../../../../core/error/exception.dart';
import '../../models/movie_model.dart';
import 'movie_remote_datasource.dart';

class MovieRemoteDataSourceImpl extends MovieRemoteDataSource {
  final http.Client client;
  final apiBaseUrl = AppConstants.apiBaseUrl;

  MovieRemoteDataSourceImpl({required this.client});

  @override
  Future<MovieModel> getMovie(String id) async {
    http.Response response;

    try {
      response = await client.get(Uri.parse('$apiBaseUrl/$id'));
    } catch (e) {
      throw const NetworkException();
    }

    if (response.statusCode == 200) {
      try {
        final decoded = jsonDecode(response.body)['data'];

        final movieModel = MovieModel.fromJson(decoded);

        return movieModel;
      } on FormatException {
        throw const ServerException();
      }
    } else {
      throw const ServerException();
    }
  }

  @override
  Future<List<MovieModel>> getMovies() async {
    http.Response response;

    try {
      response = await client.get(Uri.parse(apiBaseUrl));
    } catch (e) {
      throw const NetworkException();
    }

    if (response.statusCode == 200) {
      try {
        final decoded = jsonDecode(response.body)['data'];

        final movieModel =
            decoded.map<MovieModel>((e) => MovieModel.fromJson(e)).toList();

        return movieModel;
      } on FormatException {
        throw const ServerException();
      }
    } else {
      throw const ServerException();
    }
  }

  @override
  Future<List<MovieModel>> searchMovies(String query) async {
    http.Response response;

    try {
      response = await client.get(Uri.parse(apiBaseUrl)
          .replace(queryParameters: {'searchParams': query}));
    } catch (e) {
      throw const NetworkException();
    }

    if (response.statusCode == 200) {
      try {
        final decoded = jsonDecode(response.body)['data'];

        final movieModel =
            decoded.map<MovieModel>((e) => MovieModel.fromJson(e)).toList();

        return movieModel;
      } on FormatException {
        throw const ServerException();
      }
    } else {
      throw const ServerException();
    }
  }
}
