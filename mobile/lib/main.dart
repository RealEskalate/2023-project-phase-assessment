 import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';
import 'package:second/feature/homepage/presentation/pages/home_page.dart';
import 'package:second/feature/main_page/presentation/pages/all_movies.dart';

void main() {
  runApp( ScreenUtilInit(
        designSize: const Size(338, 717),
        builder: (context, child) {
          return MaterialApp(
            debugShowCheckedModeBanner: false,
            home: child,
          );
        },
        child: AllMoviePage(),
      ),);
}

