import 'package:get_it/get_it.dart';
import 'package:http/http.dart' as http;
import 'package:internet_connection_checker/internet_connection_checker.dart';
import 'package:shared_preferences/shared_preferences.dart';

import '../core/network/network_info.dart';
import '../features/movie/data/datasources/local/local_datasource.dart';
import '../features/movie/data/datasources/local/local_datasource_impl.dart';
import '../features/movie/data/datasources/remote/remote_datasource.dart';
import '../features/movie/data/datasources/remote/remote_datasource_impl.dart';
import '../features/movie/data/repository/movie_repository_impl.dart';
import '../features/movie/domain/repositories/movie_repository.dart';
import '../features/movie/domain/usecases/filter_movies.dart';
import '../features/movie/domain/usecases/get_movie.dart';
import '../features/movie/domain/usecases/get_movies.dart';
import '../features/movie/presentation/bloc/movie_bloc.dart';

final serviceLocator = GetIt.instance;

Future<void> init() async {
  //! Features - Article
  // Bloc
  serviceLocator.registerFactory(
    () => MovieBloc(
      getAllMovies: serviceLocator(),
      getMovie: serviceLocator(),
      filterMovies: serviceLocator(),
    ),
  );

  // Use cases

  serviceLocator.registerLazySingleton(
    () => GetMovies(serviceLocator()),
  );
  serviceLocator.registerLazySingleton(
    () => GetMovie(serviceLocator()),
  );
  serviceLocator.registerLazySingleton(
    () => FilterMovies(repository: serviceLocator()),
  );

  // Core
  serviceLocator.registerLazySingleton<NetworkInfo>(() =>
      NetworkInfoImpl(serviceLocator(), connectionChecker: serviceLocator()));

  // Repository
  serviceLocator.registerLazySingleton<MovieRepository>(
    () => MovieRepositoryImpl(
      remoteDataSource: serviceLocator(),
      localDataSource: serviceLocator(),
      networkInfo: serviceLocator(),
    ),
  );

  // Data sources
  serviceLocator.registerLazySingleton<LocalDataSource>(
    () => LocalDataSourceImpl(sharedPreferences: serviceLocator()),
  );
  serviceLocator.registerLazySingleton<RemoteDataSource>(
    () => RemoteDataSourceImpl(),
  );

  // External
  final sharedPreferences = await SharedPreferences.getInstance();
  serviceLocator.registerLazySingleton(() => sharedPreferences);
  serviceLocator.registerLazySingleton(() => InternetConnectionChecker());
  serviceLocator.registerLazySingleton(() => http.Client());
}
