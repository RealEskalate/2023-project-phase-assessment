import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';
import 'package:mobile/core/presentation/app_colors.dart';
import 'package:mobile/features/example/presentation/widgets/app_bar.dart';
import 'package:mobile/features/example/presentation/widgets/custom_search_bar.dart';
import 'package:mobile/features/example/presentation/widgets/movie_item.dart';

import '../../../../core/presentation/app_theme.dart';
import '../widgets/movie_card.dart';

class HomePage extends StatefulWidget {
  const HomePage({super.key});

  @override
  State<HomePage> createState() => _HomePageState();
}

class _HomePageState extends State<HomePage> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: const CustomAppBar(),
      body: SingleChildScrollView(
        scrollDirection: Axis.vertical,
        child: Container(
          height: MediaQuery.of(context).size.height - 100,
          padding: EdgeInsets.only(top: 20.0..h, bottom: 20.h),
          color: Theme.of(context).colorScheme.background,
          child: Column(
            children: [
              const CustomSearchBar(),
              SizedBox(height: 10.h),
              Container(
                color: AppColors.white,
                padding: EdgeInsets.all(5.w),
                child: Row(
                  children: [
                    SizedBox(
                      width: 16.w,
                    ),
                    Text(
                      'Saved Movies',
                      style: AppTheme.themeData.textTheme.displayLarge,
                    ),
                    SizedBox(
                      width: 10.w,
                    ),
                    const Icon(
                      Icons.bookmark_border_rounded,
                      color: AppColors.blue,
                    )
                  ],
                ),
              ),
              SizedBox(
                height: 10.h,
              ),
              SingleChildScrollView(
                scrollDirection: Axis.horizontal,
                child: Row(
                  children: [
                    SizedBox(
                      width: 16.w,
                    ),
                    const MovieCard(),
                    SizedBox(
                      width: 16.w,
                    ),
                    const MovieCard(),
                    SizedBox(
                      width: 16.w,
                    ),
                    const MovieCard(),
                  ],
                ),
              ),
              SizedBox(
                height: 10.h,
              ),
              Container(
                color: AppColors.white,
                padding: EdgeInsets.all(5.w),
                child: Row(
                  children: [
                    SizedBox(
                      width: 16.w,
                    ),
                    Text(
                      'All Movies',
                      style: AppTheme.themeData.textTheme.displayLarge,
                    ),
                  ],
                ),
              ),
              MovieItem(),
            ],
          ),
        ),
      ),
    );
  }
}
