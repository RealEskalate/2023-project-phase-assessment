import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';
import 'package:mobile/features/example/presentation/widgets/intro_widget.dart';
import 'package:smooth_page_indicator/smooth_page_indicator.dart';
import 'package:mobile/core/presentation/data/images.dart';

import '../../../../core/presentation/app_colors.dart';

class OnboardingScreen extends StatefulWidget {
  OnboardingScreen({super.key});

  @override
  State<OnboardingScreen> createState() => _OnboardingScreenState();
}

class _OnboardingScreenState extends State<OnboardingScreen> {
  @override
  Widget build(BuildContext context) {
    PageController controller = PageController();
    final images = data;

    return Scaffold(
      body: Stack(
        children: [
          Positioned(
            top: 0,
            child: SizedBox(
              height: ScreenUtil().screenHeight * 0.7,
              width: ScreenUtil().screenWidth,
              child: PageView.builder(
                itemCount: images.length,
                controller: controller,
                itemBuilder: (BuildContext context, int index) {
                  return Image.asset(
                    'assets/images/${images[index]}',
                    fit: BoxFit.fill,
                  );
                },
              ),
            ),
          ),
          Positioned(
            bottom: 0,
            child: Column(
              children: [
                SmoothPageIndicator(
                  controller: controller,
                  count: images.length,
                  effect: const WormEffect(
                    dotColor: AppColors.blue100,
                    activeDotColor: AppColors.blue,
                    spacing: 10,
                  ),
                ),
                SizedBox(
                  height: 20.h,
                ),
                Container(
                  decoration: BoxDecoration(
                    color: Colors.blueGrey,
                    borderRadius: BorderRadius.only(
                      topLeft: Radius.circular(50.w),
                      topRight: Radius.circular(50.w),
                    ),
                  ),
                  height: ScreenUtil().screenHeight * 0.4,
                  width: ScreenUtil().screenWidth,
                  child: const IntroWidget(),
                ),
              ],
            ),
          ),
        ],
      ),
    );
  }
}
