part of 'movie_id_bloc.dart';

sealed class MovieIdEvent extends Equatable {
  const MovieIdEvent();

  @override
  List<Object> get props => [];
}

class GiveMeSpecificDetail extends MovieIdEvent {
  final String id;

  GiveMeSpecificDetail({required this.id});
  @override
  List<Object> get props => [id];
}
