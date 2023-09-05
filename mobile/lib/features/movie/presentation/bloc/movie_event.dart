part of 'movie_bloc.dart';

sealed class MovieEvent extends Equatable {
  const MovieEvent();

  @override
  List<Object> get props => [];
}

class GetAllMoviesEvent extends MovieEvent {
  final String? searchQuery;

   GetAllMoviesEvent({this.searchQuery = "" });
}