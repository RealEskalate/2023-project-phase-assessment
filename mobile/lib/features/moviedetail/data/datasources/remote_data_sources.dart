import 'package:http/http.dart' as http;
import 'dart:convert';

class MovieProvider {
  Future<Map<String, dynamic>> getMovieDetailData(String movieId) async {
    final response = await http
        .get(Uri.parse('https://film-db.onrender.com/api/v1/article/$movieId'));

    if (response.statusCode == 200) {
      return json.decode(response.body);
    } else {
      throw Exception('Failed to fetch movie detail');
    }
  }
}
