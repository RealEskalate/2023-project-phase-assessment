import 'package:mobile/features/example/domain/entities/Movie.dart';

abstract class MovieRepository{
Future<List<Movie>> getAllMovies();
Future<Movie> getOneMovie(String? id); 
}