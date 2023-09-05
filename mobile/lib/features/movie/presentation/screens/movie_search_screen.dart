import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

import '../../../../core/presentation/theme/app_colors.dart';
import '../../../../core/presentation/theme/app_theme.dart';
import '../../domain/entities/movie.dart';
import '../widgets/movie_card.dart';
import '../widgets/search_bar.dart';

class MoviesSearchScreen extends StatelessWidget {
  const MoviesSearchScreen({super.key});

  @override
  Widget build(BuildContext context) {
    // dummy
    final movie = Movie(
      id: 'appleadjkfhavbvufaui',
      title: 'The Dark Knight',
      image:
          'https://fastly.picsum.photos/id/1/200/300.jpg?hmac=jH5bDkLr6Tgy3oAg5khKCHeunZMHq0ehBZr6vGifPLY',
      rating: 9.0,
      createdAt: DateTime.now(),
      description: 'This is supposed to be description',
      duration: '2h 35min',
      category: 'Action',
    );

    return Scaffold(
      backgroundColor: AppColors.white.withAlpha(240),
      appBar: AppBar(
        backgroundColor: Theme.of(context).colorScheme.background,
        elevation: 0,
        title: Center(
          child: Text('Alem Cinema',
              style: Theme.of(context).textTheme.titleMedium),
        ),
      ),
      body: SingleChildScrollView(
        child: Padding(
          padding: const EdgeInsets.symmetric(vertical: 30, horizontal: 20),
          child: Column(
            children: [
              // Search bar
              CustomSearchBar(),
              SizedBox(height: 20.h),

              const SizedBox(
                height: 25,
              ),

              // All movies list
              SizedBox(
                width: AppDimensions.width,
                height: (AppDimensions.height - 180).h,
                child: ListView.builder(
                  itemCount: 10,
                  itemBuilder: (context, index) {
                    return Padding(
                      padding: const EdgeInsets.fromLTRB(0, 10, 0, 10),
                      child: MovieCard(
                        movie: movie,
                      ),
                    );
                  },
                ),
              ),
            ],
          ),
        ),
      ),
    );
  }
}
