import 'package:flutter/material.dart';
import 'package:mobile/features/example/presentation/screens/homePage.dart';
import 'package:mobile/features/example/presentation/screens/movieDetail.dart';
import 'package:mobile/features/example/presentation/screens/onBoarding.dart';

void main() {
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      debugShowCheckedModeBanner: false,
      title: 'Flutter Demo',
      theme: ThemeData(
        colorScheme: ColorScheme.fromSeed(seedColor: Colors.deepPurple),
        useMaterial3: true,
      ),
      home: const OnBoarding(),
      routes: {
        '/Home': (context) => Home(),
        '/Detail': (context) => DetailPage(), // Home page route
        // Add other routes here if needed
      },
    );
  }
}
