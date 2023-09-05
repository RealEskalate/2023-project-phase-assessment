import 'dart:convert';

import 'package:dartz/dartz.dart';
import 'package:http/http.dart' as http;
import 'package:mobile/core/failure.dart';
import 'package:mobile/features/movies/data/models/get_movies_response_dto.dart';
import 'package:mobile/features/movies/domain/entities/movie.dart';
abstract class MovieApiDataSource {
  Future<Either<Failure, List<Movie>>> getMovies({searchParams = String,});
}
class MovieApiResource implements MovieApiDataSource {
  final http.Client client;
  final String baseUrl;
  MovieApiResource(
      {required this.client,
      this.baseUrl = "https://film-db.onrender.com/api/v1"});
  Future<Either<Failure, List<Movie>>> getMovies({searchParams = String,}) async {
    print(searchParams);
    var url ='$baseUrl/article';
 
    if(searchParams != String){
      url =  '$baseUrl/article?searchParams=$searchParams';
    }
    var response = await client.get(Uri.parse(url));
    if (response.statusCode == 200) {
      final movies = MoviesResponse.fromJson(json.decode(response.body));
      if (movies.data != null) {
        final movieDomain = movies.data!
            .map((mv) => Movie(
                  sId: mv.sId ?? "",
                  category: mv.category ?? "",
                  title: mv.title ?? "",
                  description: mv.description ?? "",
                  duration: mv.duration ?? "",
                  image: mv.image ?? "",
                  rating: mv.rating  != null? mv.rating! * 1.0  : 0.0,
                  createdAt: mv.createdAt ?? "",
                  iV: mv.iV ?? 0,
                  id: mv.id ?? "",
                ))
            .toList();
        return Right(movieDomain);
      }
      return const Right([]);
    } else {
      return const Left(ServerFailure(message: 'Server Failure'));
    }
    return Left(ServerFailure(message: "hello"));
  }
}
