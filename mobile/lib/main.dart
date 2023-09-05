import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:mobile/features/example/presentation/bloc/movie_bloc.dart';
import 'package:mobile/features/example/presentation/screens/onboarding_page.dart';

void main() {
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    return BlocProvider(
      create: (context) => MovieBloc()..add(GetMoviesEvent()),
      child: MaterialApp(
        theme: ThemeData(useMaterial3: true),
        debugShowCheckedModeBanner: false,
        home: const Scaffold(
          body: Center(
            child: OnBoardingFrame(),
          ),
        ),
      ),
    );
  }
}
