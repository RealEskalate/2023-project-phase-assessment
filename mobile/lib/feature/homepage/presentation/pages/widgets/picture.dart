import 'package:flutter/material.dart';

class PictureWidget extends StatelessWidget {
  const PictureWidget({super.key});

  @override
  Widget build(BuildContext context) {
    return Expanded(
      flex: 8,
      child: PageView(
        children: [
          Image(
            image: AssetImage("asset/abc.jpg",),
            fit: BoxFit.cover,
          ),
          Image(
            image: AssetImage("asset/download.jpg"),
            fit: BoxFit.cover,
          ),
          Image(
            image: AssetImage("asset/download.jpg"),
            fit: BoxFit.cover,
          ),
        ],
      ),
    );
  }
}
