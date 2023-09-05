import 'package:flutter/material.dart';

import '../../../../core/presentation/theme/app_colors.dart';
import '../../domain/entities/movie.dart';

class MovieSummaryCard extends StatelessWidget {
  final Movie movie;

  const MovieSummaryCard({super.key, required this.movie});

  @override
  Widget build(BuildContext context) {
    return Column(
      crossAxisAlignment: CrossAxisAlignment.start,
      children: [
        Text(
          movie.title,
          style:
              Theme.of(context).textTheme.titleMedium!.copyWith(fontSize: 20),
        ),
        const SizedBox(
          height: 8,
        ),
        Row(
          children: [
            Row(
              children: [
                const Icon(
                  Icons.star,
                  color: AppColors.yellow,
                ),
                const SizedBox(width: 2),
                Text(
                  movie.rating.toString(),
                  style: Theme.of(context)
                      .textTheme
                      .bodyMedium
                      ?.copyWith(color: AppColors.gray300),
                )
              ],
            ),
            const SizedBox(width: 10),
            Row(
              children: [
                const Icon(
                  Icons.access_time_outlined,
                  color: AppColors.blue,
                ),
                const SizedBox(width: 2),
                Text(
                  movie.duration,
                  style: Theme.of(context)
                      .textTheme
                      .bodyMedium
                      ?.copyWith(color: AppColors.gray300),
                )
              ],
            ),
          ],
        )
      ],
    );
  }
}
