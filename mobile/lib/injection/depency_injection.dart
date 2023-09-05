import 'package:get_it/get_it.dart';
import 'package:internet_connection_checker/internet_connection_checker.dart';
import 'package:mobile/core/network/network_info.dart';
import 'package:mobile/features/example/data/datasources/movie_local_data_source.dart';
import 'package:mobile/features/example/data/datasources/movie_remote_datasource.dart';
import 'package:mobile/features/example/data/repository/movie-repository_impl.dart';
import 'package:mobile/features/example/domain/repositories/movie_repository.dart';
import 'package:mobile/features/example/domain/usecases/get_all_movie_usecase.dart';
import 'package:mobile/features/example/domain/usecases/get_single_movie.dart';
import 'package:mobile/features/example/presentation/bloc/movie_bloc.dart';
import 'package:shared_preferences/shared_preferences.dart';
import 'package:http/http.dart' as http;

final sl = GetIt.instance;

Future<void> init() async {
  // Bloc
  sl.registerFactory(
    () => MovieBloc(
      viewAllMovies: sl(),
      viewMovie: sl(),
    ),
  );

  // Use cases
  sl.registerLazySingleton(() => GetAllMovies(sl()));
  sl.registerLazySingleton(() => GetSingleMovie(sl()));

  // Repository

  sl.registerLazySingleton<MovieRepository>(
    () => MovieRepositoryImpl(
      localDataSource: sl(),
      remoteDataSource: sl(),
      networkInfo: sl(),
    ),
  );

  // Data sources
  sl.registerLazySingleton<MovieLocalDataSource>(
    () => MovieLocalDataSourceImpl(sharedPreferences: sl()),
  );
  sl.registerLazySingleton<MovieRemoteDataSource>(
    () => MovieRemoteDataSourceImpl(
      client: sl(),
    ),
  );

  //! Core
  sl.registerLazySingleton<NetworkInfo>(
    ()=>NetworkInfoImpl(connectionChecker: sl())

  );

  //! External
  final sharedPreferences = await SharedPreferences.getInstance();
  sl.registerLazySingleton(() => sharedPreferences);

  sl.registerLazySingleton(() => InternetConnectionChecker());
  sl.registerLazySingleton(() => http.Client());
}
