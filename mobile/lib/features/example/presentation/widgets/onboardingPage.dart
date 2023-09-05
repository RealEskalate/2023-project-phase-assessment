import 'package:flutter/material.dart';

class OnboardingPage extends StatelessWidget {
  final String image;

  OnboardingPage({required this.image});

  @override
  Widget build(BuildContext context) {
    return Center(
      child: Image.asset(image, height: 50), 
    );
  }
}
