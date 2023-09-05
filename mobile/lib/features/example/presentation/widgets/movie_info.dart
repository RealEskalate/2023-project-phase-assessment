import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

import '../../../../core/presentation/app_colors.dart';
import '../../../../core/presentation/app_theme.dart';

class MovieInfo extends StatelessWidget {
  const MovieInfo({super.key});

  @override
  Widget build(BuildContext context) {
    return Container(
      alignment: Alignment.center,
      height: 240.h,
      padding:
          EdgeInsets.only(top: 10.h, bottom: 10.h, right: 16.w, left: 16.w),
      width: ScreenUtil().screenHeight * 0.35,
      decoration: BoxDecoration(
        borderRadius: BorderRadius.all(
          Radius.circular(10.h),
        ),
      ),
      child: Column(
        mainAxisAlignment: MainAxisAlignment.start,
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          Text(
            "Operation fortune",
            textAlign: TextAlign.left,
            style: AppTheme.themeData.textTheme.titleSmall,
          ),
          SizedBox(
            height: 10.h,
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
                width: 16.w,
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
    );
  }
}
