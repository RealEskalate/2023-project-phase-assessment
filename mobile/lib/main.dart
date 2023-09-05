import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:mobile/features/HomePage/presentation/bloc/homepage_bloc.dart';
import 'package:mobile/features/onboarding/on_boarding_screen.dart';

void main() {
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  @override
  Widget build(BuildContext context) {
    return BlocProvider(
      create: (context) => HomepageBloc()..add(GetDataEvent()),
      child: MaterialApp(
        debugShowCheckedModeBanner: false,
        title: 'Alem Cinima',
        theme: ThemeData(
          scaffoldBackgroundColor: const Color(0xfff4f6f8),
          colorScheme: ColorScheme.fromSeed(seedColor: Colors.purple),
          useMaterial3: true,
        ),
        home: OnBoardingScreen(),
      ),
    );
  }
}
