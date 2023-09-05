import 'package:dartz/dartz.dart';
import 'package:equatable/equatable.dart';

import '../../../../core/error/failures.dart';
import '../../../../core/usecase/usecase.dart';
import '../entities/movie.dart';
import '../repositories/movie_repository.dart';

class BookMarkMovie extends UseCase<Movie, BookMarkParams> {
  final MovieRepository repository;

  BookMarkMovie(this.repository);

  @override
  Future<Either<Failure, Movie>> call(BookMarkParams params) async {
    return await repository.bookMarkMovie(params.movie);
  }
}

class BookMarkParams extends Equatable {
  final Movie movie;

  const BookMarkParams({required this.movie});

  @override
  List<Object?> get props => [id];
}
