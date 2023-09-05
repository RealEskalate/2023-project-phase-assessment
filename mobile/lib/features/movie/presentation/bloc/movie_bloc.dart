// ignore_for_file: public_member_api_docs, sort_constructors_first
import 'dart:async';

import 'package:equatable/equatable.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:mobile/core/constants/constants.dart';
import 'package:mobile/features/movie/domain/use_cases/remove_movie_from_bookmark.dart';

import '../../../../core/error/failure.dart';
import '../../domain/entities/movie_entity.dart';
import '../../domain/use_cases/bookmark_movie.dart';
import '../../domain/use_cases/get_all_movies.dart';
import '../../domain/use_cases/get_bookmarked_movies.dart';
import '../../domain/use_cases/get_movie_detail.dart';
import '../../domain/use_cases/search_movie.dart';
import '../../domain/use_cases/use_case.dart';

part 'movie_event.dart';
part 'movie_state.dart';

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

  Future<void> _getAllMoviesEvent(
      GetMoviesEvent event, Emitter<MovieState> emit) async {
    emit(MovieLoadingState());

    final result = await getAllMoviesUseCase(NoParams());

    result.fold(
      (failure) => emit(MovieErrorState(message: _mapErrorToMessage(failure))),
      (movies) => emit(MoviesLoadedState(movies: movies)),
    );
  }

  Future<void> _searchMoviesEvent(
      SearchMoviesEvent event, Emitter<MovieState> emit) async {
    emit(MovieLoadingState());

    final failureOrResult =
        await searchMoviesUseCase(SearchMoviesParams(queryParams: event.query));

    failureOrResult.fold(
      (failure) => emit(MovieErrorState(message: _mapErrorToMessage(failure))),
      (movies) => emit(MoviesLoadedState(movies: movies)),
    );
  }

  Future<void> _getMovieDetailEvent(
      GetMovieDetailEvent event, Emitter<MovieState> emit) async {
    emit(MovieLoadingState());

    final failureOrResult =
        await getMovieDetailUseCase(GetMovieParams(movieId: event.movieId));

    failureOrResult.fold(
      (failure) => emit(MovieErrorState(message: _mapErrorToMessage(failure))),
      (movie) => emit(MovieDetailLoadedState(movie: movie)),
    );
  }

  Future<void> _bookmarkMovieEvent(
      BookmarkMovieEvent event, Emitter<MovieState> emit) async {
    emit(BookmarkedMoviesLoadingState());

    final failureOrResult = await bookmarkMovieUseCase(
        BookmarkMovieParam(movieEntity: event.movie));

    failureOrResult.fold(
      (failure) => emit(MovieErrorState(message: _mapErrorToMessage(failure))),
      (_) => emit(const SuccessState(message: "Movie bookmarked successfully")),
    );
  }

  Future<void> _removeFromBookmarkMovieEvent(
      RemoveFromBookmarkMovieEvent event, Emitter<MovieState> emit) async {
    emit(BookmarkedMoviesLoadingState());

    final failureOrResult = await removeFromBookmarkMovieUseCase(
        RemoveFromBookmarkMovieParam(movieEntity: event.movieEntity));

    failureOrResult.fold(
      (failure) => emit(MovieErrorState(message: _mapErrorToMessage(failure))),
      (_) => emit(const SuccessState(
          message: "Movie removed from bookmark successfully")),
    );
  }

  Future<void> _getBookmarkedMoviesEvent(
      GetBookmarkedMoviesEvent event, Emitter<MovieState> emit) async {
    emit(BookmarkedMoviesLoadingState());

    final failureOrResult = await getBookmarkedMoviesUseCase(NoParams());

    failureOrResult.fold(
      (failure) => emit(MovieErrorState(message: _mapErrorToMessage(failure))),
      (movies) => emit(MovieBookmarkedLoadedState(movies: movies)),
    );
  }

  String _mapErrorToMessage(Failure failure) {
    switch (failure.runtimeType) {
      case ServerFailure:
        return ErrorMessages.SERVER_FAILURE_MESSAGE;

      case InvalidResponseFormatFailure:
        return ErrorMessages.INVALID_RESPONSE_FROMAT_MESSAGE;

      case NetworkFailure:
        return ErrorMessages.NETWORK_FAILURE_MESSAGE;
      case CacheFailure:
        return ErrorMessages.CACHE_FAILURE_MESSAGE;
      default:
        return ErrorMessages.UNKNOWN_FAILURE_MESSAGE;
    }
  }
}
