import 'package:cached_network_image/cached_network_image.dart';
import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';
import 'package:go_router/go_router.dart';

import '../../../../core/presentation/theme/app_colors.dart';
import '../../domain/entities/movie.dart';

class MovieRowCard extends StatelessWidget {
  final Movie movie;

  const MovieRowCard({required this.movie, Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return GestureDetector(
      child: Container(
        height: 100.h,
        width: 388.w,
        padding: const EdgeInsets.all(10.0),
        decoration: BoxDecoration(
          borderRadius: BorderRadius.circular(20.0),
          color: AppColors.white,
        ),
        child: Row(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            ConstrainedBox(
              constraints: BoxConstraints(maxWidth: 120.w),
              child: MoviePhoto(movie: movie,),
            ),
            SizedBox(width: 20.w),
            ConstrainedBox(
              constraints: BoxConstraints(maxWidth: 140.w),
              child: MovieInfo(movie: movie,),
            ),
          ],
        ),
      ),
      onTap: () async {},
    );
  }
}

class MoviePhoto extends StatelessWidget {
  final Movie movie;

  const MoviePhoto({required this.movie, super.key});

  @override
  Widget build(BuildContext context) {
    return Container(
      width: 100.w,
      height: 100.h,
      child: ClipRRect(
        borderRadius: BorderRadius.circular(15.0),
        child: CachedNetworkImage(imageUrl: movie.image),
      ),
    );
  }
}

class MovieInfo extends StatelessWidget {
  final Movie movie;

  const MovieInfo({required this.movie, super.key});

  @override
  Widget build(BuildContext context) {
    return Container(
      child: Column(children: [
        Text(movie.category),
        Row(
          mainAxisAlignment: MainAxisAlignment.center,
          children: [
            Icon(
              Icons.star,
              color: Colors.yellow,
            ),
            Text(movie.rating.toString()),
            Icon(Icons.access_time),
            Text(movie.duration),
          ],
        )
      ]),
    );
  }
}
