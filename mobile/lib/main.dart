import 'package:flutter/material.dart';
import 'package:mobile/features/example/presentation/screens/home.dart';
import 'package:mobile/features/example/presentation/screens/movie.dart';
import 'package:mobile/features/example/presentation/screens/onboarding.dart';


void main() {
  runApp(MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      debugShowCheckedModeBanner: false,
      initialRoute: '/Onboarding', 
      onGenerateRoute: (settings) {
        switch (settings.name) {
          case '/onboarding':
            return MaterialPageRoute(builder: (context) => Onboarding());
          case '/home':
            return MaterialPageRoute(builder: (context) =>  Home());
          case '/movie':
            return MaterialPageRoute(builder: (context) => const Movie());
          default:
            
            return MaterialPageRoute(
                builder: (context) => Onboarding());
        }
      },
    );
  }
}
