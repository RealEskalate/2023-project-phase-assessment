import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:get_it/get_it.dart';
import 'package:internet_connection_checker/internet_connection_checker.dart';
import 'package:mobile/core/network/network_info.dart';
import 'package:mobile/core/utils/input_converter.dart';
import 'package:mobile/features/movie/data/data_sources/local_data_source.dart';
import 'package:mobile/features/movie/data/data_sources/local_data_source_impl.dart';
import 'package:mobile/features/movie/data/data_sources/remote_data_source.dart';
import 'package:mobile/features/movie/data/data_sources/remote_data_source_impl.dart';
import 'package:mobile/features/movie/data/repositories/movie_repository_implementation.dart';
import 'package:mobile/features/movie/domain/repositories/movie_repository.dart';
import 'package:mobile/features/movie/domain/use_cases/use_case.dart';
import 'package:mobile/features/movie/presentation/bloc/movie_bloc.dart';
import 'package:shared_preferences/shared_preferences.dart';
import 'package:http/http.dart' as http;

final sl = GetIt.instance;

Future<void> init() async {
  sl.registerFactory(() => MovieBloc(
      getAllMoviesUseCase: sl(),
      getMovieDetailUseCase: sl(),
      searchMoviesUseCase: sl(),
      bookmarkMovieUseCase: sl(),
      removeFromBookmarkMovieUseCase: sl(),
      getBookmarkedMoviesUseCase: sl()));

  sl.registerSingleton(() => GetAllMoviesUseCase(repository: sl()));

  sl.registerSingleton(() => GetMovieDetailUseCase(repository: sl()));

  sl.registerSingleton(() => SearchMoviesUseCase(repository: sl()));
  sl.registerSingleton(() => BookmarkMovieUseCase(repository: sl()));
  sl.registerSingleton(() => RemoveFromBookmarkMovieUseCase(repository: sl()));
  sl.registerSingleton(() => GetBookmarkedMoviesUseCase(repository: sl()));

  sl.registerLazySingleton<MovieRepository>(() => MovieRepositoryImpl(
      remoteDataSource: sl(), localDataSource: sl(), networkInfo: sl()));

  sl.registerLazySingleton<MovieRemoteDataSource>(
      () => MovieRemoteDataSourceImpl(client: sl()));

  sl.registerLazySingleton<MovieLocalDataSource>(
      () => MovieLocalDataSourceImpl(sharedPreferences: sl()));

  //! Core
  sl.registerLazySingleton(() => InputConverter());
  sl.registerLazySingleton<NetworkInfo>(
      () => NetworkInfoImpl(sl()));

  //! External
  final sharedPreferences = await SharedPreferences.getInstance();
  sl.registerLazySingleton(() => sharedPreferences);
  sl.registerLazySingleton(() => http.Client());
  sl.registerLazySingleton(() => InternetConnectionChecker());
}
