/// API Url

class ApiEndPoints {
  static const String apiBaseUrl = 'https://film-db.onrender.com/api/v1/';
}

class LocalStorageConstants {
  static const String bookmarkedMovies = 'bookmarked_movies';
  static const String cachedMovies = 'cached_movies';
  static const String cachedMovie = 'cached_movie';
}

class ErrorMessages {
  static const String SERVER_FAILURE_MESSAGE =
      'Server Failure: Please try again later';
  static const String INVALID_RESPONSE_FROMAT_MESSAGE =
      'Login Failure: Please check your username and password';

  static const String NETWORK_FAILURE_MESSAGE =
      'Network Failure: Please check your internet connection';

  static const String CACHE_FAILURE_MESSAGE = 'Cache Failure';

  static const String UNKNOWN_FAILURE_MESSAGE = 'Unknown error';
}
