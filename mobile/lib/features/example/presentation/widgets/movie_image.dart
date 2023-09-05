
import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

class MovieImage extends StatelessWidget {
  const MovieImage({
    super.key,
  });

  @override
  Widget build(BuildContext context) {
    return Container(
      height: 400.h,
      child: Stack(
        children: [
          Container(
            alignment: Alignment.center,
            child: ClipRRect(
              borderRadius: BorderRadius.circular(25),
              child: Image.asset(
                'assets/images/man_called_otto.jpg',
                width: 320.w,
                height: 360.h,
                fit: BoxFit.cover,
              ),
            ),
          ),
          Positioned(
            left: 320,
            top: 380,
            child: Container(
              alignment: Alignment.center,
              width: 40.w,
              height: 40.w,
              decoration: BoxDecoration(
                  color: Colors.black87,
                  borderRadius: BorderRadius.circular(10)),
              child: Column(
                crossAxisAlignment: CrossAxisAlignment.center,
                children: [
                  Icon(
                    Icons.star,
                    color: Colors.yellow,
                  ),
                  Text(
                    "4.5",
                    style: TextStyle(color: Colors.white),
                  ),
                ],
              ),
            ),
          ),
        ],
      ),
    );
  }
}