import 'package:flutter/material.dart';

import '../../../../core/presentation/theme/app_theme.dart';
import 'onboarding_content.dart';
import 'poster.dart';

class OnboardingSinglePage extends StatelessWidget {
  final String imagePath;
  final String title;
  final String description;

  const OnboardingSinglePage({
    super.key,
    required this.imagePath,
    required this.title,
    required this.description,
  });

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: SizedBox(
        height: AppDimensions.height,
        width: AppDimensions.width,
        child: Stack(
          children: [
            Poster(imagePath: imagePath),
            Positioned(
              bottom: 0,
              child: Container(
                width: MediaQuery.of(context).size.width,
                height: MediaQuery.of(context).size.height * 0.4,
                decoration: const BoxDecoration(
                  gradient: LinearGradient(
                    begin: Alignment.bottomCenter,
                    end: Alignment.topCenter,
                    colors: [
                      Colors.black,
                      Colors.transparent,
                    ],
                  ),
                ),
              ),
            ),
            Positioned(
              bottom: 0,
              child: OnboardingContent(title: title, description: description),
            )
          ],
        ),
      ),
    );
  }
}
