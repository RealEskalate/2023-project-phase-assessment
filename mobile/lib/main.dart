import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

import 'core/presentation/router/router.dart';
import 'core/presentation/theme/app_theme.dart';
import 'features/onboarding/presentation/screens/onboarding_screen.dart';

void main() {
  runApp(const App());
}

class App extends StatelessWidget {
  const App({super.key});

  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    return ScreenUtilInit(
      designSize: const Size(AppDimensions.width, AppDimensions.height),
      minTextAdapt: true,
      splitScreenMode: true,
      builder: (_, child) => MaterialApp.router(
        title: 'Alem Cinema',
        theme: AppTheme.themeData,
        debugShowCheckedModeBanner: false,
        routerConfig: router,
      ),
    );
  }
}
