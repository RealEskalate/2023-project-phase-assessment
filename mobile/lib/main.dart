import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:mobile/features/movies/domain/entities/movie.dart';
import 'package:mobile/features/movies/presentation/bloc/movie_bloc.dart';
import 'package:mobile/features/movies/presentation/screens/detail_screen.dart';
import 'package:mobile/features/movies/presentation/screens/onboarding.dart';
import 'package:mobile/features/movies/presentation/widgets/movie_card.dart';
import 'package:mobile/features/movies/presentation/widgets/movie_card_title.dart';
import 'package:mobile/features/movies/presentation/widgets/movie_list_title.dart';
import 'package:mobile/features/movies/presentation/widgets/movie_list_view_card.dart';
import 'package:mobile/features/movies/presentation/widgets/search_bar.dart';
import 'package:mobile/injection/setup.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

void main() async {
  WidgetsFlutterBinding.ensureInitialized();
  await setup();
  runApp(MyApp());
}

class MyApp extends StatelessWidget {
  MyApp({super.key});

  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Flutter Demo',
      debugShowCheckedModeBanner: false,
      theme: ThemeData(
        colorScheme: ColorScheme.fromSeed(seedColor: Colors.blue),
        useMaterial3: true,
      ),
      home: OnBoarding(),
    );
  }
}

class HomeScreen extends StatelessWidget {
  const HomeScreen({
    super.key,
  });

  @override
  Widget build(BuildContext context) {
    TextEditingController controller = TextEditingController();
    return BlocProvider(
      create: (context) =>
          sl<MovieBloc>()..add(const GetMoviesEvent(searchParams: "")),
      child: Scaffold(
          backgroundColor: Color.fromARGB(255, 228, 234, 235),
          appBar: AppBar(
            backgroundColor: Colors.white,
            centerTitle: true,
            title: Text("Alem Cinema"),
            leading: IconButton(
                icon: Icon(Icons.arrow_back_ios_new),
                onPressed: () {
                  Navigator.pop(context);
                }),
          ),
          body: BlocBuilder<MovieBloc, MovieState>(
            builder: (context, state) {
              final listOfArticle =
                  state is MovieLoaded || state is MovieSearchState
                      ? MovieListView(movie: state.movies)
                      : state is MovieLoading
                          ? Center(child: CircularProgressIndicator())
                          : Container();
              final listOfBookMark =
                  state is MovieSearchLoading || state is MovieSearchState
                      ? Container()
                      : Column(
                          children: [
                            MovieCardTitle(),
                            SizedBox(height: 10),
                            MovieList(movies: state.bookMarkedMovies),
                          ],
                        );
              return SingleChildScrollView(
                controller: ScrollController(),
                child: Column(
                  children: [
                    SizedBox(
                      height: 10,
                    ),
                    CustomInputField(controller: controller),
                    SizedBox(
                      height: 10,
                    ),
                    listOfBookMark,
                    SizedBox(height: 10),
                    MovieListTitle(),
                    SizedBox(height: 10),
                    listOfArticle
                  ],
                ),
              );
            },
          )),
    );
  }
}
