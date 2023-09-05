import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

import '../../../../core/presentation/theme/app_theme.dart';
import 'custom_text_field.dart';

class CustomSearchBar extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return SizedBox(
      width: AppDimensions.width.w,
      child: Row(
        crossAxisAlignment: CrossAxisAlignment.center,
        mainAxisAlignment: MainAxisAlignment.center,
        children: [
          const Flexible(
            child: CustomTextField(
              maxLines: 1,
            ),
          ),
          const SizedBox(width: 20),
          SizedBox(
            height: 48.h,
            child: ElevatedButton(
              onPressed: () {},
              child: const Icon(Icons.search),
            ),
          ),
        ],
      ),
    );
  }
}
