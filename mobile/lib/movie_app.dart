import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';
import 'package:go_router/go_router.dart';
import 'package:mobile/features/movie/presentation/bloc/movie_bloc.dart';
import 'package:mobile/features/movie/presentation/screens/detail_screen.dart';
import 'package:mobile/features/onboarding/presentation/screens/splash_screen.dart';
import 'package:mobile/features/movie/presentation/screens/home_screens.dart';
import 'package:mobile/injection/injection_container.dart';

class MovieApp extends StatelessWidget {
  const MovieApp({super.key});

  @override
  Widget build(BuildContext context) {
    final GoRouter _router =
        GoRouter(navigatorKey: GlobalKey<NavigatorState>(), routes: [
      GoRoute(path: '/', builder: (context, state) => SplashScreen()),
      GoRoute(path: '/detail', builder: (context, state) => DetailScreen()),
      GoRoute(path: '/home-page', builder: (context, state) =>  HomeScreen(context:context)),
    ]);
    return ScreenUtilInit(
      designSize: const Size(375, 812),
      minTextAdapt: true,
      splitScreenMode: true,
      builder: (_, child) {
        return MaterialApp(
            home: MultiBlocProvider(
          providers: [
            
            BlocProvider(
              create: (context) => sl<MovieBloc>(),
            ),
           ],
          child: MaterialApp.router(
            routerConfig: _router,
          ),
        ));
      },
    );
  }
}
