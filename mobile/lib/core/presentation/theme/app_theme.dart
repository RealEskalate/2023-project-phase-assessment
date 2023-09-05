import 'package:flutter/material.dart';

import 'app_colors.dart';

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
    textTheme: const TextTheme(
      // Headings
      titleMedium: TextStyle(
        color: AppColors.darkerBlue,
        fontFamily: 'Poppins',
        fontSize: 24,
        fontWeight: FontWeight.w500,
      ),
      titleLarge: TextStyle(
        fontFamily: 'Poppins',
        color: AppColors.darkerBlue,
        fontSize: 24,
        fontWeight: FontWeight.w600,
      ),

      // Body
      bodySmall: TextStyle(
        color: AppColors.darkBlue,
        fontFamily: 'Poppins',
        fontSize: 14,
        fontWeight: FontWeight.w500,
      ),
      bodyMedium: TextStyle(
        fontFamily: 'Poppins',
        color: AppColors.darkBlue,
        fontSize: 16,
        fontWeight: FontWeight.w400,
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
