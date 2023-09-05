import 'package:bloc/bloc.dart';
import 'package:equatable/equatable.dart';
import 'package:second/feature/main_page/domain/usecase/get_all_movie_usecase.dart';

import '../../../../domain/entitie/movie_entite.dart';

part 'get_all_event.dart';
part 'get_all_state.dart';

class GetAllBloc extends Bloc<GetAllEvent, GetAllState> {
  final GetAllMoviesUseCase getAllMoviesUseCase;
  GetAllBloc({required this.getAllMoviesUseCase}) : super(GetAllInitial()) {
    on<GetAllEvent>((event, emit) async {
      emit(LoadingGetAllMovieState());
      var result = await getAllMoviesUseCase();
      result.fold(
        (l) => ErrorGetAllMovieState(message: l.message),
        (r) => SuccessGetAllMovieState(movies: r),
      );
    });
  }
}
