abstract class MovieRepository {
    Future<List<Movie>> getMovies();
    Future<Movie> getMovie(String id);
    Future<List<Movie>> searchMovies(String query);
}