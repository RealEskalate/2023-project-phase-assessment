import 'package:get_it/get_it.dart';
import 'package:internet_connection_checker/internet_connection_checker.dart';
import 'package:mobile/core/network/network_info.dart';
import 'package:mobile/features/example/data/datasources/movie_local_data_source.dart';
import 'package:mobile/features/example/data/datasources/movie_remote_data_source.dart';
import 'package:mobile/features/example/domain/usecases/get_movie_by_id.dart';
import 'package:mobile/features/example/domain/usecases/get_movie_by_search.dart';
import 'package:mobile/features/example/domain/usecases/get_movies.dart';
import 'package:mobile/features/example/presentation/bloc/movie_bloc.dart';
import 'package:mobile/features/example/presentation/bloc/movie_id_bloc.dart';
import 'package:shared_preferences/shared_preferences.dart';
import 'package:http/http.dart' as http;

final serviceLocator = GetIt.instance;

Future<void> init() async {
  serviceLocator.registerFactory(() => MovieBloc(
      getMovies: serviceLocator(), getMovieBySearch: serviceLocator()));
  serviceLocator
      .registerFactory(() => MovieIdBloc(getMovieById: serviceLocator()));
  serviceLocator
      .registerLazySingleton(() => GetMovieById(repository: serviceLocator()));
  serviceLocator
      .registerLazySingleton(() => GetMovies(repository: serviceLocator()));
  serviceLocator.registerLazySingleton(
      () => GetMovieBySearch(repository: serviceLocator()));

  serviceLocator.registerLazySingleton<NetworkInfo>(
      () => NetworkInfoImpl(serviceLocator()));
  serviceLocator.registerLazySingleton<MovieLocalDataSource>(
      () => MovieLocalDataSourceImpl(sharedPreferences: serviceLocator()));
  serviceLocator.registerLazySingleton<MovieRemoteDataSource>(
      () => MovieRemoteDataSourceImpl(client: serviceLocator()));

  final sharedPreference = await SharedPreferences.getInstance();
  serviceLocator.registerLazySingleton(() => sharedPreference);
  serviceLocator.registerLazySingleton(() => InternetConnectionChecker());
  serviceLocator.registerLazySingleton(() => http.Client);
}
