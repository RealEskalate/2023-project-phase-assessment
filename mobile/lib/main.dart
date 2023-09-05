import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:mobile/features/example/presentation/bloc/movie_bloc.dart';
import 'package:mobile/features/example/presentation/screens/all_movies_page.dart';
import 'package:mobile/features/example/presentation/screens/movie_detail.dart';
import 'package:mobile/features/example/presentation/screens/onboarding_page.dart';
import 'package:mobile/injection/depency_injection.dart';
import './injection/depency_injection.dart' as di;

void main() async {
  WidgetsFlutterBinding.ensureInitialized();
  await di.init();
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  @override
  Widget build(BuildContext context) {
    return BlocProvider(
      create: (context) => sl<MovieBloc>(),
      child: MaterialApp(
        debugShowCheckedModeBanner: false,
        title: 'Flutter Demo',
        theme: ThemeData(),
         routes: {
              '/': (context) => OnboardingPage(),
              '/all_movies': (context) => AllMovies(),
            },
      ),
    );
  }
}
