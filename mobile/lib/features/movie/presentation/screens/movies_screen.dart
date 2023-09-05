import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

import '../../../../core/presentation/theme/app_colors.dart';
import '../../../../core/presentation/theme/app_theme.dart';
import '../widgets/bookmarked_card.dart';
import '../widgets/custom_text_field.dart';
import '../widgets/search_bar.dart';

class MoviesScreen extends StatelessWidget {
  const MoviesScreen({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: AppColors.gray100.withAlpha(240),
      appBar: AppBar(
        backgroundColor: Theme.of(context).colorScheme.background,
        elevation: 0,
        title: Center(
          child: Text('Alem Cinema',
              style: Theme.of(context).textTheme.titleMedium),
        ),
      ),
      body: Padding(
        padding: const EdgeInsets.symmetric(vertical: 30, horizontal: 20),
        child: Column(
          children: [
            // Search bar
            CustomSearchBar(),
            SizedBox(height: 20.h),

            // Title
            Row(
              children: [
                Text(
                  'Saved Movies',
                  style: Theme.of(context).textTheme.titleLarge,
                ),
                SizedBox(width: 5.w),
                GestureDetector(
                  child: const Icon(
                    Icons.bookmark_border,
                    color: AppColors.blue,
                  ),
                ),
              ],
            ),

            // Bookmarked list
            BookmarkedCard(),
          ],
        ),
      ),
    );
  }
}
