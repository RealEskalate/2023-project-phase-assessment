import 'package:bloc/bloc.dart';
import 'package:equatable/equatable.dart';
import 'package:mobile/core/usecases/usecase.dart';
import 'package:mobile/features/example/domain/usecases/get_movies_usecase.dart';
import 'package:mobile/features/example/domain/usecases/search_movies_usecase.dart';

import '../../domain/entities/movie.dart';

part 'movie_event.dart';
part 'movie_state.dart';

class MovieBloc extends Bloc<MovieEvent, MovieState> {
  GetMovies getmovies;
  SearchMovies searchMovies;
  MovieBloc({
    required this.getmovies,
    required this.searchMovies,
  }) : super(
          MovieInitial(),
        ) {
    on<GetAllMoviesEvent>(_onGetAllMovies);
    on<SearchMoviesEvent>(_onSearchAllMovies);
  }
  void _onGetAllMovies(
      GetAllMoviesEvent event, Emitter<MovieState> emit) async {
    emit(MovieLoading());
    final result = await getmovies(NoParams());
    result.fold((l) => emit(MovieError()), (r) => emit(AllMovieLoaded(movies: r)));
    print(result);
    
  }

  void _onSearchAllMovies(
      SearchMoviesEvent event, Emitter<MovieState> emit) async {
    emit(MovieLoading());
    final result = await searchMovies(SearchParams(event.query));
    // print(result);
    result.fold((l) => emit(MovieError()), (r) => emit(MovieLoaded(movies: r)));
    print(result);
    print(state);
  }
}
