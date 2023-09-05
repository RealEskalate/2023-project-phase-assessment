import 'package:get_it/get_it.dart';
import 'package:internet_connection_checker/internet_connection_checker.dart';
import 'package:mobile/features/example/data/datasources/local/local.dart';
import 'package:mobile/features/example/data/datasources/remote/remote.dart';
import 'package:mobile/features/example/data/repository/movie_repository_impl.dart';
import 'package:mobile/features/example/domain/repositories/movie_repository.dart';
import 'package:mobile/features/example/presentation/bloc/movie_bloc.dart';
import 'package:shared_preferences/shared_preferences.dart';

import '../core/constants/constants.dart';
import '../core/network/custom_client.dart';
import '../core/network/network_info.dart';
import '../features/example/domain/usecases/usecases.dart';
import '../features/example/presentation/bloc/bookmark_bloc.dart';
import 'package:http/http.dart' as http;

final serviceLocator = GetIt.instance;

Future<void> init() async {
  serviceLocator.registerFactory(
    () => MovieBloc(
      getMovie: serviceLocator(),
      getAllMovies: serviceLocator(),
      filterMovies: serviceLocator(),
    ),
  );
  
  serviceLocator.registerFactory(
    () => BookmarkBloc(
      getBookmarks: serviceLocator(),
      addToBookmark: serviceLocator(),
      removeFromBookmark: serviceLocator(),
    ),
  );


  serviceLocator.registerLazySingleton(
    () => GetAllMovies(serviceLocator()),
  );
  serviceLocator.registerLazySingleton(
    () => GetMovie(serviceLocator()),
  );
  serviceLocator.registerLazySingleton(
    () => FilterMovies(serviceLocator()),
  );

  serviceLocator.registerLazySingleton(
    () => GetBookmarks(serviceLocator()),
  );
  serviceLocator.registerLazySingleton(
    () => AddToBookmark(serviceLocator()),
  );
  serviceLocator.registerLazySingleton(
    () => RemoveFromBookmark(serviceLocator()),
  );


  serviceLocator.registerLazySingleton<NetworkInfo>(
      () => NetworkInfoImpl(serviceLocator()));
  serviceLocator.registerLazySingleton<CustomClient>(
    () => CustomClient(serviceLocator(), apiBaseUrl: apiBaseUrl),
  );

  serviceLocator.registerLazySingleton<MovieRepository>(
    () => MovieRepositoryImpl(
      remoteDatasource: serviceLocator(),
      localDatasource: serviceLocator(),
      networkInfo: serviceLocator(),
    ),
  );

  serviceLocator.registerLazySingleton<LocalDatasource>(
    () => LocalDatasourceImpl(sharedPreferences: serviceLocator()),
  );
  serviceLocator.registerLazySingleton<RemoteDatasource>(
    () => RemoteDatasourceImpl(client: serviceLocator()),
  );

    final sharedPreferences = await SharedPreferences.getInstance();
  serviceLocator.registerLazySingleton(() => sharedPreferences);
  serviceLocator.registerLazySingleton(() => InternetConnectionChecker());
  serviceLocator.registerLazySingleton(() => http.Client());
}
