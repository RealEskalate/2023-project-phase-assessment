import 'dart:convert';

import 'package:second/core/error/exception.dart';
import 'package:second/core/network/network_info.dart';
import 'package:second/feature/main_page/data/model/movie_model.dart';
import 'package:http/http.dart' as http;

abstract class MovieRemoteDataSource {
  NetworkInfo get networkInfo;
  Future<MovieModel> getSingleMovieRemote({required String id});
  Future<List<MovieModel>> getAllMovieRemote();
  Future<List<MovieModel>> getSearchedMovieRemote({required String movieName});
}

class MovieRemoteDataSourceImpl implements MovieRemoteDataSource {
  @override
  final NetworkInfo networkInfo;

  MovieRemoteDataSourceImpl({required this.networkInfo});

  @override
  Future<List<MovieModel>> getAllMovieRemote() async {
    if (await networkInfo.isConnected) {
      // there some thing should be fix
      var url = Uri.parse(
          'https://film-db.onrender.com/api/v1/article?searchParams=Quest');
      var response =
          await http.post(url, headers: {"content": "application/json"});

      if (response.statusCode == 200) {
        List<dynamic> movieList = jsonDecode(response.body)["data"];
        List<MovieModel> result =
            movieList.map((movie) => MovieModel.fromJson(movie)).toList();
        return result;
      } else {
        throw ServerException(
            statusCode: response.statusCode,
            message: "the server does not work for know");
      }
    } else {
      throw NetworkConnectionException();
    }
  }

  @override
  Future<List<MovieModel>> getSearchedMovieRemote(
      {required String movieName}) async {
    if (await networkInfo.isConnected) {
      // there some thing should be fix
      var url = Uri.parse(
          'https://film-db.onrender.com/api/v1/article?searchParams=Quest');
      var response =
          await http.post(url, headers: {"content": "application/json"});

      if (response.statusCode == 200) {
        List<dynamic> movieList = jsonDecode(response.body)["data"];
        List<MovieModel> result =
            movieList.map((movie) => MovieModel.fromJson(movie)).toList();
        return result;
      } else {
        throw ServerException(
            statusCode: response.statusCode,
            message: "the server does not work for know");
      }
    } else {
      throw NetworkConnectionException();
    }
  }

  @override
  Future<MovieModel> getSingleMovieRemote({required String id}) async {
    if (await networkInfo.isConnected) {
      // there some thing should be fix
      var url = Uri.parse(
          'https://film-db.onrender.com/api/v1/article?searchParams=Quest');
      var response =
          await http.post(url, headers: {"content": "application/json"});

      if (response.statusCode == 200) {
        var movie = jsonDecode(response.body)["data"];
        MovieModel result = MovieModel.fromJson(movie);
        return result;
      } else {
        throw ServerException(
            statusCode: response.statusCode,
            message: "the server does not work for know");
      }
    } else {
      throw NetworkConnectionException();
    }
  }
}
