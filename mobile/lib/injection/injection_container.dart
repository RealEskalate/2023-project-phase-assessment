import 'package:get_it/get_it.dart';
import 'package:mobile/features/home/data/datasources/movie_remote_datasource.dart';
import 'package:mobile/features/home/domain/entities/movie.dart';
import 'package:mobile/features/home/domain/usecases/search_movies.dart';
import 'package:mobile/features/home/presentation/bloc/home_bloc.dart';
import 'package:shared_preferences/shared_preferences.dart';

import '../features/home/data/repositories/movie_repository_impl.dart';
import '../features/home/domain/repositories/movie_repository.dart';
import '../features/home/domain/usecases/get_movies.dart';

final sl = GetIt.instance;

Future<void> init() async {
  //! Features - Task Management
  // Bloc
  sl.registerFactory(() => HomeBloc());

  // Use cases
  sl.registerLazySingleton(() => GetMovies(sl()));
  sl.registerLazySingleton(() => SearchForMovies(sl()));
  // sl.registerLazySingleton(() => LoginUseCase(repository: sl()));

  // Repository
  sl.registerLazySingleton<MovieRepository>(() => MovieRepositoryImpl());

  // Data sources

  sl.registerLazySingleton<MovieRemoteDataource>(
      () => MovieRemoteDataourceImpl());

  // classes
  sl.registerLazySingleton(() => <Movie>[]);

  //! Core
//
  //! External
}
