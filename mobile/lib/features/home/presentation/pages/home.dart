import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:mobile/core/presentation/custom_app_bar.dart';
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
        return Padding(
          padding: EdgeInsets.symmetric(
              horizontal: AppDimension.width(10, context),
              vertical: AppDimension.height(10, context)),
          child: Center(
            child: Stack(
              alignment: Alignment.bottomCenter,
              children: [
                Column(children: [
                  Padding(
                    padding: EdgeInsets.symmetric(
                        vertical: AppDimension.height(20, context),
                        horizontal: AppDimension.width(15, context)),
                    child: Container(
                      height: AppDimension.height(70, context),
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
                            width: AppDimension.width(60, context),
                            decoration: BoxDecoration(
                                color: Colors.blue,
                                borderRadius: BorderRadius.circular(
                                    AppDimension.height(10, context))),
                            child: IconButton(
                              icon:
                                  const Icon(Icons.search, color: Colors.white),
                              onPressed: () {
                                BlocProvider.of<HomeBloc>(context).add(
                                    SearchMovies(term: searchController.text));
                              },
                            ),
                          ),
                        ],
                      ),
                    ),
                  ),
                  getStatus(state: state)
                ])
              ],
            ),
          ),
        );
      }),
    );
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
            child: Text(
              "Couldn't find movies with the given term.",
              style: const TextStyle(fontSize: 18),
            ));
      }
      return Container(
        height: AppDimension.height(480, context),
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
