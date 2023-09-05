import 'dart:convert';

import 'package:mobile/core/network/custom_client.dart';
import 'package:mobile/features/example/data/datasources/remote/movie_remote_datasource.dart';
import 'package:mobile/features/example/data/models/movie_model.dart';

import '../../../../../core/error/exception.dart';

class RemoteDatasourceImpl implements RemoteDatasource {
  final CustomClient client;

  RemoteDatasourceImpl({required this.client});
  
  @override
  Future<List<MovieModel>> filterMovies(String searchParams) async {
    try {
      final response = await client.get('article/',
          queryParams: {'searchParams': searchParams});

      if (response.statusCode == 200) {
        try {
          final decoded = jsonDecode(response.body)['data'];

          final movies = decoded
              .map<MovieModel>((e) => MovieModel.fromJson(e))
              .toList();

          return movies;
        } on FormatException {
          throw const ServerException(message: 'Invalid Response');
        }
      } else {
        throw const ServerException(message: 'Operation Failed');
      }
    } catch (e) {
      throw const ServerException(message: 'Connection Failed');
    }
  }
  
  @override
  Future<List<MovieModel>> getAllMovies() async {
    try {
      final response = await client.get('article/');

      if (response.statusCode == 200) {
        try {
          final decoded = jsonDecode(response.body)['data'];

          final movies = decoded
              .map<MovieModel>((e) => MovieModel.fromJson(e))
              .toList();

          return movies;
        } on FormatException {
          throw const ServerException(message: 'Invalid Response');
        }
      } else {
        throw const ServerException(message: 'Operation Failed');
      }
    } catch (e) {
      throw const ServerException(message: 'Connection Failed');
    }
  }
  
  @override
  Future<MovieModel> getMovie(String id) async {
    try {
      final response = await client.get('article/$id');

      if (response.statusCode == 200) {
        try {
          final decoded = jsonDecode(response.body)['data'];

          final movieModel = MovieModel.fromJson(decoded);

          return movieModel;
        } on FormatException {
          throw const ServerException(message: 'Invalid Response');
        }
      } else {
        throw const ServerException(message: 'Operation Failed');
      }
    } catch (e) {
      throw const ServerException(message: 'Connection Failed');
    }
  }

}
