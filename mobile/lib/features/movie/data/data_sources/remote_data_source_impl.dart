import 'dart:convert';

import 'package:http/http.dart' as http;
import '../../../../core/constants/constants.dart';
import '../../../../core/error/exception.dart';

import 'remote_data_source.dart';
import '../models/movie_model.dart';

class MovieRemoteDataSourceImpl implements MovieRemoteDataSource {
  final http.Client client;
  MovieRemoteDataSourceImpl({
    required this.client,
  });
  @override
  Future<List<MovieModel>> getAllMovies() async {
    try {
      final response = await client.get(
        Uri.parse('${ApiEndPoints.apiBaseUrl}article'),
        headers: {
          'Content-Type': 'application/json',
        },
      );
      if (response.statusCode == 200) {
        try {
          final movies = json.decode(response.body)['data'] as List;
          return movies.map((e) => MovieModel.fromJson(e)).toList();
        } on FormatException {
          throw const InvalidResponseFormatException(
              message: "Invalid JSON format");
        }
      } else {
        throw const ServerException(message: "Couldn't get movies");
      }
    } catch (e) {
      throw const ServerException(message: "Server Error");
    }
  }

  @override
  Future<MovieModel> getMovie(String movieId) async {
    try {
      final response = await client.get(
        Uri.parse('${ApiEndPoints.apiBaseUrl}article/$movieId'),
        headers: {
          'Content-Type': 'application/json',
        },
      );
      if (response.statusCode == 200) {
        try {
          final movie = json.decode(response.body)['data'];
          return Future.value(MovieModel.fromJson(movie));
        } on FormatException {
          throw const InvalidResponseFormatException(
              message: "Invalid JSON format");
        }
      } else {
        throw const ServerException(message: "Unable to get movie");
      }
    } catch (e) {
      throw const ServerException(message: "Server Error");
    }
  }

  @override
  Future<List<MovieModel>> searchMovies(String queryParams) async {
    try {
      final response = await client.get(
        Uri.parse(
            '${ApiEndPoints.apiBaseUrl}article?searchParams=$queryParams'),
        headers: {
          'Content-Type': 'application/json',
        },
      );
      if (response.statusCode == 200) {
        try {
          final movies = json.decode(response.body)['data'] as List;
          return Future.value(
              movies.map((e) => MovieModel.fromJson(e)).toList());
        } on FormatException {
          throw const InvalidResponseFormatException(
              message: "Invalid JSON format");
        }
      } else {
        throw const ServerException(message: "Unable to get movie");
      }
    } catch (e) {
      throw const ServerException(message: "Server Error");
    }
  }
}
