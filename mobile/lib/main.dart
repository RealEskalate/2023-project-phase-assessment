import 'package:flutter/material.dart';
import 'package:flutter/material.dart';
import 'package:mobile/injection/injection.dart' as di;
import 'package:mobile/injection/injection.dart';

import 'package:shared_preferences/shared_preferences.dart'; // Import SharedPreferences package

import 'package:flutter_bloc/flutter_bloc.dart';

import 'core/bloc.dart';
import 'features/example/domain/usecases/add_bookmark.dart';
import 'features/example/domain/usecases/get_all_bookmarks.dart';
import 'features/example/domain/usecases/get_all_movies.dart';
import 'features/example/domain/usecases/get_single_movies.dart';
import 'features/example/presentation/bloc/bloc.dart';
import 'features/example/presentation/screens/home_screen.dart';
import 'features/example/presentation/screens/onboarding.dart';
import 'features/example/presentation/screens/search_result.dart';

Future<void> main() async {
  WidgetsFlutterBinding.ensureInitialized();

  await di.init();
  Bloc.observer = const AppBlocObserver();

  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return MultiBlocProvider(
      providers: [
        BlocProvider<MoviesBloc>(
          create: (context) => MoviesBloc(
            getAllMovies: sl<GetMoviesUseCase>(),
            getSingleMovie: sl<GetSingleMovieUseCase>(),
            getBookmark: sl<GetBookmarkUseCase>(),
            addBookmark: sl<AddBookmarkUseCase>(),
          ),
        ),
        // Other BlocProviders if needed
      ],
      child: MaterialApp(
        debugShowCheckedModeBanner: false,
        title: 'Alem Cinema',
        theme: ThemeData(
          colorScheme: ColorScheme.fromSeed(
              seedColor: Colors.white, secondary: const Color(0xffEE6F57)),
          useMaterial3: true,
        ),
        initialRoute: '/onboarding', // Use initialRoute based on 'auth_token'
        routes: {
          '/onboarding': (context) => const OnBoardingScreen(),
          '/home': (context) => const HomeScreen(),
          '/search': (context) => const SearchResult(
                keyword: '',
              ),

          // Define routes here
        },
      ),
    );
  }
}
