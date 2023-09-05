import 'dart:convert';

import 'package:http/http.dart' as http;

import '../../../../../core/constants/constants.dart';
import '../../../../../core/error/exceptions.dart';
import '../../models/movie_model.dart';
import 'remote_datasource.dart';

class RemoteDataSourceImpl extends RemoteDataSource {
  late final http.Client client;

  @override
  Future<List<MovieModel>> filterMovies(String query) async {
    try {
      final response = await client
          .get(Uri.parse('$apiBaseUrl/articles?searchParams=$query'));

      if (response.statusCode == 200) {
        try {
          final decoded = jsonDecode(response.body)['data'];

          final movies =
              decoded.map<MovieModel>((e) => MovieModel.fromJson(e)).toList();

          return movies;
        } catch (e) {
          throw const ServerException(message: 'Error parsing data');
        }
      } else {
        throw const ServerException(message: 'Error fetching data');
      }
    } catch (e) {
      throw const ServerException(message: 'Error fetching data');
    }
  }

  @override
  Future<MovieModel> getMovie(String id) async {
    try {
      final response = await client.get(Uri.parse('$apiBaseUrl/article/$id'));

      if (response.statusCode == 200) {
        try {
          final decoded = jsonDecode(response.body)['data'];

          final MovieModel movie = MovieModel.fromJson(decoded);

          return movie;
        } catch (e) {
          throw const ServerException(message: 'Error parsing data');
        }
      } else {
        throw const ServerException(message: 'Error fetching data');
      }
    } catch (e) {
      throw const ServerException(message: 'Error fetching data');
    }
  }

  @override
  Future<List<MovieModel>> getMovies() async {
    try {
      final response = await client.get(Uri.parse('$apiBaseUrl/articles'));

      if (response.statusCode == 200) {
        try {
          final decoded = jsonDecode(response.body)['data'];

          final movies =
              decoded.map<MovieModel>((e) => MovieModel.fromJson(e)).toList();

          return movies;
        } catch (e) {
          throw const ServerException(message: 'Error parsing data');
        }
      } else {
        throw const ServerException(message: 'Error fetching data');
      }
    } catch (e) {
      throw const ServerException(message: 'Error fetching data');
    }
  }
}
