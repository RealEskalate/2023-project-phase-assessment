import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';
import 'package:mobile/core/presentation/app_colors.dart';

import '../../../../core/presentation/app_theme.dart';

class MovieCard extends StatefulWidget {
  const MovieCard({super.key});

  @override
  State<MovieCard> createState() => _MovieCardState();
}

class _MovieCardState extends State<MovieCard> {
  @override
  Widget build(BuildContext context) {
    return SizedBox(
      height: ScreenUtil().screenHeight * 0.5,
      width: ScreenUtil().screenHeight * 0.4,
      child: Stack(
        children: [
          Positioned(
            top: 0,
            child: Container(
              height: ScreenUtil().screenHeight * 0.5,
              width: ScreenUtil().screenHeight * 0.4,
              decoration: BoxDecoration(
                color: Colors.grey,
                borderRadius: BorderRadius.all(
                  Radius.circular(20.h),
                ),
                image: const DecorationImage(
                  image: AssetImage("assets/images/batman.jpeg"),
                  fit: BoxFit.cover,
                ),
              ),
            ),
          ),
          Positioned(
            left: 15.w,
            bottom: 15.h,
            child: Container(
              alignment: Alignment.center,
              height: 100.h,
              padding: EdgeInsets.only(
                  top: 10.h, bottom: 10.h, right: 16.w, left: 16.w),
              width: ScreenUtil().screenHeight * 0.35,
              decoration: BoxDecoration(
                color: AppColors.white,
                borderRadius: BorderRadius.all(
                  Radius.circular(10.h),
                ),
              ),
              child: Column(
                mainAxisAlignment: MainAxisAlignment.start,
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  Text(
                    "Title",
                    textAlign: TextAlign.left,
                    style: AppTheme.themeData.textTheme.titleMedium,
                  ),
                  Row(
                    mainAxisAlignment: MainAxisAlignment.start,
                    crossAxisAlignment: CrossAxisAlignment.center,
                    children: [
                      const Icon(
                        Icons.star,
                        color: AppColors.gold,
                      ),
                      SizedBox(
                        width: 6.w,
                      ),
                      Text(
                        "Likes",
                        style: AppTheme.themeData.textTheme.displaySmall,
                      ),
                      SizedBox(
                        width: 20.w,
                      ),
                      const Icon(
                        Icons.access_time,
                        color: AppColors.blue,
                      ),
                      SizedBox(
                        width: 6.w,
                      ),
                      Text(
                        "1 hour",
                        style: AppTheme.themeData.textTheme.displaySmall,
                      )
                    ],
                  )
                ],
              ),
            ),
          )
        ],
      ),
    );
  }
}
