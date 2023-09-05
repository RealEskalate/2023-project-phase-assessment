part of 'get_movies_bloc.dart';

sealed class GetMoviesEvent extends Equatable {
  const GetMoviesEvent();

  @override
  List<Object> get props => [];
}


class GetAllMovie extends GetMoviesEvent {}
class AppStarted extends GetMoviesEvent {}
class GetStarted extends GetMoviesEvent{}

