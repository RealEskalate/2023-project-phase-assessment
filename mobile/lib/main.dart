import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

import 'features/onboarding/presentation/screens/onboarding_screen.dart';

Future<void> main() async {
  runApp(const App());
}

class App extends StatelessWidget {
  const App({Key? key});

  @override
  Widget build(BuildContext context) {
    return ScreenUtilInit(
      designSize: const Size(390, 844),
      minTextAdapt: true,
      splitScreenMode: true,
      child: MaterialApp(
        home: Onboarding(), // Set your home screen here
        debugShowCheckedModeBanner: false, // Remove the debug banner
      ),
    );
  }
}
