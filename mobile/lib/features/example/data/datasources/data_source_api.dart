import 'dart:io';
import 'package:dartz/dartz.dart';
import 'package:mobile/features/example/data/models/film_models.dart';

abstract class RemoteDataSource {
  Future<List<Movie>> fetchMovies();
}
