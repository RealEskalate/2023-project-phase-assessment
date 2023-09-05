import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';
import 'package:go_router/go_router.dart';
import 'package:mobile/features/example/domain/entities/movie.dart';
import 'package:mobile/features/example/presentation/widgets/all_movies.dart';
import 'package:mobile/features/example/presentation/widgets/bookmark_movies.dart';
import 'package:mobile/features/example/presentation/widgets/search_bar.dart';

class HomeScreen extends StatelessWidget {
  const HomeScreen();

  @override
  Widget build(BuildContext context) {
    final List<Movie> movie = [
      Movie(
        title: "Oppenheimer",
        rating: 4.5,
        image: "assets/images/oppenheimer.jpg",
        duration: "1h 31m",
        description: "Bla bla bla",
        id: "vhbfjdvbjkdkfbsdjkvbcjkvbjkvbfjvkbjk",
      ),
      Movie(
        title: "Spider-Man: Across The Spider Verse",
        rating: 9.2,
        image: "assets/images/spider_man.jpg",
        duration: "3h 1m",
        description: "gvbcjkdfjnvcsadfjdnasnerfgvmc zs",
        id: "gvhcxnsdfvcxjnmsdnfsvjxcbn mas",
      ),
      Movie(
        title: "Tom Hanks",
        rating: 5,
        image: "assets/images/man_called_otto.jpg",
        duration: "2hr 20m",
        description: "hello",
        id: "gddsgbnvaWGFNWngfj",
      )
    ];
    return Scaffold(
      appBar: AppBar(
        leading: BackButton(
          onPressed: () => context.pop(),
          color: Colors.black,
        ),
        title: Text(
          "Alem Cinema",
          style: TextStyle(color: Colors.black),
        ),
        backgroundColor: Colors.white,
        elevation: 0,
      ),
      body: SingleChildScrollView(
        child: Column(
          children: [
            SizedBox(
              height: 20.h,
            ),
            SearchBarWidget(),
            SizedBox(
              height: 20.h,
            ),
            Container(
              color: Colors.white,
              width: double.infinity,
              padding: EdgeInsets.symmetric(horizontal: 8.w, vertical: 8.h),
              child: BookmarkMovies(
                movies: movie,
                onMovieSelect: (movieId) {
                  context.push('/description', extra: movieId);
                },
              ),
            ),
            SizedBox(
              height: 15.h,
            ),
            AllMovies(
              movies: movie,
              onMovieSelect: (movieId) {
                context.push('/description', extra: movieId);
              },
            )
          ],
        ),
      ),
    );
  }
}
