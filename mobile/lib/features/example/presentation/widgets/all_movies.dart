
import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';
import 'package:mobile/features/example/domain/entities/movie.dart';
import 'package:mobile/features/example/presentation/widgets/movie_card.dart';

class AllMovies extends StatelessWidget {
  final List<Movie> movies;
  final Function(String) onMovieSelect;
  const AllMovies({
    super.key,
    required this.movies,
    required this.onMovieSelect,
  });

  @override
  Widget build(BuildContext context) {
    return Column(
      children: [
        Container(
          alignment: Alignment.centerLeft,
          padding: EdgeInsets.symmetric(horizontal: 8.w, vertical: 8.h),
          color: Colors.white,
          child: Text(
            "All Movies",
            style: TextStyle(
              fontWeight: FontWeight.w400,
              fontSize: 20,
            ),
          ),
        ),
        SizedBox(
          height: 20.h,
        ),
        Container(
          height: 120.h,
          child: ListView.builder(
            itemCount: movies.length,
            itemBuilder: (context, index) => Column(
              children: [
                MovieCard(
                    movie: movies[index],
                    onMovieSelect: () {
                      onMovieSelect(movies[index].id);
                    }),
                SizedBox(
                  height: 20.h,
                ),
              ],
            ),
          ),
        )
      ],
    );
  }
}