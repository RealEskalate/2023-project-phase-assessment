import 'package:go_router/go_router.dart';
import '../../../features/movie/domain/entities/movie.dart';
import '../../../features/movie/presentation/screens/movies_screen.dart';
import '../../../features/onboarding/presentation/screens/onboarding_screen.dart';
import 'routes.dart';

final GoRouter router = GoRouter(
  routes: <RouteBase>[
    //
    GoRoute(
      path: Routes.home,
      builder: (context, state) => const MoviesScreen(),
    ),
    //

    GoRoute(
      path: Routes.home,
      builder: (context, state) => const OnboardingScreen(),
    ),

    GoRoute(
      path: Routes.onBoarding,
      builder: (context, state) => const OnboardingScreen(),
    ),

    // movies
    GoRoute(
      path: Routes.movies,
      builder: (context, state) => const MoviesScreen(),
    ),

    // GoRoute(
    //   path: Routes.movieDetail,
    //   builder: (context, state) {
    //     final article = state.extra as Movie;
    //     return MovieDetailScreen(article: article);
    //   },
    // ),
  ],
);
