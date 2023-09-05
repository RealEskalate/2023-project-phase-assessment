import 'package:equatable/equatable.dart';
import 'package:mobile/features/example/domain/entities/MovieEntity.dart';

class MovieState extends Equatable {
  @override
  List<Object?> get props => [];
}

class Initial extends MovieState {}

class Loading extends MovieState {}





class Deleted extends MovieState {}

class ViewAll extends MovieState {
  final List<MovieEntity> movies;

  ViewAll({required this.movies});

  @override
  List<Object?> get props => [movies];
}

class ViewOne extends MovieState {
  final MovieEntity movie;

  ViewOne({required this.movie});

  @override
  List<Object?> get props => [movie];
}

class Error extends MovieState {
  final String message;

  Error({required this.message});

  @override
  List<Object?> get props => [message];
}