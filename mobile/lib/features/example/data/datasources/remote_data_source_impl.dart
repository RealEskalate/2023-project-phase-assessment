import 'dart:convert';
import 'dart:io';
import 'package:dartz/dartz.dart';
import 'package:http/http.dart' as http;
import 'package:mobile/core/Errors/Failure.dart';
import 'package:mobile/features/example/data/datasources/remote_data_source.dart';
import 'package:mobile/features/example/domain/entities/movie.dart';
import 'package:shared_preferences/shared_preferences.dart';

class RemoteDataSourceImpl extends RemoteDataSource {
  final http.Client client;
  static const String key = 'stored_movies';

  RemoteDataSourceImpl(this.client);

  @override
  Future<Either<Failure, List<Movie>>> getMovies() async {
    final url = 'https://film-db.onrender.com/api/v1/article';

    try {
      final response = await client.get(Uri.parse(url));

      if (response.statusCode == 200) {
        final jsonData = jsonDecode(response.body);
        List<Movie> movies = [];
        for (var item in jsonData["data"]) {
          movies.add(Movie.fromJson(item));
        }
        print("Working");
        return Right(movies);
      } else {
        print("EEE");
        return Left(Failure(message: 'something goes wrong!'));
      }
    } catch (error) {
      print(" EEEE ");
      print(error.toString());

      return Left(Failure(message: error.toString()));
    }
  }

  @override
  Future<Either<Failure, List<Movie>>> searchMovies(String s) async {
    final url = 'https://film-db.onrender.com/api/v1/article?searchParams=' + s;
    print("searching------");
    try {
      final response = await client.get(Uri.parse(url));

      if (response.statusCode == 200) {
        final jsonData = jsonDecode(response.body);
        List<Movie> movies = [];
        for (var item in jsonData["data"]) {
          movies.add(Movie.fromJson(item));
        }
        print("hhhhhhhhhhhhhhhhhhh");
        return Right(movies);
      } else {
        print("EEE");
        return Left(Failure(message: 'something goes wrong!'));
      }
    } catch (error) {
      print(" EEEE ");
      print(error.toString());

      return Left(Failure(message: error.toString()));
    }
  }

  @override
  Future<Either<Failure, List<Movie>>> getBookMarks() async {
    SharedPreferences prefs = await SharedPreferences.getInstance();
    List<String>? movieJsonList = prefs.getStringList(key);
    if (movieJsonList != null) {
      List<Movie> movies = movieJsonList.map((movieJson) {
        Map<String, dynamic> movieMap = jsonDecode(movieJson);
        return Movie.fromJson(movieMap);
      }).toList();
      return Right(movies);
    }
    return Right([]);
  }

  @override
  Future<Either<Failure, void>> setBookMark(Movie movie) async {
    try {
      SharedPreferences prefs = await SharedPreferences.getInstance();
      Set<String> storedMovies = prefs.getStringList(key)?.toSet() ?? {};
      storedMovies.add(jsonEncode(movie.toJson()));
      await prefs.setStringList(key, storedMovies.toList());
      return Right(unit);
      ;
    } catch (e) {
      return Left(Failure(message: e.toString()));
    }
  }
}
