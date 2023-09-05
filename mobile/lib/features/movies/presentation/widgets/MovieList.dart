import 'dart:developer';
import 'package:bloc/bloc.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

import 'package:flutter/material.dart';
import 'package:mobile/features/movies/domain/entities/movie.dart';
import 'package:mobile/features/movies/presentation/bloc/movie_bloc.dart';
import 'package:mobile/features/movies/presentation/bloc/movie_event.dart';
import 'package:mobile/features/movies/presentation/bloc/movie_state.dart';

class SingleMovieList extends StatelessWidget {
  const SingleMovieList(
      {super.key, this.movieTitle = "Movie title", required this.imageUrl});
  final String movieTitle;
  final String imageUrl;

  @override
  Widget build(BuildContext context) {
    // print(imageUrl);
    return GestureDetector(
      onTap: () {
        log("clicked a movie");
        Navigator.pushNamed(context, '/movie-detail');
      },
      child: Container(
        height: 90,
        margin: EdgeInsets.fromLTRB(20, 10, 20, 0),
        decoration: BoxDecoration(
            border: Border.all(
          color: Colors.black,
          width: 2,
        )),
        child: Row(children: [
          Image.network(imageUrl),
          Container(
            margin: EdgeInsets.fromLTRB(20, 0, 0, 0),
            child: Column(
              mainAxisAlignment: MainAxisAlignment.center,
              crossAxisAlignment: CrossAxisAlignment.center,
              children: [
                Text(movieTitle),
                Row(
                  mainAxisSize: MainAxisSize.max,
                  mainAxisAlignment: MainAxisAlignment.spaceBetween,
                  children: [
                    Icon(Icons.star, color: Colors.yellow),
                    Text('4.5'),
                    Icon(Icons.access_time, color: Colors.blue),
                    Text('1 hour'),
                  ],
                )
              ],
            ),
          )
        ]),
      ),
    );
  }
}

class MovieList extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    final movieBloc = MovieBloc();
    log("movie list widget");
    return BlocProvider<MovieBloc>(
        create: (context) => movieBloc,
        child: BlocBuilder<MovieBloc, MovieState>(
          builder: (context, state) {
            if (state is MovieInitial) {
              log("MovieInitial");
              movieBloc..add(GetAllMoviesEvent());
              return Container();
            } else if (state is MovieLoading) {
              log("MovieLoading");
              return Container(
                child: Center(
                  child: CircularProgressIndicator(),
                ),
              );
            } else if (state is AllMoviesLoaded) {
              log("AllMoviesLoaded");
              var movies = state.movies;
              return Column(
                children: [
                  ...[
                    for (Movie movie in movies)
                      SingleMovieList(
                        movieTitle: movie.title ?? "No title",
                        imageUrl: movie.image ?? "",
                      )
                  ]
                ],
              );

              return Text("all movies loaded");
            } else {
              log("Unknown state $state");
              return Container(
                child: Text("Cant load movies"),
              );
            }
          },
        ));
  }
}
