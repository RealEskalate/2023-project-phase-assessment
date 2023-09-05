import 'package:bloc/bloc.dart';
import 'package:equatable/equatable.dart';
import 'package:mobile/features/example/data/repository/movie_repo_Impl.dart';
import 'package:mobile/features/example/domain/entities/movie.dart';
import 'package:mobile/features/example/domain/usecases/get_bookmark_usecase.dart';
import 'package:mobile/features/example/domain/usecases/get_movies_usecase.dart';
import 'package:mobile/features/example/domain/usecases/search_movies_usecase.dart';
import 'package:mobile/features/example/domain/usecases/set_bookmark_usecase.dart';
part 'movie_event.dart';
part 'movie_state.dart';

class MovieBloc extends Bloc<MovieEvent, MovieState> {
  GetMoviesUsercase? getMoviesUsercase;
  SearchMovieUsecase? searchMovieUsecase;
  SetBookMarkUsecase? setBookMarkUsecase;
  GetBookMarkUsecase? getBookMarkUsecase;

  MovieBloc(
     this.getMoviesUsercase,
     this.searchMovieUsecase,
     this.setBookMarkUsecase,
     this.getBookMarkUsecase,
  ) : super(MovieInitial()) {
    on<GetMovies>(onGetMovies);

    on<SearchMovies>((event, emit) async {
      emit(MovieSearching());
      final result = await searchMovieUsecase!(event.s);
      result.fold((l) => emit(Error(message: l.message)),
          (r) => emit(MovieSearched(r)));
    });

    on<BookMarkMovie>((event, emit) async {
      final result = await setBookMarkUsecase!(event.movie);

      result.fold((l) => emit(Error(message: l.message)), (r) => null);
    });
  }

  void onGetMovies(event, emit) async {
    emit(MovieLoading());
    final result = await getMoviesUsercase!();
    final result2 = await getBookMarkUsecase!();
    List<Movie> bl = [];
    result2.fold((l) => emit(Error(message: l.message)), (r) {
      bl = r;
    });
    result.fold((l) => emit(Error(message: l.message)),
        (r) => emit(MovieLoaded(r, bl)));
  }
}
