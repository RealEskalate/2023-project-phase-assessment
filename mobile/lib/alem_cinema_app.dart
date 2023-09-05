import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';
import 'package:go_router/go_router.dart';
import 'package:mobile/features/example/presentation/bloc/movie_bloc.dart';
import 'package:mobile/features/example/presentation/bloc/movie_id_bloc.dart';
import 'package:mobile/features/example/presentation/screens/description_screen.dart';
import 'package:mobile/features/example/presentation/screens/home_screen.dart';
import 'package:mobile/features/example/presentation/screens/on_boarding_screen.dart';
import 'package:mobile/injection/injection_container.dart';

class AlemCinemaApp extends StatelessWidget {
  const AlemCinemaApp({super.key});
  @override
  Widget build(BuildContext context) {
    final GoRouter router =
        GoRouter(navigatorKey: GlobalKey<NavigatorState>(), routes: [
      GoRoute(
        path: '/',
        builder: (context, state) => const OnBoardingScreen(),
      ),
      GoRoute(
        path: '/home',
        builder: (context, state) => const HomeScreen(),
      ),
      GoRoute(
          path: '/description',
          builder: (context, state) =>
              DescriptionScreen(id: state.extra! as String))
    ]);
    return ScreenUtilInit(
      designSize: const Size(338, 717),
      minTextAdapt: true,
      splitScreenMode: true,
      builder: (_, child) {
        return MaterialApp(
            home: MultiBlocProvider(
          providers: [
            BlocProvider(create: (context) => serviceLocator<MovieBloc>()),
            BlocProvider(create: (context) => serviceLocator<MovieIdBloc>())
          ],
          child: MaterialApp.router(
            debugShowCheckedModeBanner: false,
            routerConfig: router,
          ),
        ));
      },
    );
  }
}
