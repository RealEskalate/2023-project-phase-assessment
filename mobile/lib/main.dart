import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:mobile/features/example/domain/entities/Movie.dart';
import 'package:mobile/features/example/presentation/bloc/get_movies_bloc.dart';
import 'package:mobile/features/example/presentation/screens/homescreen.dart';
import 'package:mobile/features/example/presentation/screens/onboarding.dart';

void main() {
  runApp(MyApp());
}

class MyApp extends StatefulWidget {
  const MyApp({super.key});

  @override
  State<MyApp> createState() => _MyAppState();
}

class _MyAppState extends State<MyApp> {
  @override
  Widget build(BuildContext context) {
    
    return MultiBlocProvider(
      providers: [
        BlocProvider<GetMoviesBloc>(
          lazy: false,
          create: (BuildContext context) => GetMoviesBloc()..add(AppStarted()),
        )
      ],
      child: MaterialApp(
        debugShowCheckedModeBanner: false,
        home: BlocBuilder<GetMoviesBloc, GetMoviesState>(
          builder: (context, state) {
            if(state is GettingMovies){
              return Container(child: Center(child: CircularProgressIndicator()));
            }
            else if(state is GetMovies){
              return HomePage(moviesData: state.movies);
            }
            return OnboardingPage();
          },
        ),
      ),
    );
  }
}

class ListCol extends StatelessWidget {
  final List<Movie> movies;
  
   ListCol({super.key, required this.movies});
  

  @override
  Widget build(BuildContext context) {
    final List<Container> lists = [];
    for(var movie in movies){
      lists.add(Container(
        child: Text(movie.title.toString()),
      ));
    }
    return Column(
      children: lists,
    );
  }
}