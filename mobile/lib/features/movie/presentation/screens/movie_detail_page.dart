import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

class movieDetail extends StatelessWidget {
  const movieDetail({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        backgroundColor: Colors.white,
        leading: IconButton(
          icon: Icon(
            Icons.arrow_back,
            size: 35.r,
          ),
          onPressed: () {
            Navigator.pushNamed(context, "/home");
          },
        ),
        title: Container(
            margin: EdgeInsets.only(left: 60.w), child: Text('Alem Cinema')),
        actions: [Icon(Icons.bookmark, size: 35.h)],
      ),
      body: SingleChildScrollView(
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          children: [
            Center(
              child: Container(
                width: 300.w,
                height: 500.h,
                child: Image.asset(
                  "assets/images/onboarding.jpg",
                  fit: BoxFit.cover,
                ),
              ),
            ),
            Container(
              margin: EdgeInsets.only(top: 15.h),
              child: Column(
                children: [
                  Text(
                    "A MAN CALLED OTTO",
                    style: TextStyle(
                      fontWeight: FontWeight.w600,
                    ),
                  ),
                  Container(
                    margin: EdgeInsets.only(left: 60.w),
                    child: Row(
                      children: [
                        Icon(Icons.access_time),
                        Text("1 hour| comedy or drama"),
                      ],
                    ),
                  ),
                  Container(
                    margin: EdgeInsets.only(top: 10.h),
                    width: 350.w,
                    height: 350.h,
                    child: Text(
                      "Your long text goes here, and it will be truncated with an ellipsis at the end if it exceeds the container's width.Your long text goes here, and it will be truncated with an ellipsis at the end if it exceeds the container's width.Your long text goes here, and it will be truncated with an ellipsis at the end if it exceeds the container's width.Your long text goes here, and it will be truncated with an ellipsis at the end if it exceeds the container's width.",
                      maxLines: 15.toInt(), // Set the maximum number of lines
                      overflow: TextOverflow.ellipsis, // Overflow with ellipsis
                      style: TextStyle(
                        color: Colors.black,
                        fontSize: 25.sp,
                      ),
                    ),
                  ),
                  Center(
                    child: Container(
                      margin: EdgeInsets.only(top: 50.h),
                      width: 200.w, // Set the desired width
                      height: 50.h, // Set the desired height
                      child: ElevatedButton(
                        onPressed: () {},
                        style: ElevatedButton.styleFrom(
                          primary: Colors.blue, // Background color
                          onPrimary: Colors.white,
                          shape: RoundedRectangleBorder(
                            borderRadius: BorderRadius.circular(
                                10.r), // Remove the border radius
                          ), // Text color
                        ),
                        child: Text('Watch Now'),
                      ),
                    ),
                  )
                ],
              ),
            )
          ],
        ),
      ),
    );
  }
}
