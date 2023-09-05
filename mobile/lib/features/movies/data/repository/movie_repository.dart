import 'package:dartz/dartz.dart';
import 'package:mobile/core/failure.dart';
import 'package:mobile/features/movies/data/datasources/movie_api_resource.dart';
import 'package:mobile/features/movies/data/datasources/movie_local_datasource.dart';
import 'package:mobile/features/movies/domain/entities/movie.dart';
import 'package:mobile/features/movies/domain/repositories/movies_repository.dart';

class MovieRepositoryImpl implements MoviesRepository{
  final MovieApiDataSource movieApiDataSource;
  final MovieBookmarkDataSource movieBookmarkDataSource;
  MovieRepositoryImpl({required this.movieBookmarkDataSource, required this.movieApiDataSource});
  @override
  Future<Either<Failure, List<Movie>>> getMovies({searchParams = String,}) async {
    return await movieApiDataSource.getMovies(searchParams: searchParams);
  }
  bool isBookmarked(Movie movie) {
    var listOfBookMark = movieBookmarkDataSource.getBookmarkedMovies();
    return listOfBookMark.contains(movie);
  }
  void bookmarkMovie(Movie movie) {
    movieBookmarkDataSource.toggleBookmark(movie);
  }
  void unBookmarkMovie(Movie movie) {
    movieBookmarkDataSource.toggleBookmark(movie);
  }
  List<Movie> getBookmarkedMovies() {
    return movieBookmarkDataSource.getBookmarkedMovies();
  }
}