part of 'movie_bloc.dart';

sealed class MovieEvent extends Equatable {
  const MovieEvent();

  @override
  List<Object> get props => [];
}

final class LoadAllMoviesEvent extends MovieEvent {}

final class LoadSingleMovieEvent extends MovieEvent {
  final String id;

  const LoadSingleMovieEvent({required this.id});

  @override
  List<Object> get props => [id];
}

final class FilterMoviesEvent extends MovieEvent {
  final String searchParams;

  const FilterMoviesEvent({required this.searchParams});

  @override
  List<Object> get props => [searchParams];
}
