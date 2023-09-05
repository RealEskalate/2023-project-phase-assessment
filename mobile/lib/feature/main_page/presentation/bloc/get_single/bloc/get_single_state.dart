part of 'get_single_bloc.dart';

sealed class GetSingleState extends Equatable {
  const GetSingleState();
  
  @override
  List<Object> get props => [];
}

final class GetSingleInitial extends GetSingleState {}

class LoadingSingleState extends GetSingleState {}

class ErrorSingleState extends GetSingleState {
  final String message;
  const ErrorSingleState({required this.message});
  
}

class SuccessSingleState extends GetSingleState {
  final MovieEntitie movies;
  const SuccessSingleState({required this.movies});
}