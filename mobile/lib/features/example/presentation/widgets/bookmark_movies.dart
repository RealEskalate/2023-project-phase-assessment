import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';
import 'package:mobile/features/example/domain/entities/movie.dart';
import 'package:mobile/features/example/presentation/widgets/bookmark_movie_card.dart';

class BookmarkMovies extends StatelessWidget {
  final List<Movie> movies;
  final Function(String) onMovieSelect;
  BookmarkMovies({
    super.key,
    required this.movies,
    required this.onMovieSelect,
  });

  @override
  Widget build(BuildContext context) {
    return Container(
      child: Column(
        children: [
          Container(
            color: Colors.white,
            child: Row(
              children: [
                SizedBox(
                  width: 10.w,
                ),
                Text(
                  "Saved Movies",
                  style: TextStyle(fontWeight: FontWeight.w400, fontSize: 20),
                ),
                SizedBox(
                  width: 10.w,
                ),
                Icon(
                  Icons.bookmark_outline,
                  color: Colors.blue,
                  size: 24,
                )
              ],
            ),
          ),
          SizedBox(
            height: 20.h,
          ),
          Container(
            height: 300.h,
            child: ListView.builder(
              scrollDirection: Axis.horizontal,
              itemCount: movies.length,
              itemBuilder: (context, index) {
                return Row(
                  children: [
                    BookmarkMovieCard(
                        movie: movies[index],
                        onMovieSelect: () {
                          onMovieSelect(movies[index].id);
                        }),
                    SizedBox(
                      width: 10.w,
                    ),
                  ],
                );
              },
            ),
          ),
        ],
      ),
    );
  }
}
