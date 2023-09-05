import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';
import 'package:go_router/go_router.dart';
import 'package:mobile/features/movie/presentation/screens/home_screens.dart';
import 'package:mobile/features/onboarding/presentation/screens/splash_screen.dart';

class MovieApp extends StatelessWidget {
  const MovieApp({super.key});

  @override
  Widget build(BuildContext context) {
    final GoRouter _router =
        GoRouter(navigatorKey: GlobalKey<NavigatorState>(), routes: [
      GoRoute(path: '/splash', builder: (context, state) => SplashScreen()),
      GoRoute(path: '/', builder: (context, state) => const HomeScreen()),
    ]);
    return ScreenUtilInit(
      designSize: const Size(375, 812),
      minTextAdapt: true,
      splitScreenMode: true,
      builder: (_, child) {
        return MaterialApp(
          home: MaterialApp.router(
            routerConfig: _router,
          ),
        );
      },
    );
  }
}
