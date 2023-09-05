import 'package:flutter/material.dart';
import 'package:mobile/features/example/presentation/screens/home_page.dart';
import 'package:mobile/features/example/presentation/screens/OnboardingPage.dart';
import 'package:mobile/features/example/presentation/screens/movie_detail_page.dart';

void main() {
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
           
      routes: {
        '/': (context) => OnBoardingPage(),
        '/home': (context) => HomePage(),
        '/detail': (context) => movieDetail(),
        // '/task_Detail': (context) => taskDetail()
      },
       initialRoute: "/",
      debugShowCheckedModeBanner: false,
      title: 'Flutter Demo',
      theme: ThemeData(
        useMaterial3: true,
      ),
      // home: const OnBoardingPage(),
    );
  }
}
