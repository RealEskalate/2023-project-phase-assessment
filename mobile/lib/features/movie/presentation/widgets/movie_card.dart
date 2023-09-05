import 'package:cached_network_image/cached_network_image.dart';
import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

import '../../../../core/presentation/theme/app_colors.dart';
import '../../../../core/presentation/theme/app_theme.dart';
import '../../domain/entities/movie.dart';
import 'movie_summary_card.dart';

class MovieCard extends StatelessWidget {
  final Movie movie;
  const MovieCard({super.key, required this.movie});

  @override
  Widget build(BuildContext context) {
    final height = 120.h;

    return Container(
      width: AppDimensions.width,
      height: height,
      decoration: const BoxDecoration(
        boxShadow: [
          BoxShadow(
            color: AppColors.gray200,
            blurRadius: 10,
            offset: Offset(0, 5),
          ),
        ],
        color: AppColors.white,
        borderRadius: BorderRadius.all(
          Radius.circular(20),
        ),
      ),
      child: Padding(
        padding: const EdgeInsets.all(10),
        child: Row(
          crossAxisAlignment: CrossAxisAlignment.center,
          children: [
            Container(
              clipBehavior: Clip.hardEdge,
              decoration: const BoxDecoration(
                  borderRadius: BorderRadius.all(Radius.circular(20))),
              child: CachedNetworkImage(
                imageUrl: movie.image,
                fit: BoxFit.cover,
                width: 150.w,
                height: height,
              ),
            ),

            //
            const SizedBox(width: 20),

            //

            MovieSummaryCard(movie: movie),
          ],
        ),
      ),
    );
  }
}
