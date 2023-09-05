import 'package:flutter/material.dart';

class Poster extends StatelessWidget {
  final String imagePath;

  const Poster({super.key, required this.imagePath});

  @override
  Widget build(BuildContext context) {
    return Image.asset(
      imagePath,
      fit: BoxFit.cover,
    );
  }
}
