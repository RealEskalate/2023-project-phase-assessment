import 'package:flutter/material.dart';
import "package:flutter_bloc/flutter_bloc.dart";
import "package:mobile/features/example/presentation/bloc/movie_bloc.dart";
import "./features/example/presentation/screens/home.dart";
import "./features/example/presentation/screens/detail.dart";
import "./features/example/presentation/screens/onboarding.dart";

void main() {
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    return BlocProvider(
      create: (context) => MovieBloc()..add(GetMovies()),
      child: MaterialApp(
        title: 'Flutter Demo',
        debugShowCheckedModeBanner: false,
        theme: ThemeData(
          colorScheme: ColorScheme.fromSeed(seedColor: Colors.deepPurple),
          useMaterial3: true,
        ),
        home: const OnBoarding(),
      ),
    );
  }
}
