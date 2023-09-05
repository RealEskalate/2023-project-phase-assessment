import 'package:flutter/material.dart';
import 'package:mobile/core/routes/movie_routes.dart';
import 'package:mobile/features/example/presentation/screens/home_screen.dart';
import 'package:mobile/injection/dependency_injection.dart';
import 'routes.dart' as route;
import 'package:mobile/features/example/presentation/screens/movie_detail_screen.dart';
import 'package:mobile/features/example/presentation/screens/onboarding_screen.dart';

void main() {
  setup();
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      
      theme: ThemeData(
        
        // useMaterial3: true,
      ),
      debugShowCheckedModeBanner: false,
      onGenerateRoute: route.controller,
      initialRoute: MovieAppRoutes.ONBOARDING,

      // home: HomeScreen(),
    );
  }
}


