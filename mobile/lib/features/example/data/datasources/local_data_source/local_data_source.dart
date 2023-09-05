import 'dart:convert';

import 'package:flutter_secure_storage/flutter_secure_storage.dart';
import 'package:mobile/features/example/data/models/movie_model.dart';


class LocalDataSource{
  final FlutterSecureStorage _secureStorage = const FlutterSecureStorage();
  final List<MovieModel> _lists = [];

  Future<List<MovieModel>> readFromStorage(String key) async{
    return _lists;
  }

  Future<void> writeToStorage(MovieModel data) async{
    _lists.add(data);
  }
}