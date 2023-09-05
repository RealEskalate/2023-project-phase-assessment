import 'dart:convert';
import 'dart:developer';
import 'dart:io';
import 'package:dartz/dartz.dart';
import 'package:http/http.dart' as http;
import 'package:http_parser/http_parser.dart';
import 'package:mobile/features/example/data/datasources/data_source_api.dart';
import 'package:mobile/features/example/data/models/film_models.dart';
import 'package:shared_preferences/shared_preferences.dart'; // Import SharedPreferences package

class UserApiDataSource implements RemoteDataSource {
  final String baseUrl;

  UserApiDataSource({required this.baseUrl});

  Future<List<Movie>> fetchMovies() async {
    final response = await http
        .get(Uri.parse("https://film-db.onrender.com/api/v1/article"));
    if (response.statusCode == 200) {
      final List<dynamic> data = json.decode(response.body)['data'];
      return data.map((json) => Movie.fromJson(json)).toList();
    } else {
      throw Exception('Failed to load movies');
    }
  }
}
