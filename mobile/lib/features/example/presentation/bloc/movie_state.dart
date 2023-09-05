part of 'movie_bloc.dart';

@immutable
sealed class MovieState {}

final class MovieInitial extends MovieState {}

class MovieLoading extends MovieState{

}
class MovieFailed extends MovieState{

}

class MovieLoadedAll extends MovieState{
  final List<MovieModel> movie;
  MovieLoadedAll({required this.movie});
}

class MovieLoadedSearch extends MovieState{
  final List<MovieModel> movie;
  MovieLoadedSearch({required this.movie});
}
