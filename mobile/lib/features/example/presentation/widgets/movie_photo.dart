import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

class MoviePhoto extends StatelessWidget {
  const MoviePhoto({super.key});

  @override
  Widget build(BuildContext context) {
    return Stack(alignment: Alignment.centerLeft, children: [
      Container(
        width: 160.w,
        height: 160.h,
        decoration: BoxDecoration(
          borderRadius: BorderRadius.all(
            Radius.circular(10.h),
          ),
          image: const DecorationImage(
            image: AssetImage("assets/images/spiderman.jpeg"),
            fit: BoxFit.cover,
          ),
        ),
      )
    ]);
  }
}
