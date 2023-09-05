import 'package:flutter/material.dart';
import 'package:mobile/features/home/presentation/widgets/saved_movie_card.dart';
import '../../../movie_detail/presentation/pages/movie_detail.dart';
import '../../domain/entities/movie.dart';

class SavedMovies extends StatefulWidget {
  const SavedMovies({super.key, required this.movies});
  final List<Movie> movies;

  @override
  State<SavedMovies> createState() => _SavedMoviesState();
}

class _SavedMoviesState extends State<SavedMovies> {
  @override
  Widget build(BuildContext context) {
    return Column(
      crossAxisAlignment: CrossAxisAlignment.start,
      children: [
        Container(
            margin: EdgeInsets.only(left: 20, bottom: 10),
            child: Text(
              "Saved Movies",
              style: TextStyle(fontSize: 24, fontWeight: FontWeight.w500),
            )),
        Container(
          width: double.infinity,
          margin: EdgeInsets.symmetric(vertical: 15),
          height: 300,
          child: ListView.builder(
              scrollDirection: Axis.horizontal,
              itemCount: widget.movies.length,
              itemBuilder: (context, index) {
                return GestureDetector(
                  onTap: () {
                    Navigator.push(
                        context,
                        MaterialPageRoute(
                            builder: (context) => MovieDetail(
                                  movie: widget.movies[index],
                                )));
                  },
                  child: SavedMovieCard(
                    movie: widget.movies[index],
                  ),
                );
              }),
        ),
      ],
    );
  }
}
