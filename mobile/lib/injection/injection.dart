import 'package:get_it/get_it.dart';
import 'package:internet_connection_checker/internet_connection_checker.dart';
import 'package:mobile/features/example/data/datasources/remote_data_source.dart';
import 'package:shared_preferences/shared_preferences.dart';

import 'package:http/http.dart' as http;

import '../core/platform/network_info.dart';
import '../features/example/data/datasources/datasource_api.dart';
import '../features/example/data/datasources/local_data_source.dart';
import '../features/example/data/repository/repository_imp.dart';
import '../features/example/domain/repositories/repository.dart';
import '../features/example/domain/usecases/add_bookmark.dart';
import '../features/example/domain/usecases/get_all_bookmarks.dart';
import '../features/example/domain/usecases/get_all_movies.dart';
import '../features/example/domain/usecases/get_single_movies.dart';
import '../features/example/presentation/bloc/bloc.dart';

final sl = GetIt.instance;

Future<void> init() async {
  final sharedPreference = await SharedPreferences.getInstance();
  sl.registerSingleton<SharedPreferences>(sharedPreference);

  // Register network info
  sl.registerLazySingleton<NetworkInfo>(() => NetworkInfoImpl(sl()));
  sl.registerLazySingleton(() => http.Client());
  sl.registerLazySingleton(() => InternetConnectionChecker());

  // register blog
  sl.registerFactory(
    () => MoviesBloc(
      getAllMovies: sl<GetMoviesUseCase>(),
      getSingleMovie: sl<GetSingleMovieUseCase>(),
      getBookmark: sl<GetBookmarkUseCase>(),
      addBookmark: sl<AddBookmarkUseCase>(),
    ),
  );

  // Register usecases
  sl.registerFactory(() => GetMoviesUseCase(sl()));
  sl.registerFactory(() => GetSingleMovieUseCase(sl()));
  sl.registerFactory(() => GetBookmarkUseCase(sl()));
  sl.registerFactory(() => AddBookmarkUseCase(sl()));

  sl.registerLazySingleton<MovieRepository>(
      () => MoviesRepositoryImp(remoteDataSource: sl(), localDataSource: sl()));

  //RemoteDataSource
  sl.registerLazySingleton<MovieRemoteDataSource>(() =>
      MovieRemoteDataSourceImp(baseUrl: 'https://film-db.onrender.com/api/v1'));

  sl.registerLazySingleton<MoviesLocalDataSource>(
      () => MovieLocalDataSourceImp(sharedPreferences: sl()));

  // sl.registerLazySingleton<MovieRepository>(
  //     () => MoviesRepositoryImp(remoteDataSource: sl(), localDataSource: sl()));
}
