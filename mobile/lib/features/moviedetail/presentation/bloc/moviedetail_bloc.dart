import 'package:bloc/bloc.dart';
import 'package:equatable/equatable.dart';

part 'moviedetail_event.dart';
part 'moviedetail_state.dart';

class MoviedetailBloc extends Bloc<MoviedetailEvent, MoviedetailState> {
  MoviedetailBloc() : super(MoviedetailInitial()) {
    on<MoviedetailEvent>((event, emit) {
      // TODO: implement event handler
    });
  }
}
