
import 'dart:convert';

import 'package:dartz/dartz.dart';
import 'package:mobile/core/Error/failures.dart';
import 'package:mobile/features/example/data/models/movie_model.dart';
import 'package:http/http.dart' as http;


abstract class MovieRemoteDataSource {
  Future<Either<Faliure, List<MovieModel>>> getMovie();
  Future<Either<Faliure, List<MovieModel>>> searchMovie(String query);
}

class MovieRemoteDataSourceImpl implements MovieRemoteDataSource{
  @override
  Future<Either<Faliure, List<MovieModel>>> getMovie() async {
     try {
      final response = await http.get(Uri.parse('https://film-db.onrender.com/api/v1/article/64f61804c4ee2805e925b7cd'));

      if (response.statusCode == 200) {
        final decodedData = jsonDecode(response.body);
        final movieData = decodedData['data'];

        // Parse the movie data into a MovieModel object
        final List<MovieModel> movies = List<MovieModel>.from(
            movieData.map((data) => MovieModel.fromJson(data)));

        return Right(movies);
      }
      else{
        return Left(Faliure());
      } 
    } catch (e) {
      return Left(Faliure());
    }
  }

  @override
  Future<Either<Faliure, List<MovieModel>>> searchMovie(String query) async{
   try {
      final response = await http.get(Uri.parse('https://film-db.onrender.com/api/v1/article?searchParams=$query'));

      if (response.statusCode == 200) {
        final decodedData = jsonDecode(response.body);
        final movieListData = decodedData['data'];

        // Parse the movie list data into a list of MovieModel objects
        final List<MovieModel> movies = List<MovieModel>.from(movieListData.map((data) => MovieModel.fromJson(data)));

        return Right(movies);
      } else {
        return Left(Faliure());
      }
    } catch (e) {
      return Left(Faliure());
    }
  }
  


}