import 'package:cached_network_image/cached_network_image.dart';
import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

import '../../../../core/presentation/theme/app_colors.dart';
import '../../domain/entities/movie.dart';

class MovieCard extends StatelessWidget {
  final Movie movie;

  const MovieCard({required this.movie, super.key});

  @override
  Widget build(BuildContext context) {
    return Container(
      height: 300.h,
      decoration: BoxDecoration(
          color: AppColors.gray200, borderRadius: BorderRadius.circular(20.0)),
      padding: const EdgeInsets.all(10.0),
      child: Stack(
        alignment: Alignment.centerLeft,
        children: [
          ClipRRect(
            borderRadius: BorderRadius.circular(10.0),
            child: ClipRRect(
              borderRadius: BorderRadius.circular(10.0),
              child: CachedNetworkImage(
                imageUrl: movie.image,
                fit: BoxFit.cover,
              ),
            ),
          ),
          Container(
            width: 200.w,
            height: 50.h,
            decoration: BoxDecoration(
                color: AppColors.white,
                borderRadius: BorderRadius.circular(15.0)),
            child:
                Column(crossAxisAlignment: CrossAxisAlignment.start, children: [
              Center(child: Text(movie.category)),
              Row(
                mainAxisAlignment: MainAxisAlignment.center,
                children: [
                  const Icon(
                    Icons.star,
                    color: Colors.yellow,
                  ),
                  Text(movie.rating.toString()),
                  const Icon(Icons.access_time),
                  Text(movie.duration)
                ],
              )
            ]),
          )
        ],
      ),
    );
  }
}
