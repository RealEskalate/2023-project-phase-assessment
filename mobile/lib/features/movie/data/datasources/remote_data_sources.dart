import 'dart:convert';

import 'package:http/http.dart' as http;
import 'package:mobile/core/error/exceptions.dart';
import 'package:mobile/core/utils/typedef.dart';
import 'package:mobile/features/movie/data/model/movie_model.dart';

abstract class MovieRemoteDataSource {
  Future<List<MovieModel>> getMovies();
}

const kCreateUserEndpoint = '/test-api/users';
const kGetUserEndpoint = '/test-api/users';

class MovieRemotDataSourceImp implements MovieRemoteDataSource {
  const MovieRemotDataSourceImp(this._client);

  final http.Client _client;

  @override
  Future<List<MovieModel>> getMovies() async {
    try {
      final response = await _client.get(
        Uri.parse(
            'https://film-db.onrender.com/api/v1/article?searchParams=Quest'),
        headers: {"Content-Type": 'application/json'},
      );

      if (response.statusCode != 200) {
        throw ServerException(
          message: response.body,
          statusCode: response.statusCode,
        );
      }

      return List<DataMap>.from(jsonDecode(response.body) as List)
          .map((userData) => MovieModel.fromMap(userData))
          .toList();
    } on ServerException {
      rethrow;
    } catch (e) {
      throw ServerException(
        message: e.toString(),
        statusCode: 505,
      );
    }
  }
}
