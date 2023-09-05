part of 'search_bloc.dart';

sealed class SearchEvent extends Equatable {
  const SearchEvent();

  @override
  List<Object> get props => [];
}

class SearchEventClick extends SearchEvent {
  final String movieName;

  const SearchEventClick({required this.movieName});
}
