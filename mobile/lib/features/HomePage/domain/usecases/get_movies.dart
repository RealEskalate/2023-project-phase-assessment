

import 'package:dartz/dartz.dart';
import 'package:equatable/equatable.dart';
import 'package:mobile/features/HomePage/data/repositories/movie_repository_imp.dart';
import 'package:mobile/features/HomePage/domain/repositories/movie_repository.dart';

import '../../../../core/errors/Failure.dart';
import '../../data/models/movie_data_model.dart';

class GetMovies extends Equatable{
  final MovieRepository repository;
  const GetMovies(this.repository);
  
   Future<Either<Failure,List<Data>>> call() async{
    return await repository.getMovies();
  }

  @override
  List<Object?> get props =>[repository];

}