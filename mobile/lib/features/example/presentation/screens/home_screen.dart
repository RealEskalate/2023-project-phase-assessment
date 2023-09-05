import 'dart:developer';
import 'package:animated_text_kit/animated_text_kit.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:mobile/features/example/presentation/bloc/bloc_event.dart';
import 'package:mobile/features/example/presentation/bloc/bloc_state.dart';
import '../../data/models/movie.dart' as moviemodel;

import '../../domain/entities/movie.dart';
import '../bloc/bloc.dart';
import '../bloc/get_bookmark/get_bookmark_event.dart';
import '../bloc/get_bookmark/get_bookmark_state.dart';
import '../widgets/all_movies_list.dart';
import '../widgets/saved_movies.dart';
import '../widgets/search_bar.dart';

class HomeScreen extends StatefulWidget {
  const HomeScreen({super.key});

  @override
  State<HomeScreen> createState() => _HomeScreenState();
}

class _HomeScreenState extends State<HomeScreen> {
  List<Movie> movies = [];
  List<moviemodel.MovieModel> bookmarkedMovies = [];
  bool _isDisposed = false; // Flag to track widget disposal

  @override
  void initState() {
    super.initState();
    // movies
    context.read<MoviesBloc>().add(const GetAllMoviesEvent());
    context.read<MoviesBloc>().stream.listen((state) {
      if (!_isDisposed) {
        if (state is MoviesLoading) {
          log("Loading Movies..");
        }
        if (state is LoadedGetMoviesState) {
          log("Movies are fetched ${state.movies.length}");
          setState(() {
            movies = state.movies!;
          });
        }
        if (state is MoviesError) {
          log("Error ${state.errorMessage}");
        }
      }
    });

    // bookmarks
    context.read<MoviesBloc>().add(const GetBookmarksEvent());
    context.read<MoviesBloc>().stream.listen((state) {
      if (!_isDisposed) {
        if (state is BookmarkLoading) {
          log("Loading Bookmarks..");
        }
        if (state is LoadedBookmarksState) {
          log("Bookmarks are fetched ${state.movie.length}");
          setState(() {
            bookmarkedMovies = state.movie;
          });
        }
        if (state is BookmarkError) {
          log("Error ${state.errorMessage}");
        }
      }
    });
  }

  @override
  Widget build(BuildContext context) {
    return RefreshIndicator(
      onRefresh: () async {
        context.read<MoviesBloc>().add(const GetAllMoviesEvent());
        context.read<MoviesBloc>().add(const GetBookmarksEvent());
      },
      child: Scaffold(
        backgroundColor: const Color(0xffF8FAFF),
        appBar: AppBar(
          leading: IconButton(
            icon: const Icon(
              Icons.arrow_back_ios_new,
              color: Colors.black,
              size: 45,
            ),
            onPressed: () {
              // move to 'onboarding' screen
              Navigator.pushNamed(context, '/onboarding');
            },
          ),
          backgroundColor: const Color(0xffF8FAFF),
          title: Center(
            child: Column(
              children: [
                AnimatedTextKit(
                  animatedTexts: [
                    TyperAnimatedText(
                      "Alem Cinima  ",
                      textStyle: const TextStyle(
                        fontFamily: 'Poppins-SemiBold',
                        fontWeight: FontWeight.bold,
                        color: Colors.black,
                      ),
                    ),
                  ],
                  onTap: () {
                    log("Tap Event");
                  },
                  pause: const Duration(milliseconds: 1000),
                  stopPauseOnTap: true,
                  isRepeatingAnimation: false,
                  totalRepeatCount: 3,
                  repeatForever: false,
                ),

                const SizedBox(height: 10), // Add some spacing between lines
              ],
            ),
          ),
          toolbarHeight: 80,
        ),
        body: SingleChildScrollView(
          child: Container(
              decoration: const BoxDecoration(
                color: Color(0xffF8FAFF),
              ),
              child: Column(children: [
                GestureDetector(
                    onTap: () {
                      Navigator.pushReplacementNamed(context, '/search');
                    },
                    child: searchBar(context)),
                savedMovies(movies: bookmarkedMovies),
                allMovies(movies: movies)
              ])),
        ),
      ),
    );
  }

  @override
  void dispose() {
    _isDisposed = true;
    super.dispose();
  }
}
