part of 'movie_id_bloc.dart';

sealed class MovieIdState extends Equatable {
  const MovieIdState();

  @override
  List<Object> get props => [];
}

final class MovieIdInitial extends MovieIdState {}

final class MovieIdLoaded extends MovieIdState {
  final Movie movie;

  MovieIdLoaded({required this.movie});
  @override
  List<Object> get props => [movie];
}
