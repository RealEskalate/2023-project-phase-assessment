import 'dart:convert';

import '../../models/movie_model.dart';
import '../remote/remore_datasource.dart';
import '../../../../../core/errors/failures/exception.dart';
import 'package:http/http.dart' as http;

class RemoteDatasourceImpl extends RemoteDatasource {
  final http.Client client;
  RemoteDatasourceImpl({required this.client});

  @override
  Future<MovieModel> getMovie(String id) async {
    try {
      final response = await client
          .get(Uri.parse("https://film-db.onrender.com/api/v1/article/$id"));

      final data = jsonDecode(response.body)['data'];
      final movie = MovieModel.fromJson(data);
      return movie;
    } catch(e) {
      throw ServerException();
    }
  }
}
