part of 'movie_bloc.dart';

sealed class MovieEvent extends Equatable {
  const MovieEvent();

  @override
  List<Object> get props => [];
}

class GiveMeData extends MovieEvent {}


class GiveMeSearchedData extends MovieEvent {
  final String searchParams;

  GiveMeSearchedData({required this.searchParams});
}
