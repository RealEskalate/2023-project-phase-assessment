// ignore_for_file: curly_braces_in_flow_control_structures

import 'package:dartz/dartz.dart';
import 'package:flutter/material.dart';
import 'package:mobile/core/routes/movie_routes.dart';
import 'package:mobile/features/example/presentation/widgets/bookmarked_card.dart';
import 'package:mobile/features/example/presentation/widgets/custom_input.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:mobile/injection/dependency_injection.dart';

import '../bloc/movie_bloc.dart';
import '../widgets/move_card.dart';

class HomeScreen extends StatelessWidget {
  final controller = TextEditingController();
  HomeScreen({super.key});
  @override
  Widget build(BuildContext context) {
    return BlocProvider(
      create: (context) => sl<MovieBloc>()..add(GetAllMoviesEvent()),
      child: Scaffold(
        appBar: AppBar(
          centerTitle: true,
          leading: IconButton(
            icon: const Icon(
              Icons.arrow_back,
            ),
            color: Colors.black,
            onPressed: () {
              Navigator.pop(context);
            },
          ),
          title: const Text(
            'Alem Cinema',
            style: TextStyle(
              color: Colors.black,
            ),
          ),
          backgroundColor: Colors.white,
          elevation: 0,
        ),
        body: Padding(
          padding: const EdgeInsets.all(15.0),
          child: Column(
            children: [
              CustomInput(
                controller: controller,
              ),
              const SizedBox(height: 20),
              BlocConsumer<MovieBloc, MovieState>(
                  listener: (context, state) {},
                  builder: (context, state) {
                    if (state is MovieLoading) {
                      return const CircularProgressIndicator();
                    } 
                    else if (state is AllMovieLoaded)
                      return Expanded(
                        child: Column(
                          children: [
                            const BookmarkedCard(),
                            const SizedBox(height: 20),
                            const Align(
                              alignment: Alignment.centerLeft,
                              child: Text(
                                'All Movies',
                                style: TextStyle(
                                  color: Colors.black,
                                  fontSize: 20,
                                  fontWeight: FontWeight.w400,
                                ),
                              ),
                            ),
                            const SizedBox(height: 20),
                            Expanded(
                              child: ListView.separated(
                                itemCount: state.movies.length,
                                itemBuilder: (context, index) {
                                  return GestureDetector(
                                    onTap: () {
                                      Navigator.pushNamed(context,
                                          MovieAppRoutes.MOVIE_DETAIL,
                                          arguments: state.movies[index]);
                                    },
                                    child: MovieCard(
                                      movie: state.movies[index],
                                    ),
                                  );
                                },
                                separatorBuilder: (context, index) {
                                  return SizedBox(height: 20);
                                },
                              ),
                            ),
                          ],
                        ),
                      );
                    else if(state is MovieLoaded) {
                      if (state.movies.isEmpty) {
                        return const Center(
                          child: Text('No movie'),
                        );
                      } else {
                        return Expanded(
                          child: ListView.separated(
                            itemCount: state.movies.length,
                            itemBuilder: (context, index) {
                              return GestureDetector(
                                onTap: () { 
                                  Navigator.pushNamed(
                                    context, MovieAppRoutes.MOVIE_DETAIL,
                                    arguments: state.movies[index]);
                                    
                                    },
                                child: MovieCard(
                                  movie: state.movies[index],
                                ),
                              );
                            },
                            separatorBuilder: (context, index) {
                              return const SizedBox(height: 20);
                            },
                          ),
                        );
                      }
                    }
          
                    return const Center(
                      child:
                          Text('There is an error while search for Movies'),
                    );
                  }),
            ],
          ),
        ),
      ),
    );
  }
}
