import 'package:flutter/material.dart';

import '../../data/models/movie.dart' as moviemodel;

class savedMovies extends StatelessWidget {
  final List<moviemodel.MovieModel> movies;

  const savedMovies({Key? key, required this.movies}) : super(key: key);
  @override
  Widget build(BuildContext context) {
    return Container(
      padding: const EdgeInsets.only(top: 5, bottom: 20),
      color: Colors.white,
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          const Padding(
            padding: EdgeInsets.all(16.0),
            child: Text(
              'Saved Movies',
              style: TextStyle(
                fontSize: 24.0,
                fontWeight: FontWeight.bold,
              ),
            ),
          ),
          SizedBox(
            height: 240.0,
            child: ListView.builder(
              scrollDirection: Axis.horizontal,
              itemCount:
                  movies.length, // Replace with the number of saved movies
              itemBuilder: (BuildContext context, int index) {
                // Replace with movie data or information
                return MovieCard(
                  title: movies[index].title!,
                  duration: movies[index].duration!,
                  // Replace with image URL or AssetImage
                  image: NetworkImage(movies[index].image!),
                );
              },
            ),
          ),
        ],
      ),
    );
  }
}

class MovieCard extends StatelessWidget {
  final String title;
  final String duration;
  final ImageProvider<Object> image;

  MovieCard({
    required this.title,
    required this.duration,
    required this.image,
  });

  @override
  Widget build(BuildContext context) {
    return Container(
      width: 220.0,
      margin: const EdgeInsets.symmetric(horizontal: 8.0),
      decoration: BoxDecoration(
        borderRadius: BorderRadius.circular(16.0),
        image: DecorationImage(
          image: image,
          fit: BoxFit.cover,
        ),
      ),
      child: Column(
        mainAxisAlignment: MainAxisAlignment.end,
        children: [
          Padding(
            padding: const EdgeInsets.only(left: 15, right: 15, bottom: 10),
            child: Container(
              width: double.infinity,
              padding: const EdgeInsets.all(16.0),
              decoration: const BoxDecoration(
                color: Colors.white,
                borderRadius: BorderRadius.all(
                  Radius.circular(16.0),
                ),
              ),
              child: Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  Text(
                    title,
                    style: const TextStyle(
                      fontSize: 16.0,
                      fontWeight: FontWeight.bold,
                    ),
                  ),
                  Row(
                    children: [
                      const Icon(Icons.star, color: Colors.yellow),
                      const Text('4.5', style: TextStyle(fontSize: 14.0)),
                      const SizedBox(width: 15.0),
                      const Icon(Icons.timelapse, color: Colors.blue),
                      Text(duration),
                    ],
                  ),
                ],
              ),
            ),
          ),
        ],
      ),
    );
  }
}
