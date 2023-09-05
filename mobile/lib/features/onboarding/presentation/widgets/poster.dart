import 'dart:ui';

import 'package:flutter/material.dart';

import '../../../../core/presentation/theme/app_colors.dart';

class Poster extends StatelessWidget {
  final String imagePath;

  const Poster({super.key, required this.imagePath});

  @override
  Widget build(BuildContext context) {
    return ShaderMask(
      shaderCallback: (Rect bounds) {
        return LinearGradient(
          begin: Alignment.bottomCenter,
          end: Alignment.topCenter,
          colors: [
            AppColors.black.withOpacity(1),
            AppColors.black.withOpacity(.5),
          ],
          stops: const [0.6, 1],
        ).createShader(bounds);
      },
      blendMode: BlendMode.dstOver,
      child: Image.asset(
        imagePath,
        fit: BoxFit.cover,
      ),
    );
  }
}
