import 'package:bloc/bloc.dart';
import 'package:equatable/equatable.dart';
import 'package:second/feature/main_page/domain/usecase/get_single_movie.dart';

import '../../../../domain/entitie/movie_entite.dart';

part 'get_single_event.dart';
part 'get_single_state.dart';

class GetSingleBloc extends Bloc<GetSingleEvent, GetSingleState> {
  final GetSingleUseCase getSingleUseCase;
  GetSingleBloc({required this.getSingleUseCase}) : super(GetSingleInitial()) {
    on<GetSingleClick>((event, emit) async{
      emit(LoadingSingleState());
      var result = await getSingleUseCase(id: event.id);
      result.fold(
        (l) => ErrorSingleState(message: l.message),
        (r) => SuccessSingleState(movies: r),
      );
    });
  }
}
