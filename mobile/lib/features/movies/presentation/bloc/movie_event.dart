part of 'movie_bloc.dart';

sealed class MovieEvent extends Equatable {
  const MovieEvent();

  @override
  List<Object> get props => [];
}
class GetMoviesEvent extends MovieEvent {
  final String searchParams;
  const GetMoviesEvent({required this.searchParams});
  @override
  List<Object> get props => [searchParams];
}
class SearchMoviesEvent extends MovieEvent {
  final String searchParams;
  const SearchMoviesEvent({required this.searchParams});
  @override
  List<Object> get props => [searchParams];
}
class GetBookMarkedMovieEvent extends MovieEvent {
  const GetBookMarkedMovieEvent();
  @override
  List<Object> get props => [];
}
// class AddBookMarkedMovieEvent extends MovieEvent {
//   final Movie movie;
//   const AddBookMarkedMovieEvent({required this.movie});
//   @override
//   List<Object> get props => [movie];
// }
// class RemoveBookMarkedMovieEvent extends MovieEvent {
//   final Movie movie;
//   const RemoveBookMarkedMovieEvent({required this.movie});
//   @override
//   List<Object> get props => [movie];
// }
// class GetMovieEvent extends MovieEvent {
//   final String id;
//   const GetMovieEvent({required this.id});
//   @override
//   List<Object> get props => [id];
// }