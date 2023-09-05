import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';
import 'package:mobile/features/movie/presentation/widgets/detail_header_widget.dart';

class DetailScreen extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Container(
        padding: EdgeInsets.only(left: 16.0, right: 16, top: 20),
        child: SingleChildScrollView(
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            mainAxisAlignment: MainAxisAlignment.spaceBetween,
            children: [
              DetailHeaderWidget(),
              Container(
                height: 380.h,
                child: Stack(
                  children: [
                    // Image.network(
                    //   "https://example.com/your_image_url.jpg", // Replace with your image URL
                    //   height: 200, // Adjust the height as needed
                    //   width: double.infinity,
                    //   fit: BoxFit.cover,
                    // ),
                    ClipRRect(
                      borderRadius: BorderRadius.circular(15.0),
                      child: Image.asset(
                        'assets/images/image.jpeg', // Replace with your image asset
                        fit: BoxFit.cover,
                        height: 350.h,
                        width: double.infinity,
                      ),
                    ),
                    Positioned(
                      bottom: 0,
                      right: 16.0,
                      child: Container(
                        color: Colors.black,
                        padding: EdgeInsets.all(10.0),
                        height: 80.h,
                        width: 50.w,
                        child: Column(
                          children: [
                            Icon(
                              Icons.star,
                              color: Colors.white,
                            ),
                            SizedBox(width: 8.0),
                            Text(
                              "4.5",
                              style: TextStyle(
                                color: Colors.white,
                              ),
                            ), // Replace with your star rating
                          ],
                        ),
                      ),
                    ),
                  ],
                ),
              ),
              SizedBox(height: 16.0),
              Text(
                "A man Called Otto",
                style: TextStyle(
                  fontSize: 24.0, // Adjust the font size as needed
                  fontWeight: FontWeight.bold,
                ),
              ),
              SizedBox(height: 8.h),
              Row(
                children: [
                  Icon(Icons.watch_later),
                  SizedBox(width: 8.w),
                  Text(
                    "1 hour | Comedy and Drama",
                    style: TextStyle(
                      fontSize: 15.0, // Adjust the font size as needed
                      fontWeight: FontWeight.w200,
                    ),
                  ),
                ],
              ),
              SizedBox(height: 16.h),
              Text(
                "Otto (Tom Hanks) is a man who is easily angered after losing his wife. The situation has changed when the family moved to proximity.",
                style: TextStyle(fontSize: 16.0),
              ),
              SizedBox(height: 16.0),
              ClipRRect(
                      borderRadius: BorderRadius.circular(10.0),

                child: Container(
                  width: double.infinity,
                  height: 50.w,
                  color: Colors.blue,
                  child: ElevatedButton(
                    onPressed: () {
                      // Handle the "Start" button press
                    },
                    child: Text(
                      'Watch Now',
                      style: TextStyle(
                        fontSize: 20.0, // Adjust the font size as needed
                        fontWeight: FontWeight.bold,
                      ),
                    ),
                  ),
                ),
              ),
            ],
          ),
        ),
      ),
    );
  }
}
