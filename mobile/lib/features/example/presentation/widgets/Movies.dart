import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:mobile/features/example/domain/entities/movie.dart';
import 'package:mobile/features/example/presentation/bloc/movie_bloc.dart';
import "./MovieWidget.dart";

class Movies extends StatelessWidget {
  const Movies({Key? key});

  @override
  Widget build(BuildContext context) {
    return BlocBuilder<MovieBloc, MovieState>(
      builder: (context, state) {
        return Container(
          margin: EdgeInsets.only(top: 10, bottom: 15),
          child: Column(
            children: [
              Container(
                width: double.infinity,
                height: 50,
                color: Colors.white,
                padding: EdgeInsets.only(left: 10),
                alignment: Alignment.centerLeft,
                child: Text(
                  "All Movies",
                  style: TextStyle(fontSize: 18),
                ),
              ),
              if (state is MovieLoading) CircularProgressIndicator(),
              if (state is MovieLoaded)
                Column(
                  children: getMovies(state.movies),
                ),
              if (state is MovieSearched)
                Column(
                  children: getMovies(state.movies),
                ),
            ],
          ),
        );
      },
    );
  }

  List<Widget> getMovies(List<Movie> movies) {
    List<Widget> result = [];
    for (var item in movies) {
      
      result.add(MovieWidget(
        movie : item
      ));
    }
    return result;
  }
}
