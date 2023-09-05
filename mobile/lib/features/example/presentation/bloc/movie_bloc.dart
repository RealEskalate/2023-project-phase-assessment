import 'package:bloc/bloc.dart';
import 'package:meta/meta.dart';
import 'package:mobile/core/Error/failures.dart';
import 'package:mobile/core/Usecase/usecase.dart';
import 'package:mobile/features/example/data/datasources/movie_remote_data_source_impl.dart';
import 'package:mobile/features/example/data/models/movie_model.dart';
import 'package:mobile/features/example/data/repository/movie_repository_impl.dart';
import 'package:mobile/features/example/domain/repositories/movie_repositry.dart';
import 'package:mobile/features/example/domain/usecases/get_movie_usecase.dart';
import 'package:mobile/features/example/domain/usecases/search_movie_usecase.dart';

part 'movie_event.dart';
part 'movie_state.dart';

class MovieBloc extends Bloc<MovieEvent, MovieState> {
  MovieBloc() : super(MovieInitial()) {
    MovieRemoteDataSource remoteDataSource = MovieRemoteDataSourceImpl();
    MovieRepository repository = MovieRepositoryImpl(remoteDataSource);

    GetMovieUseCase getMovies = GetMovieUseCase(repository);
    SearchMovieUseCase searchMovie = SearchMovieUseCase(repository );

    on<GetMoviesEvent>((event, emit) async{
      emit(MovieLoading());

      try{
        final result = await getMovies(NoParams());

        result.fold((Faliure) => emit(MovieFailed()), (movie) => emit(MovieLoadedAll(movie: movie)));

      }catch(e){
        emit(MovieFailed());
      }
    });
    on<SearchMovieEvent>((event, emit) async{
      emit(MovieLoading());

      try{
        final result = await searchMovie(SearchParams(query: event.query));

        result.fold((Faliure) => emit(MovieFailed()), (movie) => emit(MovieLoadedSearch(movie: movie)));

      }catch(e){
        emit(MovieFailed());
      }
    });
  }
}
