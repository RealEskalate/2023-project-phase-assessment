import 'package:get_it/get_it.dart';
import 'package:mobile/features/example/data/datasources/remote_data_source.dart';
import 'package:mobile/features/example/data/datasources/remote_data_source_impl.dart';
import 'package:mobile/features/example/domain/repositories/movie_repo.dart';
import 'package:mobile/features/example/presentation/bloc/movie_bloc.dart';
import 'package:shared_preferences/shared_preferences.dart';
import 'package:http/http.dart';
import 'package:mobile/features/example/data/repository/movie_repo_Impl.dart';
import 'package:mobile/features/example/domain/entities/movie.dart';
import 'package:mobile/features/example/domain/usecases/get_bookmark_usecase.dart';
import 'package:mobile/features/example/domain/usecases/get_movies_usecase.dart';
import 'package:mobile/features/example/domain/usecases/search_movies_usecase.dart';
import 'package:mobile/features/example/domain/usecases/set_bookmark_usecase.dart';

final sl = GetIt.instance;

void setup() {
  sl.registerSingleton(Client());
  sl.registerSingleton<RemoteDataSource>(RemoteDataSourceImpl(sl()));
  sl.registerFactory<MovieRepo>(() => MovieRepoImpl(sl()));
  sl.registerFactory(() => GetBookMarkUsecase(sl()));
  sl.registerFactory(() => GetMoviesUsercase(sl()));
  sl.registerFactory(() => SearchMovieUsecase(sl()));
  sl.registerFactory(() => SetBookMarkUsecase(sl()));

  sl.registerFactory(() => MovieBloc(
    sl(),
    sl(),
    sl(),
    sl(),
  ));
}
