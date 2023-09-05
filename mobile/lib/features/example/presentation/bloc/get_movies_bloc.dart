import 'package:bloc/bloc.dart';
import 'package:equatable/equatable.dart';
import 'package:mobile/core/usecase.dart';
import 'package:mobile/features/example/data/datasources/remote_data_source/remote_data_source.dart';
import 'package:mobile/features/example/data/datasources/remote_data_source/remote_data_source_impl.dart';
import 'package:mobile/features/example/data/repository/movie_repo_impl.dart';
import 'package:mobile/features/example/domain/entities/Movie.dart';
import 'package:mobile/features/example/domain/repositories/movie_repository.dart';
import 'package:mobile/features/example/domain/usecases/get_all_movies.dart';

part 'get_movies_event.dart';
part 'get_movies_state.dart';

class GetMoviesBloc extends Bloc<GetMoviesEvent, GetMoviesState> {
  GetMoviesBloc() : super(GetMoviesInitial())  {
    on<GetAllMovie>((event, emit) async {
      // print("event recieved");
      // print(event);
      final RemoteSource remoteSource = RemoteSourceImpl();
      final MovieRepository repository = MovieRepoImpl(remoteSource: remoteSource);
      final GetAllUsecase getAllUsecase = GetAllMoviesImpl(repository: repository);
     final List<Movie> movies= await getAllUsecase.call();
      emit(GetMovies(movies: movies));
    });

    on<GetStarted>((event, emit){
      emit(GettingMovies());
      // print("event recieved from get started");
      
    });

    on<AppStarted>((event, emit){
      emit(Onboarding());
    });


  }
}
