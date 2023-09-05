import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

import 'app_colors.dart';

class AppDimensions {
  static const width = 411.4;
  static const height = 866.3;
}

abstract class AppTheme {
  /// Theme data for the app
  ///
  /// This theme data is used in [App] widget
  static final themeData = ThemeData(
    // Color Palette
    colorScheme: const ColorScheme(
      primary: AppColors.blue,
      onPrimary: AppColors.white,
      secondary: AppColors.darkerBlue,
      onSecondary: AppColors.white,
      background: AppColors.gray100,
      onBackground: AppColors.darkBlue,
      surface: AppColors.gray200,
      onSurface: AppColors.darkBlue,
      error: AppColors.red,
      onError: AppColors.white,
      brightness: Brightness.light,
    ),

    // Text Theme
    textTheme: TextTheme(
      // Headings
      titleMedium: const TextStyle(
        color: AppColors.darkerBlue,
        fontFamily: 'Poppins',
        fontSize: 24,
        fontWeight: FontWeight.w500,
      ),
      titleLarge: const TextStyle(
        fontFamily: 'Poppins',
        color: AppColors.darkerBlue,
        fontSize: 24,
        fontWeight: FontWeight.w600,
      ),

      // Body
      bodySmall: const TextStyle(
        color: AppColors.darkBlue,
        fontFamily: 'Poppins',
        fontSize: 14,
        fontWeight: FontWeight.w500,
      ),
      bodyMedium: const TextStyle(
        fontFamily: 'Poppins',
        color: AppColors.darkBlue,
        fontSize: 16,
        fontWeight: FontWeight.w400,
      ),
      bodyLarge: const TextStyle(
        fontFamily: 'Poppins',
        color: AppColors.darkBlue,
        fontSize: 20,
        fontWeight: FontWeight.w400,
      ),

      displayLarge: TextStyle(
        fontFamily: 'Poppins',
        color: AppColors.darkerBlue,
        fontSize: 40,
        wordSpacing: 6.sp,
        letterSpacing: 1.sp,
        fontWeight: FontWeight.w600,
      ),
    ),

    // Elevated Button theme
    elevatedButtonTheme: const ElevatedButtonThemeData(
      style: ButtonStyle(
        textStyle: MaterialStatePropertyAll<TextStyle>(
          TextStyle(
            fontFamily: 'Poppins',
            fontSize: 15,
            fontWeight: FontWeight.w500,
            color: AppColors.white,
          ),
        ),
        shape: MaterialStatePropertyAll<RoundedRectangleBorder>(
          RoundedRectangleBorder(
            borderRadius: BorderRadius.all(
              Radius.circular(12),
            ),
          ),
        ),
      ),
    ),

    // Popup menu theme
    popupMenuTheme: const PopupMenuThemeData(
      color: AppColors.gray100,
      textStyle: TextStyle(
        color: AppColors.darkBlue,
        fontFamily: 'Poppins',
        fontSize: 14,
        fontWeight: FontWeight.w400,
      ),
    ),

    iconTheme: const IconThemeData(
      color: AppColors.darkBlue,
    ),
  );
}
