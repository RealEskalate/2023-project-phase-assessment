
import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';
import 'package:mobile/features/example/presentation/widgets/movie_image.dart';

class MovieDesription extends StatelessWidget {
  const MovieDesription({
    super.key,
  });

  @override
  Widget build(BuildContext context) {
    return Column(
      crossAxisAlignment: CrossAxisAlignment.start,
      children: [
        SizedBox(
          height: 10.h,
        ),
        MovieImage(),
        SizedBox(
          height: 10,
        ),
        Container(
            padding: EdgeInsets.symmetric(horizontal: 20.w),
            child: Text(
              "A man called Otto",
              style: TextStyle(fontWeight: FontWeight.bold, fontSize: 24),
            )),
        SizedBox(
          height: 10.h,
        ),
        Container(
          padding: EdgeInsets.symmetric(horizontal: 20.w),
          child: Row(
            children: [
              Icon(
                Icons.access_time,
                color: Colors.blue,
              ),
              Text(
                "1 hour | Comedy & drama",
                style: TextStyle(
                  color: Colors.grey,
                  fontSize: 18,
                ),
              )
            ],
          ),
        ),
        SizedBox(
          height: 20.h,
        ),
        Expanded(
          child: Container(
              padding: EdgeInsets.symmetric(horizontal: 20.w),
              child: Text(
                "Otto(Tom Hanks) is a man who is easily angry after losing his wife. The situation begins to change when the young family moves into proximity.",
                style: TextStyle(fontWeight: FontWeight.w600, fontSize: 16),
              )),
        ),
        SizedBox(height: 10.h,),
        Container(
          margin: EdgeInsets.only(left: 24),
          width: 300.w,
          height: 50.h,
          child: ElevatedButton(
            onPressed: () {},
            child: Text("Watch Now"),
          ),
        ),
        SizedBox(height: 20.h,)
      ],
    );
  }
}