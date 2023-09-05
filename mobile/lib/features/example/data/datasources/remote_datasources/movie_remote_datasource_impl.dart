import 'dart:convert';

import 'package:dartz/dartz.dart';
import 'package:mobile/features/example/data/datasources/remote_datasources/movie_remote_datasource.dart';
import 'package:http/http.dart' as http;
import 'package:mobile/features/example/data/models/get_movies_dto.dart';
import 'package:mobile/core/exceptions/Failure.dart';
import 'package:mobile/features/example/domain/entities/movie.dart';
class MovieRemoteDataSourceImpl extends MovieRemoteDataSource{
  
  final http.Client client;
  String baseurl;
   MovieRemoteDataSourceImpl({required this.client,
   this.baseurl ='https://film-db.onrender.com/api/v1/article',
   });


  @override
  Future<Either <Failure , List<Movie>>> seachMovies(String query) async {
    try {
      String urlString = baseurl + '?searchParams=' + query;
     
      var url = Uri.parse(urlString);
      var response = await client.get(url,);
      if (response.statusCode == 200) {
        var data = jsonDecode(response.body);

        var getMoviesDto = GetMoviesDto.fromJson(data);
        var movieslist = getMoviesDto.data;
        var movies = movieslist!.map((e) => e.toMovie() ).toList();
        
        return Right(movies);
      } else {
        return const Left(ServerFailure(message: 'Server Failure'));
      }
    } catch (e) {
      return Left(NetworkFailure(message: e.toString()));
    }
  }
  

@override
  Future<Either <Failure , List<Movie>>> getMovies() async {
    try {
      String urlString = baseurl;
     
      var url = Uri.parse(urlString);
      var response = await client.get(url,);
      if (response.statusCode == 200) {
        var data = jsonDecode(response.body);

        var getMoviesDto = GetMoviesDto.fromJson(data);
        var movieslist = getMoviesDto.data;
        var movies = movieslist!.map((e) => e.toMovie() ).toList();
        
        return Right(movies);
      } else {
        return const Left(ServerFailure(message: 'Server Failure'));
      }
    } catch (e) {
      return Left(NetworkFailure(message: e.toString(),));
    }
  }
  



  }
  