import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:mobile/core/presentation/custom_app_bar.dart';
import 'package:mobile/features/home/presentation/widgets/saved_movies.dart';
import 'package:mobile/features/movie_detail/presentation/pages/movie_detail.dart';

import '../../../../core/utils/app_dimension.dart';
import '../bloc/home_bloc.dart';
import '../widgets/custom_card.dart';

class HomePage extends StatefulWidget {
  const HomePage({super.key});

  @override
  State<HomePage> createState() => _HomePageState();
}

class _HomePageState extends State<HomePage> {
  bool showSaved = true;
  @override
  Widget build(BuildContext context) {
    @override
    void initState() {
      super.initState();
    }

    TextEditingController searchController = TextEditingController();
    return Scaffold(
      appBar: AppBar(
          automaticallyImplyLeading: false,
          backgroundColor: Colors.white,
          title: CustomAppBar(
            title: "Alem Cinema",
            externalContext: context,
          )),
      backgroundColor: Colors.grey.shade100,
      body: BlocBuilder<HomeBloc, HomeState>(builder: (context, state) {
        return Container(
          child: Column(children: [
            Container(
              padding: EdgeInsets.symmetric(
                  vertical: AppDimension.height(25, context),
                  horizontal: AppDimension.width(15, context)),
              child: Container(
                height: AppDimension.height(55, context),
                decoration: BoxDecoration(
                  color: Colors.white,
                  borderRadius: BorderRadius.circular(8),
                ),
                child: Row(
                  children: [
                    Expanded(
                      child: Padding(
                        padding: EdgeInsets.only(
                            left: AppDimension.width(10, context)),
                        child: TextField(
                          onSubmitted: (value) {
                            setState(() {
                              showSaved = false;
                            });
                            BlocProvider.of<HomeBloc>(context)
                                .add(SearchMovies(term: value));
                          },
                          controller: searchController,
                          decoration: const InputDecoration(
                            hintText: 'Looking for shows',
                            hintStyle: TextStyle(color: Colors.grey),
                            border: InputBorder.none,
                          ),
                          style: TextStyle(
                            color: Colors.black,
                            fontSize: AppDimension.height(20, context),
                          ),
                        ),
                      ),
                    ),
                    Container(
                      height: double.infinity,
                      width: AppDimension.width(55, context),
                      decoration: BoxDecoration(
                          color: const Color.fromARGB(255, 30, 137, 255),
                          borderRadius: BorderRadius.circular(
                              AppDimension.height(10, context))),
                      child: IconButton(
                        icon: const Icon(Icons.search, color: Colors.white),
                        onPressed: () {
                          setState(() {
                            showSaved = false;
                          });
                          BlocProvider.of<HomeBloc>(context)
                              .add(SearchMovies(term: searchController.text));
                        },
                      ),
                    ),
                  ],
                ),
              ),
            ),
            showSaved ? getSavedMovies(state: state) : Container(),
            Container(
                width: double.infinity,
                margin: EdgeInsets.only(left: 20, bottom: 15, top: 15),
                child: Text(
                  "All Movies",
                  style: TextStyle(fontSize: 24, fontWeight: FontWeight.w500),
                )),
            getStatus(state: state)
          ]),
        );
      }),
    );
  }

  Widget getSavedMovies({final state}) {
    if (state is Loaded) {
      return SavedMovies(movies: state.movies);
    }
    return Container();
  }

  Widget getStatus({final state}) {
    if (state is Loading) {
      return Container(
        margin: const EdgeInsets.only(top: 250),
        child: const CircularProgressIndicator(),
      );
    } else if (state is Loaded) {
      if (state.movies.isEmpty) {
        return Container(
            margin: const EdgeInsets.only(top: 250),
            child: const Text(
              "Couldn't find movies with the given term.",
              style: const TextStyle(fontSize: 18),
            ));
      }
      return Expanded(
        child: ListView.builder(
          itemCount: state.movies.length,
          itemBuilder: (context, index) {
            return GestureDetector(
              onTap: () {
                Navigator.push(
                    context,
                    MaterialPageRoute(
                        builder: (context) => MovieDetail(
                              movie: state.movies[index],
                            )));
              },
              child: CustomCard(
                title: state.movies[index].title,
                duration: state.movies[index].duration,
                rating: state.movies[index].rating,
                image: state.movies[index].image,
              ),
            );
          },
        ),
      );
    } else if (state is Error) {
      return Container(
          margin: const EdgeInsets.only(top: 250),
          child: Text(
            state.message,
            style: const TextStyle(fontSize: 18),
          ));
    } else {
      BlocProvider.of<HomeBloc>(context).add(GetAllMovies());
      return const Text("");
    }
  }
}
