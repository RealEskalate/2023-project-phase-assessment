import 'package:cached_network_image/cached_network_image.dart';
import 'package:flutter/material.dart';
import 'package:flutter/widgets.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

import '../../../../core/presentation/theme/app_colors.dart';
import '../../domain/entities/movie.dart';

class BookmarkedCard extends StatelessWidget {
  final Movie movie;

  const BookmarkedCard({super.key, required this.movie});

  @override
  Widget build(BuildContext context) {
    final width = 220.w;
    final height = 300.h;

    return Container(
        width: width,
        height: height,
        clipBehavior: Clip.hardEdge,
        decoration: BoxDecoration(
          borderRadius: BorderRadius.circular(20),
          color: AppColors.white,
        ),
        child: Stack(
          children: [
            CachedNetworkImage(
              imageUrl: movie.image,
              fit: BoxFit.cover,
              width: width,
              height: height,
            ),
            Positioned(
              child: Align(
                alignment: Alignment.bottomCenter,
                child: Padding(
                  padding: const EdgeInsets.all(20),
                  child: Container(
                    width: 200.w,
                    height: 80.h,
                    decoration: BoxDecoration(
                      borderRadius: BorderRadius.circular(20),
                      color: AppColors.white,
                    ),
                    child: Padding(
                      padding: const EdgeInsets.only(
                        top: 10,
                        right: 5,
                        left: 5,
                        bottom: 5,
                      ),
                      child: Column(
                        crossAxisAlignment: CrossAxisAlignment.start,
                        children: [
                          Text(
                            movie.title,
                            style: Theme.of(context)
                                .textTheme
                                .titleMedium!
                                .copyWith(fontSize: 20),
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
                      ),
                    ),
                  ),
                ),
              ),
            )
          ],
        ));
  }
}
