import 'package:flutter/material.dart';
import 'package:mobile/features/movies/presentation/screens/home.dart';
import 'package:mobile/features/movies/presentation/screens/movieDetail.dart';
import 'package:mobile/features/movies/presentation/screens/onboarding.dart';

void main() {
  runApp(MyApp());
}

class MyApp extends StatelessWidget {
//create named routes here
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Flutter Demo',
      theme: ThemeData(
        primaryColor: Colors.purple,
      ),
      initialRoute: '/home',
      routes: {
        '/': (context) => Home(),
        '/home': (context) => Home(),
        '/movie-detail': (context) => MovieDetail(),
      },
    );
  }
}
