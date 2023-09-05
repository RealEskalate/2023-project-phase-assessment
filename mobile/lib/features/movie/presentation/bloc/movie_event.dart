import 'package:equatable/equatable.dart';

import '../../domain/entities/movie.dart';


sealed class MovieEvent extends Equatable {
  const MovieEvent();

  @override
  List<Object?> get props => [];
}

final class LoadAllMoviesEvent extends MovieEvent {}

final class FilterMoviesEvent extends MovieEvent {
  final String searchParams;

  const FilterMoviesEvent(this.searchParams);

  @override
  List<Object?> get props => [searchParams];
}

final class GetSingleMovieEvent extends MovieEvent {
  final String id;

  const GetSingleMovieEvent(this.id);

  @override
  List<Object> get props => [id];
}

final class CreateMovieEvent extends MovieEvent {
  final Movie movie;

  const CreateMovieEvent(this.movie);

  @override
  List<Object?> get props => [movie];
}

