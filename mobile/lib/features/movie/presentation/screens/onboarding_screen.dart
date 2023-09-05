import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

import '../widgets/splash_container.dart';

class OnboardingScreen extends StatelessWidget {
  const OnboardingScreen({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Container(
        height: 840.h,
        // width: 390.w,
        child: Stack(
          children: [
            SizedBox(
              height: 550.h,
              width: 390.w,
              child: ClipRRect(
                borderRadius: BorderRadius.circular(10.0),
                child: const Image(
                  image: AssetImage('assets/images/splash_screen.jpg'),
                  fit: BoxFit.cover, // Set the fit property to cover
                ),
              ),
            ),
            const Positioned(
              bottom: 0,
              child: SplashContainer(),
            )
          ],
        ),
      ),
    );
  }
}
