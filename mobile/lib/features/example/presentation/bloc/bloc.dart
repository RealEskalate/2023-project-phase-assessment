import 'dart:developer';

import 'package:dartz/dartz.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:mobile/features/example/presentation/bloc/add_bookmark/add_bookmark_state.dart';
import '../../data/models/movie.dart' as moviemodel;

import '../../../../core/error/failure.dart';
import '../../domain/entities/movie.dart';
import '../../domain/usecases/add_bookmark.dart';
import '../../domain/usecases/get_all_bookmarks.dart';
import '../../domain/usecases/get_all_movies.dart';
import '../../domain/usecases/get_single_movies.dart';
import 'add_bookmark/add_bookmark_event.dart';
import 'bloc_event.dart';
import 'bloc_state.dart';
import 'get_bookmark/get_bookmark_event.dart';
import 'get_bookmark/get_bookmark_state.dart';

class MoviesBloc extends Bloc<MovieEvent, MoviesState> {
  final GetMoviesUseCase getAllMovies;
  final GetSingleMovieUseCase getSingleMovie;
  final GetBookmarkUseCase getBookmark;
  final AddBookmarkUseCase addBookmark;

  MoviesBloc({
    required this.getAllMovies,
    required this.getSingleMovie,
    required this.getBookmark,
    required this.addBookmark,
  }) : super(MoviesInitial()) {
    on<GetAllMoviesEvent>((event, emit) async {
      emit(MoviesLoading());

      try {
        final Either<Failure, List<Movie>> result = await getAllMovies();
        emit(result.fold(
          (failure) => MoviesError(_mapFailureToMessage(failure)),
          (articles) => LoadedGetMoviesState(articles),
        ));
      } catch (e) {
        emit(MoviesError(_mapFailureToMessage(
            const ServerFailure('Error fetching movies'))));
      }
    });
    on<GetBookmarksEvent>((event, emit) async {
      emit(BookmarkLoading());

      try {
        log("bookmark bloc started");
        final Either<Failure, List<moviemodel.MovieModel>> result =
            await getBookmark();
        emit(result.fold(
          (failure) => BookmarkError(_mapFailureToMessage(failure)),
          (articles) => LoadedBookmarksState(articles),
        ));
      } catch (e) {
        emit(BookmarkError(_mapFailureToMessage(
            const ServerFailure('Error fetching bookmark'))));
      }
    });

    // add bookmark
    on<AddBookmarkEvent>((event, emit) async {
      emit(BookmarkLoading());

      try {
        final Either<Failure, bool> isAdded =
            await addBookmark(AddBookmarkParams(
          id: event.id,
          title: event.title,
          category: event.category,
          description: event.description,
          duration: event.duration,
          image: event.image,
          rating: event.rating,
          createdAt: event.createdAt,
        ));
        emit(isAdded.fold(
          (failure) => AddBookmarkError(_mapFailureToMessage(failure)),
          (isAdded) => AddedBookmarkState(isAdded),
        ));
      } catch (e) {
        emit(BookmarkError(_mapFailureToMessage(
            const ServerFailure('Error adding bookmark'))));
      }
    });
  }
  String _mapFailureToMessage(Failure failure) {
    return 'An error occurred: $failure';
  }
}
