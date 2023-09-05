import 'package:flutter/material.dart';

import '../../domain/entities/movie.dart';
import '../screens/movie_detail.dart';

class allMovies extends StatelessWidget {
  final List<Movie> movies;

  const allMovies({Key? key, required this.movies}) : super(key: key);
  @override
  Widget build(BuildContext context) {
    return Container(
      height: 300,
      padding: const EdgeInsets.only(top: 5, bottom: 5),
      color: Colors.white,
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          const Padding(
            padding: EdgeInsets.all(16.0),
            child: Text(
              'All Movies',
              style: TextStyle(
                fontSize: 24.0,
                fontWeight: FontWeight.bold,
              ),
            ),
          ),
          Flexible(
            fit: FlexFit.loose, // Use FlexFit.loose for flexible children
            child: ListView.builder(
              itemCount: movies.length, // Replace with the number of movies
              itemBuilder: (BuildContext context, int index) {
                // Replace with movie data or information
                return MovieCard(
                  title: movies[index].title!,
                  duration: movies[index].duration!,
                  image: NetworkImage(movies[index].image!),
                  movie: movies[index],
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
  final Movie movie;
  final ImageProvider<Object> image;

  const MovieCard({
    required this.title,
    required this.duration,
    required this.image,
    required this.movie,
  });

  @override
  Widget build(BuildContext context) {
    return GestureDetector(
      onTap: () {
        // Navigate to movie detail screen by passing movie data
        Navigator.push(
          context,
          MaterialPageRoute(
            builder: (context) => MovieDetailRoute(
              movie: movie,
            ),
          ),
        );
      },
      child: Card(
        surfaceTintColor: Colors.white,
        margin: const EdgeInsets.all(16.0),
        elevation: 1.0,
        child: Row(
          children: [
            Container(
              width: 100.0,
              height: 70.0,
              decoration: BoxDecoration(
                image: DecorationImage(
                  image: image,
                  fit: BoxFit.cover,
                ),
              ),
            ),
            Expanded(
              child: Padding(
                padding: const EdgeInsets.all(16.0),
                child: Column(
                  crossAxisAlignment: CrossAxisAlignment.start,
                  children: [
                    Text(
                      title,
                      style: const TextStyle(
                        fontSize: 18.0,
                        fontWeight: FontWeight.bold,
                      ),
                    ),
                    Row(
                      children: [
                        const Icon(Icons.star, color: Colors.yellow),
                        const SizedBox(width: 8.0),
                        Text(duration),
                      ],
                    ),
                  ],
                ),
              ),
            ),
          ],
        ),
      ),
    );
  }
}
