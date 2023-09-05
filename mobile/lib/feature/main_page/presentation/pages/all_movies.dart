import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:second/feature/main_page/presentation/bloc/search/bloc/search_bloc.dart';
import 'package:second/feature/main_page/presentation/pages/widgets/saved_movie.dart';

import 'widgets/customize_text_field.dart';
import 'widgets/movie_customize_widget.dart';

class AllMoviePage extends StatelessWidget {
  final TextEditingController searchController = TextEditingController();
  bool isNotSearching = true;
  AllMoviePage({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Center(
          child: Text("Alem Cinema"),
        ),
      ),
      body: SingleChildScrollView(
        child: Container(
          color: const Color.fromARGB(255, 226, 222, 222),
          child: Column(
            children: [
              Row(
                children: [
                  Expanded(
                    flex: 3,
                    child: Padding(
                      padding: const EdgeInsets.symmetric(
                        horizontal: 20,
                        vertical: 10,
                      ),
                      child: CustomizeTextField(
                        hint: "Lookin for shows",
                        controller: searchController,
                      ),
                    ),
                  ),
                  Expanded(
                    flex: 1,
                    child: Padding(
                      padding: const EdgeInsets.symmetric(horizontal: 10),
                      child: ElevatedButton.icon(
                        onPressed: () {},
                        icon: Icon(
                          Icons.search,
                          size: 30,
                        ),
                        label: Text(""),
                      ),
                    ),
                  ),
                ],
              ),
              isNotSearching
                  ? IsNotSearching()
                  : BlocBuilder<SearchBloc, SearchState>(
                      builder: (context, state) {
                        if (state is LoadingSearchState) {
                          return Center(
                            child: CircularProgressIndicator(),
                          );
                        }
                        else if (state is SuccessSearchState){
                          return ListView.builder(itemBuilder: (index){
                            return CustomizeMovieWidget(distribution: state.movies.,);
                          })
                        }
                      },
                    ),
            ],
          ),
        ),
      ),
    );
  }
}

class MoviesColumn extends StatelessWidget {
  const MoviesColumn({super.key});

  @override
  Widget build(BuildContext context) {
    return SingleChildScrollView(
      child: Column(
        children: [
          CustomizeMovieWidget(
            title: "fun",
            distribution: "1h",
            rate: 8,
            image: "asset/12.jpg",
          ),
          CustomizeMovieWidget(
            title: "fun",
            distribution: "1h",
            rate: 8,
            image: "asset/12.jpg",
          ),
          CustomizeMovieWidget(
            title: "fun",
            distribution: "1h",
            rate: 8,
            image: "asset/12.jpg",
          ),
          CustomizeMovieWidget(
            title: "fun",
            distribution: "1h",
            rate: 8,
            image: "asset/12.jpg",
          ),
        ],
      ),
    );
  }
}

class IsNotSearching extends StatelessWidget {
  const IsNotSearching({super.key});

  @override
  Widget build(BuildContext context) {
    return SingleChildScrollView(
      child: Column(
        children: [
          Container(
            color: Colors.white,
            child: Padding(
              padding: const EdgeInsets.all(8.0),
              child: Row(
                children: [
                  Text(
                    "saved book mark",
                    style: TextStyle(
                      fontSize: 20,
                      fontWeight: FontWeight.w700,
                    ),
                  ),
                  Icon(
                    Icons.bookmark_border,
                    color: Colors.blue,
                  ),
                ],
              ),
            ),
          ),
          SingleChildScrollView(
            scrollDirection: Axis.horizontal,
            child: Row(
              mainAxisAlignment: MainAxisAlignment.start,
              children: [
                SavedMovieWidget(
                  catagory: "fun",
                  distribution: "1h",
                  rate: 8,
                  image: "asset/12.jpg",
                ),
                SavedMovieWidget(
                  catagory: "fun",
                  distribution: "1h",
                  rate: 8,
                  image: "asset/12.jpg",
                ),
                SavedMovieWidget(
                  catagory: "fun",
                  distribution: "1h",
                  rate: 8,
                  image: "asset/12.jpg",
                ),
                SavedMovieWidget(
                  catagory: "fun",
                  distribution: "1h",
                  rate: 8,
                  image: "asset/12.jpg",
                ),
                SavedMovieWidget(
                  catagory: "fun",
                  distribution: "1h",
                  rate: 8,
                  image: "asset/12.jpg",
                ),
              ],
            ),
          ),
          Container(
            width: double.infinity,
            color: Colors.white,
            child: Padding(
              padding: const EdgeInsets.all(8.0),
              child: Text(
                "all movies",
                style: TextStyle(
                  fontSize: 20,
                  fontWeight: FontWeight.w700,
                ),
              ),
            ),
          ),
          SizedBox(
            height: 300,
            child: MoviesColumn(),
          ),
        ],
      ),
    );
  }
}
