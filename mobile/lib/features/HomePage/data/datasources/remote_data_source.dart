
import 'dart:convert';

import '../../../../core/errors/exceptions.dart';
import '../models/movie_data_model.dart';
import "package:http/http.dart" as http;

abstract class RemoteDataSource{
  Future<List<Data>> getMovies();
  Future<List<Data>> searchMovies(String searchParam);
}

class RemoteDataSourceImpl implements RemoteDataSource{
  @override
  Future<List<Data>> getMovies() async{
    return await _getDataFromUrl();
  }
  
  @override
  Future<List<Data>> searchMovies(String searchParam) async{
    return await _searchDataFromApi(searchParam);
  }

 Future<List<Data>> _getDataFromUrl() async {
    final response = await http
        .get(Uri.parse('https://film-db.onrender.com/api/v1/article'));

    var fetchedData = <Data>[];
    if (response.statusCode == 200) {
      for (var art in jsonDecode(response.body)['data']) {
        fetchedData.add(Data.fromJson(art));
      }
      return fetchedData;
    } else {
      throw ServerException();
    }
  }
  
   Future<List<Data>> _searchDataFromApi(String searchParam) async {
    final response = await http
        .get(Uri.parse('https://film-db.onrender.com/api/v1/article?searchParams=$searchParam'));

    var fetchedData = <Data>[];
    if (response.statusCode == 200) {
      for (var art in jsonDecode(response.body)['data']) {
        fetchedData.add(Data.fromJson(art));
      }
      return fetchedData;
    } else {
      throw ServerException();
    }
  }

}