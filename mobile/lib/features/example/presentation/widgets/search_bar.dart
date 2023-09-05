
import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

class SearchBarWidget extends StatelessWidget {
  const SearchBarWidget({
    super.key,
  });

  @override
  Widget build(BuildContext context) {
    return Row(
      children: [
        SizedBox(
          width: 10.w,
        ),
        Container(
          width: 240.w,
          height: 60.5.h,
          padding: EdgeInsets.only(left: 15.w),
          decoration: BoxDecoration(
            border: Border.all(color: Colors.grey.withOpacity(0.1)),
            color: Colors.white,
            borderRadius: BorderRadius.circular(10),
            boxShadow: [
              BoxShadow(
                color: Colors.grey.withOpacity(0.1),
                spreadRadius: 5,
                blurRadius: 7,
                offset: const Offset(0, 2),
              ),
            ],
          ),
          child: Center(
            child: TextField(
              decoration: InputDecoration(
                hintText: 'Looking for shows',
                hintStyle: TextStyle(
                  color: Theme.of(context).hintColor,
                  fontSize: 15,
                  fontWeight: FontWeight.w300,
                ),
                border: InputBorder.none,
              ),
            ),
          ),
        ),
        SizedBox(
          width: 20.w,
        ),
        ElevatedButton(
          onPressed: () {},
          style: ElevatedButton.styleFrom(
            padding:
                EdgeInsets.symmetric(vertical: 20.h, horizontal: 12.w),
            shape: RoundedRectangleBorder(
              borderRadius: BorderRadius.circular(10),
            ),
          ),
          child: Icon(
            Icons.search, // Clear icon
            color: Colors.white,
            size: 34.sp,
          ),
        ),
      ],
    );
  }
}