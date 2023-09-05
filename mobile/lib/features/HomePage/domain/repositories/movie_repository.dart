
import 'package:dartz/dartz.dart';
import 'package:equatable/equatable.dart';

import '../../../../core/errors/Failure.dart';
import '../../data/models/movie_data_model.dart';

abstract class MovieRepository extends Equatable{
  Future<Either<Failure,List<Data>>> getMovies();
  Future<Either<Failure,List<Data>>> searchMovies(String param);
}