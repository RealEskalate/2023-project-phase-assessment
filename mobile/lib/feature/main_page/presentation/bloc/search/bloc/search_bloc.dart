import 'package:bloc/bloc.dart';
import 'package:equatable/equatable.dart';
import 'package:second/feature/main_page/domain/entitie/movie_entite.dart';

import '../../../../domain/usecase/search_usecase.dart';

part 'search_event.dart';
part 'search_state.dart';

class SearchBloc extends Bloc<SearchEvent, SearchState> {
  final GetSearchUseCase getSearchUseCase;
  SearchBloc({required this.getSearchUseCase}) : super(SearchInitial()) {
    on<SearchEventClick>((event, emit) async {
      emit(LoadingSearchState());
      var result = await getSearchUseCase(movieName: event.movieName);
      result.fold(
        (l) => ErrorSearchState(message: l.message),
        (r) => SuccessSearchState(movies: r),
      );
    });
  }
}
