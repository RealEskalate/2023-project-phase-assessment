import 'package:go_router/go_router.dart';

import '../../../features/movie/presentation/screens/home_screen.dart';
import '../../../features/movie/presentation/screens/movie_detail_screen.dart';
import '../../../features/movie/presentation/screens/onboarding_screen.dart';
import 'routes.dart';

final GoRouter router = GoRouter(
  // TODO: Add all routes here

  routes: <RouteBase>[
    // Debug area
    GoRoute(
      path: Routes.home,
      builder: (context, state) => const HomeScreen(),
    ),
    // Debug end!

    GoRoute(
      path: Routes.onBoard,
      builder: (context, state) => const OnboardingScreen(),
    ),

    GoRoute(
      path: Routes.movieDetail,
      builder: (context, state) => const MovieDetailScreen(),
    ),
  ],
);
