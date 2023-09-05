
import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';
import 'package:go_router/go_router.dart';

class OnBoardingInnerContent extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Column(
      crossAxisAlignment: CrossAxisAlignment.center,
      children: [
        SizedBox(
          height: 20.h,
        ),
        Container(
            padding: EdgeInsets.symmetric(horizontal: 20.w, vertical: 20.h),
            child: Text(
              "Streaming movie and TV. Watch Instantly",
              textAlign: TextAlign.center,
              style: TextStyle(fontWeight: FontWeight.bold, fontSize: 40),
            )),
        Container(
          padding: EdgeInsets.symmetric(horizontal: 20.w),
          child: Text(
            "Enjoy all your favorite films and TV shows on your streaming devices",
            style: TextStyle(
              fontSize: 20,
            ),
          ),
        ),
        SizedBox(
          height: 40.h,
        ),
        Container(
          width: 300.w,
          height: 50.h,
          child: ElevatedButton(
            onPressed: () {
              context.push('/home');
            },
            child: Text("Get Started"),
          ),
        ),
        SizedBox(
          height: 20.h,
        )
      ],
    );
  }
}