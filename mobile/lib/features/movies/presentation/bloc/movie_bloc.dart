import 'dart:async';

import 'package:bloc/bloc.dart';
import 'package:equatable/equatable.dart';
import 'package:mobile/features/movies/domain/entities/movie.dart';
import 'package:mobile/features/movies/domain/repositories/movies_repository.dart';
import 'package:mobile/features/movies/domain/usecases/get_movies_usecase.dart';

part 'movie_event.dart';
part 'movie_state.dart';

class MovieBloc extends Bloc<MovieEvent, MovieState> {
  GetMoviesUseCase getMoviesUseCase;
  MoviesRepository moviesRepository;
  MovieBloc({required this.getMoviesUseCase, required this.moviesRepository}) : super(MovieInitial()) {
    on<GetMoviesEvent>(fetchMovies);
    on<SearchMoviesEvent>(searchMovies);
  }

  FutureOr<void> fetchMovies(GetMoviesEvent event, Emitter<MovieState> emit) async {
    emit(MovieLoading(bookMarkedMovies: moviesRepository.getBookmarkedMovies(), movies: []));
    final res = await getMoviesUseCase.execute();
    print(res);
    res.fold((l) => emit(MovieErrorState(bookMarkedMovies: state.bookMarkedMovies, movies: state.movies)), (r) => emit(MovieLoaded(bookMarkedMovies: state.bookMarkedMovies, movies: r)));  
  }

  FutureOr<void> searchMovies(SearchMoviesEvent event, Emitter<MovieState> emit)async  {
    emit(MovieSearchLoading(bookMarkedMovies:state.bookMarkedMovies, movies: []));
    final res = await getMoviesUseCase.execute(event.searchParams);
    print(res);
    res.fold((l) => emit(MovieErrorState(bookMarkedMovies: state.bookMarkedMovies, movies: state.movies)), (r) => emit(MovieSearchState(bookMarkedMovies: state.bookMarkedMovies, movies: r)));  
    if(event.searchParams == ""){
      emit(MovieLoaded(bookMarkedMovies: state.bookMarkedMovies, movies: state.movies));
    }
  }
}
