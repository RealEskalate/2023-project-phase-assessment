import 'package:flutter/material.dart';


import '../../domain/entities/movie.dart';
import 'movie_card.dart';


class MovieCardList extends StatelessWidget {
  final List<Movie> movies;

  const MovieCardList({required this.movies, super.key});

  @override
  Widget build(BuildContext context) {
    return SizedBox(
      height: MediaQuery.of(context).size.height * 0.63,
      child: ListView.builder(
        itemCount: movies.length,
        itemBuilder: (context, index) {
          Movie movie = movies[index];
          return Padding(
              padding: const EdgeInsets.only(bottom: 15),
              child: MovieCard(movie: movie));
        },
      ),
    );
  }
}
