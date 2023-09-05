// import 'package:dartz/dartz.dart';
// import 'package:equatable/equatable.dart';
// import 'package:mobile/core/errors/failure.dart';
// import 'package:mobile/core/usecase/usecase.dart';
// import 'package:mobile/features/example/data/models/movie_model.dart';
// import 'package:mobile/features/example/domain/entities/MovieEntity.dart';
// import 'package:mobile/features/example/domain/repositories/movie_repository.dart';

// class FilterArticles implements Usecase<List<MovieModel>, FilterParams> {
//   final MovieRepository repository;

//   FilterArticles(this.repository);

//   @override
//   Future<Either<Failure, List<MovieEntity>>> call(FilterParams params) async {
//     return await repository.filteredMovies(params.title);
//   }
// }

// class FilterParams extends Equatable {
//   final String title;

//   const FilterParams({ required this.title});

//   @override
//   List<Object?> get props => [title];
// }
