import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';
import 'package:mobile/features/example/presentation/widgets/movie_info.dart';

import '../../../../core/presentation/app_colors.dart';
import 'movie_photo.dart';

class MovieItem extends StatefulWidget {
  const MovieItem({super.key});

  @override
  State<MovieItem> createState() => _MovieItemState();
}

class _MovieItemState extends State<MovieItem> {
  @override
  Widget build(BuildContext context) {
    return GestureDetector(
      child: Container(
        height: 140.h,
        width: ScreenUtil().screenWidth * 0.9,
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
              child: MoviePhoto(),
            ),
            SizedBox(width: 10.w),
            Expanded(
              child: MovieInfo(),
            ),
          ],
        ),
      ),
      onTap: () async {},
    );
  }
}
