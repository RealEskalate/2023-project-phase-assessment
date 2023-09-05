import 'package:http/http.dart' as http;
import 'dart:convert';

import 'package:mobile/features/get_all_movie/data/models/movie_model.dart';

class SearchRemoteDataSource {
  Future<List<MovieModel>> searchMoviesData(String searchTerm) async {
    final response = await http.get(Uri.parse(
        'https://film-db.onrender.com/api/v1/article?searchParams=$searchTerm'));

    if (response.statusCode == 200) {
      final List<dynamic> movieDataList = json.decode(response.body)['data'];
      return movieDataList
          .map((movieData) => MovieModel.fromJson(movieData))
          .toList();
    } else {
      throw Exception('Failed to search movies');
    }
  }
}
