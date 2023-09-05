part of 'homepage_bloc.dart';

abstract class HomepageState extends Equatable {
  const HomepageState();  

  @override
  List<Object> get props => [];
}
class HomepageInitial extends HomepageState {}

class MovieDataLoaded extends HomepageState{
  List<Data> data;
  MovieDataLoaded({required this.data});
}