part of 'home_bloc.dart';

abstract class HomeState extends Equatable {
  const HomeState();

  @override
  List<Object> get props => [];
}

class HomeInitial extends HomeState {}

class Loading extends HomeState {}

class Error extends HomeState {
  String message;
  Error({this.message = ""});
}

class Loaded extends HomeState {
  List<Movie> movies;
  Loaded({required this.movies});
}
