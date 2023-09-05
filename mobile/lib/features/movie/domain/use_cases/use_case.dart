import 'package:dartz/dartz.dart';
import 'package:mobile/core/error/failure.dart';

import '../entities/movie_entity.dart';
import '../repositories/movie_repository.dart';

abstract class UseCase<Type, Params> {
  Future<Either<Failure, Type>> call(Params params);
}

class GetAllMoviesUseCase extends UseCase<List<MovieEntity>, NoParams> {
  final MovieRepository repository;

  GetAllMoviesUseCase({required this.repository});

  @override
  Future<Either<Failure, List<MovieEntity>>> call(NoParams params) async {
    return await repository.getAllMovies();
  }
}

class GetMovieDetailUseCase extends UseCase<MovieEntity, GetMovieParams> {
  final MovieRepository repository;

  GetMovieDetailUseCase({required this.repository});

  @override
  Future<Either<Failure, MovieEntity>> call(GetMovieParams params) async {
    return await repository.getMovie(params.movieId);
  }
}

class SearchMoviesUseCase
    extends UseCase<List<MovieEntity>, SearchMoviesParams> {
  final MovieRepository repository;

  SearchMoviesUseCase({required this.repository});

  @override
  Future<Either<Failure, List<MovieEntity>>> call(
      SearchMoviesParams params) async {
    return await repository.searchMovies(params.queryParams);
  }
}

class BookmarkMovieUseCase extends UseCase<void, BookmarkMovieParam> {
  final MovieRepository repository;

  BookmarkMovieUseCase({required this.repository});

  @override
  Future<Either<Failure, void>> call(BookmarkMovieParam params) async {
    return await repository.bookmarkMovie(params.movieEntity);
  }
}

class RemoveFromBookmarkMovieUseCase extends UseCase<void, BookmarkMovieParam> {
  final MovieRepository repository;

  RemoveFromBookmarkMovieUseCase({required this.repository});

  @override
  Future<Either<Failure, void>> call(BookmarkMovieParam params) async {
    return await repository.removeMovieFromBookmark(params.movieEntity);
  }
}

class GetBookmarkedMoviesUseCase extends UseCase<List<MovieEntity>, NoParams> {
  final MovieRepository repository;

  GetBookmarkedMoviesUseCase({required this.repository});

  @override
  Future<Either<Failure, List<MovieEntity>>> call(NoParams params) async {
    return await repository.getBookmarkedMovies();
  }
}

class BookmarkMovieParam {
  final MovieEntity movieEntity;

  BookmarkMovieParam({required this.movieEntity});
}

class RemoveFromBookmarkMovieParam {
  final MovieEntity movieEntity;

  RemoveFromBookmarkMovieParam({required this.movieEntity});
}

class GetAllMoviesParam {
  final String? queryParams;
  GetAllMoviesParam({this.queryParams});
}

class NoParams {}

class GetMovieParams {
  final String movieId;

  GetMovieParams({required this.movieId});
}

class SearchMoviesParams {
  final String queryParams;
  SearchMoviesParams({required this.queryParams});
}
