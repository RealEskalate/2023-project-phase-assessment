import 'package:flutter/material.dart';

class BackGroundImage extends StatelessWidget {
  const BackGroundImage({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    final double screenWidth = MediaQuery.of(context).size.width;
    return Container(
      child: Image.asset(
        'assets/images/spider_man.jpg',
        width: screenWidth,
        fit: BoxFit.cover,
      ),
    );
  }
}
