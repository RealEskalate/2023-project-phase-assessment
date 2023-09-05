import 'package:flutter/material.dart';
import 'package:mobile/features/example/presentation/screens/home_screen.dart';
import 'package:mobile/features/example/presentation/screens/onboarding_screen.dart';

import 'core/routes/movie_routes.dart';
import 'features/example/domain/entities/movie.dart';
import 'features/example/presentation/screens/movie_detail_screen.dart';

Route<dynamic> controller(RouteSettings settings) {
  switch (settings.name) {
    
    case MovieAppRoutes.MOVIE_DETAIL:
      final Movie movie = settings.arguments as Movie;
      return MaterialPageRoute(
        builder: (context) => MovieDetailScreen(movie: movie),
      );
    case MovieAppRoutes.HOME:
      return MaterialPageRoute(builder: (context) => HomeScreen());
    case MovieAppRoutes.ONBOARDING:
      return MaterialPageRoute(builder: (context) => const OnboardingScreen());
    default:
      return throw ("invalid navigation");
  }
}
