import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:mobile/features/movie/presentation/bloc/movie_bloc.dart';
import 'package:mobile/injection/injection.dart';

import 'features/movie/presentation/screens/OnboardingPage.dart';
import 'features/movie/presentation/screens/home_page.dart';
import 'features/movie/presentation/screens/movie_detail_page.dart';
import './injection/injection.dart' as di;

void main() async{
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
        routes: {
          '/': (context) => OnBoardingPage(),
          '/home': (context) => HomePage(),
          '/detail': (context) => movieDetail(),
         
        },
        initialRoute: "/",
        debugShowCheckedModeBanner: false,
        title: 'Flutter Demo',
        theme: ThemeData(
          useMaterial3: true,
        ),
       
      ),
    );
  }
}
