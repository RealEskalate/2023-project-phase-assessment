import 'package:get_it/get_it.dart';
import 'package:mobile/features/movie/data/datasources/remote_data_sources.dart';
import 'package:mobile/features/movie/data/repository/movie_repository_implementation.dart';
import 'package:mobile/features/movie/domain/repository/movie_repo.dart';
import 'package:mobile/features/movie/domain/usecase/get_movies.dart';
import 'package:mobile/features/movie/presentation/bloc/movie_bloc.dart';
import 'package:http/http.dart' as http;

final sl = GetIt.instance;

Future<void> init() async {
  sl
    ..registerFactory(() => MovieBloc(
          getMovies: sl(),
        ))

    // usecases
    ..registerLazySingleton(() => GetMovies(sl()))

    // repositories
    ..registerLazySingleton<MovieRepository>(() => MovieRepositoryImp(sl()))

    //  data source
    ..registerLazySingleton<MovieRemoteDataSource>(
        () => MovieRemotDataSourceImp(sl()))

    // external dependencies
    ..registerLazySingleton(http.Client.new);
}
