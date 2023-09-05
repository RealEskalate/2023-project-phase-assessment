
import 'package:flutter/material.dart';
import 'package:mobile/features/example/presentation/widgets/background_image.dart';
import 'package:mobile/features/example/presentation/widgets/feed_content.dart';
import 'package:mobile/features/example/presentation/widgets/on_boarding_inner_content.dart';

class OnBoardingScreen extends StatelessWidget {
  const OnBoardingScreen({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Stack(
        children: [
          BackGroundImage(),
          Column(
            children: [
              Spacer(),
              FeedContent(
                innerContent: OnBoardingInnerContent(),
              ),
            ],
          ),
        ],
      ),
    );
  }
}