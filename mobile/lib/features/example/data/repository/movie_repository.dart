// features/data/movie_repository.dart

import 'dart:convert';
import 'package:http/http.dart' as http;
import 'package:mobile/features/example/domain/entities/movie_entity.dart';


class MovieRepository {
  final String baseUrl =
      'https://film-db.onrender.com/api/v1/article'; 

  Future<List> fetchMovies() async {
    final response = await http.get(Uri.parse('$baseUrl/movies'));
    if (response.statusCode == 200) {
      final List<dynamic> data = json.decode(response.body);
      return data.map((movieData) => MovieEntity.fromJson(movieData)).toList();
    } else {
      throw Exception('Failed to load movies');
    }
  }
}
