import 'dart:convert';

import 'package:mobile/features/example/data/datasources/remote_data_source/remote_data_source.dart';
import 'package:http/http.dart' as http;
import 'package:mobile/features/example/data/datasources/remote_data_source/urls.dart';
import 'package:mobile/features/example/data/models/movie_model.dart';

class RemoteSourceImpl implements RemoteSource{
  Future<List<MovieModel>> getAllMovies() async{
    final responseData = await http.get(Uri.parse(Urls.getAllApi));
    final response = jsonDecode(responseData.body);
    List<MovieModel> movies = [];
    for(var movie in response['data']){
      final datatobeconverted = MovieModel.fromJson(movie);
      movies.add(datatobeconverted);
    }
    return movies;
  }

   Future<MovieModel> getOneMovie(String? id) async {
       final responseData = await http.get(Uri.parse("${Urls.getOneApi}${id}"));
       final response = jsonDecode(responseData.body);
       return MovieModel.fromJson(response);
   }
}