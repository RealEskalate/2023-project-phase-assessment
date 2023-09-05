import 'package:go_router/go_router.dart';
import 'package:mobile/features/movie/presentation/pages/onboarding/onboarding.dart';

import 'routes.dart';

final GoRouter router = GoRouter(routes: <RouteBase>[
  GoRoute(
    path: Routes.onboarding,
    builder: (context, state) => const OnboardingPage(),
  ),
  GoRoute(
    path: Routes.home,
    builder: (context, state) => const OnboardingPage(),
  ),
  GoRoute(
    path: Routes.movieDetails,
    builder: (context, state) => const OnboardingPage(),
  ),
  GoRoute(
    path: Routes.search,
    builder: (context, state) => const OnboardingPage(),
  ),
]);
