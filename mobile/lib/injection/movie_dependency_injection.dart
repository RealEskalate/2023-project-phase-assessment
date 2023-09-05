import 'package:get_it/get_it.dart';
import 'package:internet_connection_checker/internet_connection_checker.dart';
import 'package:mobile/core/network/network_info.dart';
import 'package:mobile/features/movie/domain/use_cases/use_case.dart';
import 'package:shared_preferences/shared_preferences.dart';

import '../features/movie/data/data_sources/local_data_source.dart';
import '../features/movie/data/data_sources/local_data_source_impl.dart';
import '../features/movie/data/data_sources/remote_data_source.dart';
import '../features/movie/data/data_sources/remote_data_source_impl.dart';
import '../features/movie/data/repositories/movie_repository_implementation.dart';
import '../features/movie/domain/repositories/movie_repository.dart';
import '../features/movie/presentation/bloc/movie_bloc.dart';

import 'package:http/http.dart' as http;

GetIt getIt = GetIt.instance;

Future<void> init() async {
  //! Feature - Movie

  // Bloc
  getIt.registerFactory(() => MovieBloc(
        getAllMoviesUseCase: getIt(),
        searchMoviesUseCase: getIt(),
        bookmarkMovieUseCase: getIt(),
        removeFromBookmarkMovieUseCase: getIt(),
        getMovieDetailUseCase: getIt(),
        getBookmarkedMoviesUseCase: getIt(),
      ));

  // Use cases
  getIt.registerLazySingleton(() => GetAllMoviesUseCase(repository: getIt()));
  getIt.registerLazySingleton(() => GetMovieDetailUseCase(repository: getIt()));
  getIt.registerLazySingleton(() => SearchMoviesUseCase(repository: getIt()));
  getIt.registerLazySingleton(() => BookmarkMovieUseCase(repository: getIt()));
  getIt.registerLazySingleton(
      () => RemoveFromBookmarkMovieUseCase(repository: getIt()));
  getIt.registerLazySingleton(
      () => GetBookmarkedMoviesUseCase(repository: getIt()));

  // Repository
  getIt.registerLazySingleton<MovieRepository>(() => MovieRepositoryImpl(
        remoteDataSource: getIt(),
        localDataSource: getIt(),
        networkInfo: getIt(),
      ));

  // Data sources
  getIt.registerLazySingleton<MovieRemoteDataSource>(
      () => MovieRemoteDataSourceImpl(client: getIt()));

  getIt.registerLazySingleton<MovieLocalDataSource>(
      () => MovieLocalDataSourceImpl(sharedPreferences: getIt()));

  // External
  final sharedPreferences = await SharedPreferences.getInstance();
  getIt.registerLazySingleton(() => http.Client());
  getIt.registerLazySingleton(() => sharedPreferences);
  getIt.registerLazySingleton(() => InternetConnectionChecker());

  //! Core
  getIt.registerLazySingleton<NetworkInfo>(() => NetworkInfoImpl(getIt()));
}
