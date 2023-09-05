import 'package:equatable/equatable.dart';
import 'package:mobile/features/example/domain/entities/MovieEntity.dart';


class MovieEvent extends Equatable {
  @override
  List<Object?> get props => [];
}



class GetMovie extends MovieEvent {
  final String id;

  GetMovie({required this.id});

  @override
  List<Object?> get props => [id];
}

class GetAllMovie extends MovieEvent {}