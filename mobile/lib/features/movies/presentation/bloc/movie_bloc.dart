import 'dart:developer';

import 'package:bloc/bloc.dart';
import 'package:dartz/dartz.dart';
import 'package:meta/meta.dart';
import 'package:mobile/core/error/failure.dart';
import 'package:mobile/features/movies/data/datasources/remote_data_source.dart';
import 'package:mobile/features/movies/data/repository/movie_repo_impl.dart';
import 'package:mobile/features/movies/domain/entities/movie.dart';
import 'package:mobile/features/movies/domain/usecases/get_all_movies.dart';
import 'package:mobile/features/movies/presentation/bloc/movie_event.dart';
import 'package:mobile/features/movies/presentation/bloc/movie_state.dart';

class MovieBloc extends Bloc<MovieEvent, MovieState> {
  var repoImpl = MovieRepositoryImpl(
      remoteDataSource:
          RemoteDataSource(baseUrl: "https://film-db.onrender.com/api/v1"));

  MovieBloc() : super(MovieInitial()) {
    on<GetAllMoviesEvent>((event, emit) async {
      try {
        var usecase = await GetAllMoviesUseCase(repoImpl);
        Either<Failure, List<Movie>> data = await usecase();
        log("received");
        log(data.toString());
        log('get all movies event - bloc 1');

        emit(MovieLoading());
        log("after loading");
        // emit(AllMoviesLoaded(data));

        emit(data.fold(
          (failure) => MovieError(_mapFailureToMessage(failure)),
          (movies) => AllMoviesLoaded(movies),
        ));
      } catch (e) {
        log("Caught error: $e");
        emit(MovieError(_mapFailureToMessage(e as Failure)));
      }
    });
  }

  String _mapFailureToMessage(Failure failure) {
    return 'An error occurred: $failure';
  }
}
