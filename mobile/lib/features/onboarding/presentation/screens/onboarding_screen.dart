import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';
import 'package:smooth_page_indicator/smooth_page_indicator.dart';

import '../../../../core/presentation/assets/assets.dart';
import '../../../../core/presentation/content/app_text_content.dart';
import '../../../../core/presentation/theme/app_colors.dart';
import '../../../../core/presentation/theme/app_theme.dart';
import '../widgets/onboarding_content.dart';
import '../widgets/poster.dart';

class OnboardingScreen extends StatefulWidget {
  const OnboardingScreen({
    super.key,
  });

  @override
  State<StatefulWidget> createState() => _OnboardingScreenState();
}

class _OnboardingScreenState extends State<OnboardingScreen> {
  final PageController controller = PageController();

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: SizedBox(
        height: AppDimensions.height.h,
        width: AppDimensions.width.w,
        child: Stack(
          children: [
            PageView.builder(
              controller: controller,
              itemCount: AppAssset.onboardingImages.length,
              itemBuilder: (context, index) =>
                  Poster(imagePath: AppAssset.onboardingImages[index]),
            ),
            Positioned(
              child: Align(
                alignment: Alignment.center,
                child: SmoothPageIndicator(
                  controller: controller,
                  count: AppAssset.onboardingImages.length,
                  effect: const ExpandingDotsEffect(
                    dotColor: AppColors.blue,
                    activeDotColor: AppColors.blue,
                    dotHeight: 10,
                    dotWidth: 10,
                    spacing: 10,
                  ),
                ),
              ),
            ),
            const Positioned(
              bottom: 0,
              child: OnboardingContent(
                  title: AppTextContent.onboardingScreenTitle,
                  description: AppTextContent.onboardingScreenDescription),
            )
          ],
        ),
      ),
    );
  }
}
