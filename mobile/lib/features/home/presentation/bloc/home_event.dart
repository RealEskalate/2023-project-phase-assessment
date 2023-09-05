part of 'home_bloc.dart';

abstract class HomeEvent extends Equatable {
  const HomeEvent();

  @override
  List<Object> get props => [];
}

class GetAllMovies extends HomeEvent {}

class SearchMovies extends HomeEvent {
  final String term;
  SearchMovies({required this.term});
}
