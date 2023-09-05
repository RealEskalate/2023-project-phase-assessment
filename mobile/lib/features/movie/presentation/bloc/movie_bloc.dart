import 'dart:async';

import 'package:bloc/bloc.dart';
import 'package:equatable/equatable.dart';
import 'package:mobile/features/movie/domain/usecase/get_movies.dart';

import '../../domain/entities/movie.dart';

part 'movie_event.dart';
part 'movie_state.dart';

class MovieBloc extends Bloc<MovieEvent, MovieState> {
  final GetMovies _getMovies;
  MovieBloc({
    required GetMovies getMovies,
  })  : _getMovies = getMovies,
        super(MovieInitial()) {
    on<GetAllMoviesEvent>(_getAllMoviesHandler);
  }

  FutureOr<void> _getAllMoviesHandler(
      GetAllMoviesEvent event, Emitter<MovieState> emit) async {
    emit(const GettingMovies());

    final result = await _getMovies();
    print(result);

    result.fold((failure) => emit(MvovieError(failure.errorMessage)),
        (articles) => emit(MoviesLoaded(articles)));
  }
}
