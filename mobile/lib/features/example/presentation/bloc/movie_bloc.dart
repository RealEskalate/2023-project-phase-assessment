import 'package:bloc/bloc.dart';
import 'package:equatable/equatable.dart';
import 'package:mobile/core/usecase/usecase.dart';
import 'package:mobile/features/example/domain/entities/movie.dart';
import 'package:mobile/features/example/domain/usecases/get_movie_by_search.dart';
import 'package:mobile/features/example/domain/usecases/get_movies.dart';

part 'movie_event.dart';
part 'movie_state.dart';

class MovieBloc extends Bloc<MovieEvent, MovieState> {
  GetMovies getMovies;
  GetMovieBySearch getMovieBySearch;
  MovieBloc({required this.getMovies, required this.getMovieBySearch})
      : super(MovieInitial()) {
    on<GiveMeData>((event, emit) async {
      emit(MovieLoading());
      final result = await getMovies(NoParams());
      result.fold((l) => emit(MovieError(message: l.toString())),
          (r) => emit(MovieLoaded(movies: r)));
    });
    on<GiveMeSearchedData>((GiveMeSearchedData event, emit) async{
      emit(MovieLoading());
      final result = await getMovieBySearch(event.searchParams);
      result.fold((l) => emit(MovieError(message: l.toString())),
          (r) => emit(MovieLoaded(movies: r)));
    });
  }
}
