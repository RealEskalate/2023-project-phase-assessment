import 'package:get_it/get_it.dart' ;
import 'package:http/http.dart' as http;
import 'package:mobile/features/movies/data/datasources/movie_api_resource.dart';
import 'package:mobile/features/movies/data/datasources/movie_local_datasource.dart';
import 'package:mobile/features/movies/data/repository/movie_repository.dart';
import 'package:mobile/features/movies/domain/repositories/movies_repository.dart';
import 'package:mobile/features/movies/domain/usecases/get_movies_usecase.dart';
import 'package:mobile/features/movies/presentation/bloc/movie_bloc.dart';
import 'package:mobile/features/movies/presentation/cubit/bookmark_cubit.dart';
import 'package:shared_preferences/shared_preferences.dart';
final sl = GetIt.instance;


Future<void> setup() async{
  var sharedPreferences = await SharedPreferences.getInstance();
  sl.registerFactory(() => BookmarkCubit(moviesRepository: sl()));
  // Bloc
  sl.registerFactory(() => MovieBloc(getMoviesUseCase: sl(), moviesRepository: sl()));
  // Use cases
  sl.registerLazySingleton(() => GetMoviesUseCase(sl()));
  // Repository
  sl.registerLazySingleton<MoviesRepository>(() => MovieRepositoryImpl(movieApiDataSource: sl(),
  movieBookmarkDataSource: sl()
    
  ));
  sl.registerLazySingleton<MovieBookmarkDataSource>(() => MovieBookmarkDataSourceImpl(sharedPreferences));
  // Data sources
  sl.registerLazySingleton<MovieApiDataSource>(() => MovieApiResource(client: sl()));
  // sl.registerLazySingleton<MoviesLocalDataSource>(() => MoviesLocalDataSourceImpl(sharedPreferences: sl()));
  // Core
  // sl.registerLazySingleton<NetworkInfo>(() => NetworkInfoImpl(sl()));
  // External
  sl.registerLazySingleton(() => http.Client());
  // sl.registerLazySingleton(() => DataConnectionChecker());
  // sl.registerLazySingleton(() => SharedPreferences.getInstance());
  return Future.value();
}