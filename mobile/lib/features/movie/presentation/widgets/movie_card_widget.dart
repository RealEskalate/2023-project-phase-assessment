import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';


class MovieCardWidget extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Card(
      elevation: 4.0, // Card elevation for a shadow effect
      shape: RoundedRectangleBorder(
        borderRadius: BorderRadius.circular(15.0), // Rounded corners
      ),
      child: Container(
        height: 150.h,
        padding: EdgeInsets.all(16.0),
        child: Row(
          crossAxisAlignment: CrossAxisAlignment.center,
          children: [
            // Image
            Container(
              width: 100.0,
              height: double.infinity, // Take full height of the card
              child: Image.asset(
                'assets/images/image.jpeg', // Replace with your image asset
                fit: BoxFit.cover,
              ),
            ),
            SizedBox(width: 16.0), // Spacing between image and text

            // Text and Info
            Expanded(
              child: Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                mainAxisAlignment:  MainAxisAlignment.center,
                children: [
                  Text(
                    'Movie Title',
                    style: TextStyle(
                      fontSize: 20.0,
                      fontWeight: FontWeight.bold,
                    ),
                  ),
                  Row(
                    children: [
                      Icon(Icons.star, color: Colors.yellow),
                      SizedBox(width: 4.0),
                      Text('4.5'),
                      SizedBox(width: 16.0),
                      Icon(Icons.access_time),
                      SizedBox(width: 4.0),
                      Text('2h 30m'),
                    ],
                  ),
                ],
              ),
            ),
          ],
        ),
      ),
    );
  }
}
