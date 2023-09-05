part of 'search_bloc.dart';

sealed class SearchState extends Equatable {
  const SearchState();

  @override
  List<Object> get props => [];
}

final class SearchInitial extends SearchState {}

class LoadingSearchState extends SearchState {}

class ErrorSearchState extends SearchState {
  final String message;
  const ErrorSearchState({required this.message});
  
}

class SuccessSearchState extends SearchState {
  final List<MovieEntitie> movies;
  const SuccessSearchState({required this.movies});
}
