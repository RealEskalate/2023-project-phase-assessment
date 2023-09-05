// ignore_for_file: public_member_api_docs, sort_constructors_first
import 'dart:async';

import 'package:equatable/equatable.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:mobile/core/error/failure.dart';
import 'package:mobile/core/utils/input_converter.dart';

import '../../domain/entities/movie_entity.dart';
import '../../domain/use_cases/use_case.dart';

part 'movie_event.dart';
part 'movie_state.dart';

const String INVALID_INPUT_FAILURE_MESSAGE =
    'Invalid input - the number must be a positive integer or zero';
const String SERVER_FAILURE_MESSAGE = 'Server Failure';
const String CACHE_FAILURE_MESSAGE = 'Cache Failure';
const String DATA_BASE_FAILURE_MESSAGE = "Database Failure";
const String LOCATION_FAILURE_MESSAGE = "Location Failure";
const String CONNECTION_FAILURE_MESSAGE = "Connection Failure";
const String PERMISSION_FAILURE_MESSAGE = "Permission Failure";

class MovieBloc extends Bloc<MovieEvent, MovieState> {
  final GetAllMoviesUseCase getAllMoviesUseCase;
  final GetMovieDetailUseCase getMovieDetailUseCase;

  final SearchMoviesUseCase searchMoviesUseCase;

  final BookmarkMovieUseCase bookmarkMovieUseCase;
  final RemoveFromBookmarkMovieUseCase removeFromBookmarkMovieUseCase;
  final GetBookmarkedMoviesUseCase getBookmarkedMoviesUseCase;

  MovieBloc({
    required this.getAllMoviesUseCase,
    required this.getMovieDetailUseCase,
    required this.searchMoviesUseCase,
    required this.bookmarkMovieUseCase,
    required this.removeFromBookmarkMovieUseCase,
    required this.getBookmarkedMoviesUseCase,
  }) : super(MovieInitialState()) {
    on<GetMoviesEvent>(_getAllMoviesEvent);
    on<SearchMoviesEvent>(_searchMoviesEvent);
    on<GetMovieDetailEvent>(_getMovieDetailEvent);
    on<BookmarkMovieEvent>(_bookmarkMovieEvent);
    on<RemoveFromBookmarkMovieEvent>(_removeFromBookmarkMovieEvent);
    on<GetBookmarkedMoviesEvent>(_getBookmarkedMoviesEvent);
  }

  FutureOr<void> _getAllMoviesEvent(
      GetMoviesEvent event, Emitter<MovieState> emit) async {
    emit(AllMovieLoadingState());

    final result = await getAllMoviesUseCase(NoParams());
    result.fold(
        (failure) =>
            emit(MovieErrorState(message: _mapFailureToMessage(failure))),
        (movie) => emit(MoviesLoadedState(movies: movie)));
  }

  FutureOr<void> _searchMoviesEvent(
      SearchMoviesEvent event, Emitter<MovieState> emit) async {
    emit(SearchMoviesLoadingState());

    final result =
        await searchMoviesUseCase(SearchMoviesParams(queryParams: event.query));
    result.fold(
        (failure) =>
            emit(MovieErrorState(message: _mapFailureToMessage(failure))),
        (movie) => emit(MoviesLoadedState(movies: movie)));
  }

  FutureOr<void> _getMovieDetailEvent(
      GetMovieDetailEvent event, Emitter<MovieState> emit) async {
    emit(GetMovieLoadingState());
    final result =
        await getMovieDetailUseCase(GetMovieParams(movieId: event.movieId));
    result.fold(
        (failure) =>
            emit(MovieErrorState(message: _mapFailureToMessage(failure))),
        (movie) => emit(MovieDetailLoadedState(movie: movie)));
  }

  FutureOr<void> _bookmarkMovieEvent(
      BookmarkMovieEvent event, Emitter<MovieState> emit) async {
    final result = await bookmarkMovieUseCase(
        BookmarkMovieParam(movieEntity: event.movie));
    result.fold(
        (failure) =>
            emit(MovieErrorState(message: _mapFailureToMessage(failure))),
        (r) => emit(const SucessState(message: "BookMarked")));
  }

  FutureOr<void> _removeFromBookmarkMovieEvent(
      RemoveFromBookmarkMovieEvent event, Emitter<MovieState> emit) async {
    final result = await removeFromBookmarkMovieUseCase(
        BookmarkMovieParam(movieEntity: event.movieEntity));

    result.fold(
        (failure) =>
            emit(MovieErrorState(message: _mapFailureToMessage(failure))),
        (r) => emit(const SucessState(message: "book mark removed")));
  }

  FutureOr<void> _getBookmarkedMoviesEvent(
      GetBookmarkedMoviesEvent event, Emitter<MovieState> emit) async {
    emit(SavedMovieLoadingState());
    final result = await getBookmarkedMoviesUseCase(NoParams());

    result.fold(
        (failure) =>
            emit(MovieErrorState(message: _mapFailureToMessage(failure))),
        (book_mark_movie) =>
            emit(MovieBookmarkedLoadedState(movies: book_mark_movie)));
  }
}

String _mapFailureToMessage(Failure failure) {
  switch (failure.runtimeType) {
    case ServerFailure:
      return SERVER_FAILURE_MESSAGE;
    case CacheFailure:
      return CACHE_FAILURE_MESSAGE;
    case InvalidInputFailure:
      return INVALID_INPUT_FAILURE_MESSAGE;

    case ConnectionFailure:
      return CONNECTION_FAILURE_MESSAGE;
    case DatabaseFailure:
      return DATA_BASE_FAILURE_MESSAGE;
    case LocationFailure:
      return LOCATION_FAILURE_MESSAGE;
    case PermissionFailure:
      return PERMISSION_FAILURE_MESSAGE;

    default:
      return 'Unexpected error';
  }
}
