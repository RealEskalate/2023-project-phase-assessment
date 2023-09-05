import 'package:cached_network_image/cached_network_image.dart';
import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

import '../../../../core/presentation/theme/app_colors.dart';
import '../../../../core/presentation/theme/app_theme.dart';
import '../../domain/entities/movie.dart';

class MovieDetailScreen extends StatelessWidget {
  final Movie? movie;

  const MovieDetailScreen({super.key, this.movie});

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
          child: Text('Detail', style: Theme.of(context).textTheme.titleMedium),
        ),
      ),
      body: SingleChildScrollView(
        child: Padding(
          padding: const EdgeInsets.symmetric(vertical: 30, horizontal: 20),
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            mainAxisAlignment: MainAxisAlignment.start,
            children: [
              Container(
                clipBehavior: Clip.hardEdge,
                decoration: const BoxDecoration(
                  borderRadius: BorderRadius.all(
                    Radius.circular(20),
                  ),
                ),
                width: AppDimensions.width.w,
                height: (AppDimensions.height * .5).h,
                child: CachedNetworkImage(
                    imageUrl: movie.image,
                    fit: BoxFit.cover,
                    width: AppDimensions.width.w,
                    height: (AppDimensions.height * .4).h),
              ),

              //
              SizedBox(height: 20.h),

              // title
              Padding(
                padding: const EdgeInsets.all(10),
                child: Text(
                  movie.title,
                  textAlign: TextAlign.start,
                  style: Theme.of(context).textTheme.titleLarge,
                ),
              ),

              // summary
              Row(
                children: [
                  const Icon(Icons.access_time, color: AppColors.blue),
                  SizedBox(width: 5.w),
                  Text(movie.duration),
                  SizedBox(width: 5.w),
                  const Text('|'),
                  SizedBox(width: 5.w),
                  Text(movie.category),
                ],
              ),

              SizedBox(height: 10.h),

              // Description
              Text(movie.description),

              SizedBox(height: 30.h),

              // watch now
              SizedBox(
                  width: AppDimensions.width,
                  height: 60.h,
                  child: ElevatedButton(
                    onPressed: () {},
                    child: const Text('Watch Now'),
                  ))
            ],
          ),
        ),
      ),
    );
  }
}
