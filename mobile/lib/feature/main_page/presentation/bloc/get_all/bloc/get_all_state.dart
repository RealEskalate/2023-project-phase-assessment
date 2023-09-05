part of 'get_all_bloc.dart';

sealed class GetAllState extends Equatable {
  const GetAllState();
  
  @override
  List<Object> get props => [];
}

final class GetAllInitial extends GetAllState {}

class LoadingGetAllMovieState extends GetAllState {}

class ErrorGetAllMovieState extends GetAllState {
  final String message;
  const ErrorGetAllMovieState({required this.message});
}

class SuccessGetAllMovieState extends GetAllState {
  final List<MovieEntitie> movies;
  const SuccessGetAllMovieState({required this.movies});
}
