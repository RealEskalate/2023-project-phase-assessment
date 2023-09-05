import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:mobile/features/example/presentation/bloc/movie_bloc.dart';
import 'package:mobile/features/example/presentation/widgets/Movies.dart';
import 'package:mobile/features/example/presentation/widgets/custome_search_bar.dart';
import 'package:mobile/features/example/presentation/widgets/saved_movies.dart';

class Home extends StatelessWidget {
  const Home({super.key});

  @override
  Widget build(BuildContext context) {
    return BlocBuilder<MovieBloc, MovieState>(
      builder: (context, state) {
        return Scaffold(
          backgroundColor: Color.fromARGB(255, 228, 234, 235),
          appBar: AppBar(
            centerTitle: true,
            leading: IconButton(
              icon: Icon(Icons.arrow_back),
              onPressed: () {
                Navigator.of(context).pop();
              },
            ),
            title: Text("Alem Cinema"),
          ),
          body: SingleChildScrollView(
            child: Column(
              mainAxisAlignment: MainAxisAlignment.start,
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                CustomeSearchBar(),
                Container(
                  width: double.infinity,
                  padding: EdgeInsets.only(left: 20),
                  height: 40,
                  decoration: BoxDecoration(
                    color: Colors.white,
                  ),
                  child: Row(
                    mainAxisAlignment:
                        state is MovieSearching || state is MovieSearched
                            ? MainAxisAlignment.end
                            : MainAxisAlignment.start,
                    children: [
                      if (!(state is MovieSearching) &&
                          !(state is MovieSearched))
                        Text(
                          "Saved Movies",
                          style: TextStyle(fontSize: 20),
                        ),
                      if (!(state is MovieSearching) &&
                          !(state is MovieSearched))
                        SizedBox(width: 20),
                      if (!(state is MovieSearching) &&
                          !(state is MovieSearched))
                        Icon(
                          Icons.bookmark_border,
                          color: Colors.blue,
                        ),
                      if (state is MovieSearching || state is MovieSearched)
                        IconButton(
                          onPressed: (){
                            context
                                  .read<MovieBloc>()
                                  .add(GetMovies());
                          },
                          icon: Icon(Icons.close),
                        ),
                    ],
                  ),
                ),
                if (!(state is MovieSearching) && !(state is MovieSearched))
                  SavedMovies(),
                if (state is MovieSearching)
                  Center(child: CircularProgressIndicator()),
                Movies(),
              ],
            ),
          ),
        );
      },
    );
  }
}
