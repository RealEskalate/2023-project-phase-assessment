part of 'get_single_bloc.dart';

sealed class GetSingleEvent extends Equatable {
  const GetSingleEvent();

  @override
  List<Object> get props => [];
}

class GetSingleClick extends GetSingleEvent{
  final String id;

  const GetSingleClick({required this.id});
  
}
