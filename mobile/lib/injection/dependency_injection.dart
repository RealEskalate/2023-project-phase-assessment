import 'package:get_it/get_it.dart';
import 'package:http/http.dart';
import 'package:mobile/features/example/data/datasources/remote_datasources/movie_remote_datasource.dart';
import 'package:mobile/features/example/data/datasources/remote_datasources/movie_remote_datasource_impl.dart';
import 'package:mobile/features/example/data/repository/movie_repository_impl.dart';
import 'package:mobile/features/example/domain/usecases/get_movies_usecase.dart';
import 'package:mobile/features/example/domain/usecases/search_movies_usecase.dart';
import 'package:mobile/features/example/presentation/bloc/movie_bloc.dart';

import '../features/example/domain/repositories/movie_repository.dart';

final sl = GetIt.instance;

Future<void> setup() async {
  sl.registerSingleton(Client());
  sl.registerSingleton<MovieRemoteDataSource>(
      MovieRemoteDataSourceImpl(client: sl()));
  sl.registerFactory<MovieRepository>(() => MovieRempositoryImpl(
        remoteDataSource: sl(),
      ));

  sl.registerFactory(() => GetMovies(sl()));
  sl.registerFactory(() => SearchMovies(sl()));

  sl.registerFactory(() => MovieBloc(
        getmovies: sl(),
        searchMovies: sl(),
      ));
}
