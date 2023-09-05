import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';
import 'package:go_router/go_router.dart';
import 'package:mobile/core/presentation/app_colors.dart';

import '../../../../core/presentation/app_theme.dart';
import '../../../../core/presentation/router/routes.dart';

class IntroWidget extends StatelessWidget {
  const IntroWidget({super.key});

  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: EdgeInsets.only(top: 20.h, left: 30.w, right: 30.w, bottom: 8.h),
      child: Column(
        children: [
          Text(
            'Streaming movie and TV. watch instantly',
            textAlign: TextAlign.center,
            style: AppTheme.themeData.textTheme.titleLarge,
          ),
          SizedBox(
            height: 16.h,
          ),
          Text(
            'Enjoy all your favorite films and TV shows on your streaming decices',
            textAlign: TextAlign.center,
            style: AppTheme.themeData.textTheme.displaySmall,
          ),
          SizedBox(
            height: 32.h,
          ),
          MaterialButton(
            minWidth: double.infinity,
            height: 60,
            color: AppColors.blue,
            textColor: Colors.white,
            onPressed: () {
              context.go(Routes.movies);
            },
            child: Text(
              'Get Started',
              style: AppTheme.themeData.textTheme.bodyMedium,
            ),
          ),
        ],
      ),
    );
  }
}
