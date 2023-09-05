import 'package:go_router/go_router.dart';
import 'package:mobile/features/example/presentation/screens/onboarding_screen.dart';

import '../../../features/example/presentation/screens/home_page.dart';
import 'routes.dart';

final GoRouter router = GoRouter(

  routes: <RouteBase>[
    GoRoute(
      path: Routes.home,
      builder: (context, state) => OnboardingScreen(),
    ),

    GoRoute(
      path: Routes.onBoard,
      builder: (context, state) => OnboardingScreen(),
    ),

 
    GoRoute(
      path: Routes.movies,
      builder: (context, state) => const HomePage(),
    ),

    // GoRoute(
    //   path: Routes.movieDetail,
    //   builder: (context, state) {
    //     final article = state.extra as Article;
    //     return ArticleScreen(article: article);
    //   },
    // ),

  ],
);
