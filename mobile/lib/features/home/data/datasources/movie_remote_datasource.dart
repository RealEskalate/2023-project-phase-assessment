import 'dart:convert';

import 'package:mobile/features/home/domain/entities/movie.dart';
import "package:http/http.dart" as http;

import '../models/movie_model.dart';

abstract class MovieRemoteDataource {
  Future<List<Movie>> getMovies();
  Future<List<Movie>> searchMovies(String term);
}

class MovieRemoteDataourceImpl extends MovieRemoteDataource {
  @override
  Future<List<Movie>> getMovies() async {
    final response = await http
        .get(Uri.parse("https://film-db.onrender.com/api/v1/article"));
    if (response.statusCode == 200) {
      final data = jsonDecode(response.body)["data"];
      try {
        List<Movie> movies = [];
        for (final movie in data) {
          movies.add(MovieModel.fromJson(movie));
        }

        return movies;
      } catch (e) {
        print(e);
      }
    }
    throw ("Couldn't get movies");
  }

  @override
  Future<List<Movie>> searchMovies(String term) async {
    final response = await http.get(Uri.parse(
        "https://film-db.onrender.com/api/v1/article?searchParams=$term"));

    if (response.statusCode == 200) {
      final data = jsonDecode(response.body)["data"];
      try {
        List<Movie> movies = [];
        for (final movie in data) {
          movies.add(MovieModel.fromJson(movie));
        }

        return movies;
      } catch (e) {
        print(e);
      }
    }
    throw ("Couldn't search movies");
  }
}
