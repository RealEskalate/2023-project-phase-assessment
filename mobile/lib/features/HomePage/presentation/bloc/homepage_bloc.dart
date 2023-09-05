import 'package:bloc/bloc.dart';
import 'package:equatable/equatable.dart';
import 'package:mobile/features/HomePage/data/datasources/remote_data_source.dart';
import 'package:mobile/features/HomePage/data/repositories/movie_repository_imp.dart';
import 'package:mobile/features/HomePage/domain/repositories/movie_repository.dart';
import 'package:mobile/features/HomePage/domain/usecases/get_movies.dart';

import '../../data/models/movie_data_model.dart';

part 'homepage_event.dart';
part 'homepage_state.dart';

class HomepageBloc extends Bloc<HomepageEvent, HomepageState> {
  HomepageBloc() : super(HomepageInitial()) {
    on<GetDataEvent>((event, emit) async{   
      RemoteDataSource dataSource = RemoteDataSourceImpl();
      MovieRepository repository = MovieRepositoryImpl(dataSource);
      GetMovies moviesData= GetMovies(repository);
      
      final fetchedData = await moviesData.call();

      if (fetchedData.isRight()) {
        emit(MovieDataLoaded(data: fetchedData.getOrElse(() => [])));
      }
    });
  }
}
