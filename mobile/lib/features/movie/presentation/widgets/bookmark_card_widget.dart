import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

class BookMarkCard extends StatelessWidget {
  get background => null;

  @override
  Widget build(BuildContext context) {
    return Card(
      elevation: 4.0, // Card elevation for a shadow effect
      shape: RoundedRectangleBorder(
        borderRadius: BorderRadius.circular(20.0), // Rounded corners
      ),
      child: Stack(
        children: [
          ClipRRect(
            borderRadius: BorderRadius.circular(20.0),
            child: Container(
              height: 200.h,
              width: 200.w,
              decoration: BoxDecoration(
                image: DecorationImage(
                  image: AssetImage(
                      'assets/images/image.jpeg'), // Background image
                  fit: BoxFit.cover,
                ),
              ),
            ),
          ),
          Positioned(
            bottom: 10,
            left: 10,
            height: 70.h,
            width: 150.w,
            child: Container(
              padding: EdgeInsets.only(left: 16.0, right: 16),
              decoration: BoxDecoration(
                color:
                    Colors.white, // Replace with your desired background color
                borderRadius:
                    BorderRadius.circular(10.0), // Set the border radius
              ),
              child: Column(
                mainAxisAlignment: MainAxisAlignment.center,
                children: [
                  Text(
                    'Autobiography',
                    style: TextStyle(
                      color: Colors.black,
                      fontSize: 15.0,
                      fontWeight: FontWeight.bold,
                    ),
                  ),
                  SizedBox(height: 8.h),
                  Row(
                    mainAxisAlignment: MainAxisAlignment.spaceAround,
                    children: [
                      Row(
                        children: [
                          Icon(
                            Icons.star,
                            color: Colors.yellow,
                          ),
                          SizedBox(width: 4.w),
                          Text(
                            '5.0',
                            style: TextStyle(
                              color: Colors.black,
                            ),
                          ),
                        ],
                      ),
                      Row(
                        children: [
                          Icon(
                            Icons.remove_red_eye,
                            color: Colors.black,
                          ),
                          SizedBox(width: 4.w),
                          Text(
                            '100K',
                            style: TextStyle(
                              color: Colors.black,
                            ),
                          ),
                        ],
                      ),
                    ],
                  ),
                ],
              ),
            ),
          ),
          // Other content for the card can be added here
        ],
      ),
    );
  }
}
