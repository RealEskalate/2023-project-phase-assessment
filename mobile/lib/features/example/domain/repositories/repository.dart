import 'dart:io';

import 'package:dartz/dartz.dart';
import '../../../../core/error/failure.dart';
import '../entities/movie.dart';
import '../../data/models/movie.dart' as moviemodel;

abstract class MovieRepository {
  Future<Either<Failure, List<Movie>>> getAllMovies();
  Future<Either<Failure, List<moviemodel.MovieModel>>> getAllBookmarks();
  Future<Either<Failure, Movie>> getSingleMovie(String movieId);
  Future<Either<Failure, List<Movie>>> searchMovie(String tag, String key);
  // add bookmark
  Future<Either<Failure, bool>> addBookmark({
    required String id,
    required String category,
    required String title,
    required String description,
    required String duration,
    required String image,
    required double rating,
    required String createdAt,
  });
}
