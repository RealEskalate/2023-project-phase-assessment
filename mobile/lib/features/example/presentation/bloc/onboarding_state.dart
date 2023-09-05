import 'package:bloc/bloc.dart';
import 'package:meta/meta.dart';
import 'package:mobile/features/example/domain/entities/movie_entity.dart';
import '../../data/repository/movie_repository.dart';


abstract class OnboardingEvent {}

class OnboardingLoadData extends OnboardingEvent {}


abstract class OnboardingState {}

class OnboardingInitial extends OnboardingState {}

class OnboardingLoading extends OnboardingState {}

class OnboardingDataLoaded extends OnboardingState {
  final List<MovieEntity> movies;

  OnboardingDataLoaded(this.movies);
}

class OnboardingError extends OnboardingState {
  final String errorMessage;

  OnboardingError(this.errorMessage);
}

class OnboardingBloc extends Bloc<OnboardingEvent, OnboardingState> {
  final MovieRepository movieRepository = MovieRepository();

  OnboardingBloc() : super(OnboardingInitial());
  
  List<MovieEntity> get movies => this.movies;

  @override
  Stream<OnboardingState> mapEventToState(OnboardingEvent event) async* {
    if (event is OnboardingLoadData) {
      yield OnboardingLoading();

      try {
        final List<dynamic> data = await movieRepository.fetchMovies();
        final List movies =
            data.map((movieData) => MovieEntity.fromJson(movieData)).toList();
        yield OnboardingDataLoaded(this.movies);
      } catch (e) {
        yield OnboardingError('Failed to load data');
      }
    }
  }
}
