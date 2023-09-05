import 'package:dartz/dartz.dart';
import 'package:equatable/equatable.dart';

import '../../../../core/exceptions/Failure.dart';
import '../../../../core/usecases/usecase.dart';
import '../entities/movie.dart';
import '../repositories/movie_repository.dart';

class GetMovies extends UseCase<List<Movie> , NoParams>{ 
  final MovieRepository repository;
  GetMovies(this.repository);

  @override
  Future<Either<Failure, List<Movie>>> call(NoParams params ) async{
    return await repository.getMovies();
  }

}
