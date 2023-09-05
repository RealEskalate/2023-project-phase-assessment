import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:mobile/features/example/data/models/movie_model.dart';
import 'package:mobile/features/example/presentation/bloc/movie_bloc.dart';
import 'package:mobile/features/example/presentation/screens/detail_page.dart';

class HomePage extends StatelessWidget {
  const HomePage({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        leading: IconButton(
            onPressed: () {
              Navigator.pop(context);
            },
            icon: const Icon(
              Icons.arrow_back_rounded,
              size: 40,
            )),
        title: Text("Alem Cinema"),
        centerTitle: true,
      ),
      body: Container(
        decoration: const BoxDecoration(
          color: Color.fromARGB(255, 235, 234, 234),
          boxShadow: [
            BoxShadow(
              color: Color.fromRGBO(201, 201, 201, 1),
              spreadRadius: 2,
              blurRadius: 5,
              offset: Offset(0, 3),
            ),
          ],
        ),
        child: Column(mainAxisAlignment: MainAxisAlignment.start, children: [
          Padding(
            padding: const EdgeInsets.symmetric(vertical: 20, horizontal: 10),
            child: Align(
              alignment: Alignment.topCenter,
              child: Row(
                children: [
                  Expanded(
                    child: Container(
                      height: 60,
                      decoration: BoxDecoration(
                        color: Colors.white,
                        borderRadius: BorderRadius.circular(
                            10), // Adjust the value to control the roundness
                      ),
                      child: const TextField(
                        decoration: InputDecoration(
                          border: InputBorder.none,
                          hintText: 'Looking for shows',
                          contentPadding: EdgeInsets.all(10),
                        ),
                      ),
                    ),
                  ),
                  SizedBox(width: 20),
                  ElevatedButton(
                    onPressed: () {
                      // Perform search action
                    },
                    child: Icon(
                      Icons.search,
                      color: Colors.white,
                      size: 35,
                    ),
                    style: ElevatedButton.styleFrom(
                        backgroundColor: Colors.blue,
                        shape: RoundedRectangleBorder(
                            borderRadius: BorderRadius.circular(10))),
                  ),
                ],
              ),
            ),
          ),
          Container(
            decoration: BoxDecoration(color: Colors.white),
            child: Padding(
              padding: const EdgeInsets.symmetric(vertical: 5, horizontal: 15),
              child: Align(
                alignment: Alignment.topCenter,
                child: Row(
                  children: [
                    const Text(
                      "Saved Movies",
                      style: TextStyle(
                        fontSize: 25,
                      ),
                    ),
                    SizedBox(width: 10),
                    IconButton(
                      onPressed: () {},
                      icon: const Icon(
                        Icons.bookmark_border,
                        color: Colors.blue,
                        size: 35,
                      ),
                    ),
                  ],
                ),
              ),
            ),
          ),
          const BooKMarkWidget(),
          Container(
            width: 400,
            decoration: BoxDecoration(color: Colors.white),
            child: Padding(
              padding: const EdgeInsets.symmetric(vertical: 5, horizontal: 20),
              child: Text(
                "All Movies",
                style: TextStyle(
                  fontSize: 25,
                ),
              ),
            ),
          ),
          SizedBox(
            height: 3,
          ),
          SizedBox(
            height: 100,
            width: 400,
            child: ElevatedButton(
              onPressed: () {
                Navigator.push(
                    context,
                    MaterialPageRoute(
                      builder: (context) => DetailPage(),
                    ));
              },
              child: BlocConsumer<MovieBloc, MovieState>(
                listener: (context, state) {
                  if (state is MovieLoadedAll) {
                    ScaffoldMessenger.of(context).showSnackBar(
                      SnackBar(
                        content: Text('Movies loaded successfully.'),
                        backgroundColor: Colors.green,
                      ),
                    );
                  } else if (state is MovieFailed) {
                    ScaffoldMessenger.of(context).showSnackBar(
                      SnackBar(
                        content: Text('Failed to load movies.'),
                        backgroundColor: Colors.red,
                      ),
                    );
                  }
                },
                builder: (context, state) {
                  if (state is MovieLoadedAll) {
                    return ListView.builder(
                      itemCount: state.movie.length,
                      itemBuilder: (context, index) =>
                          AllMoviesWidget(movieModel: state.movie[index]),
                    );
                  } else if (state is MovieLoading) {
                    return Center(
                      child: CircularProgressIndicator(
                        color: Colors.blue,
                      ),
                    );
                  } else if (state is MovieInitial) {
                    BlocProvider.of<MovieBloc>(context).add(GetMoviesEvent());
                  }

                  return Container();
                },
              ),
            ),
          )
        ]),
      ),
    );
  }
}

class AllMoviesWidget extends StatelessWidget {
  final MovieModel movieModel;
  AllMoviesWidget({
    required this.movieModel,
    super.key,
  });

  @override
  Widget build(BuildContext context) {
    return Container(
      height: 100,
      width: 380,
      margin: EdgeInsets.symmetric(horizontal: 10),
      decoration: BoxDecoration(
          color: Colors.white,
          borderRadius: BorderRadius.all(Radius.circular(20))),
      child: Row(children: [
        Container(
          height: 80,
          width: 120,
          margin: EdgeInsets.symmetric(horizontal: 10),
          decoration: BoxDecoration(
              image: DecorationImage(
                image: NetworkImage(
                    movieModel.image ?? ''), // Replace with your image path
                fit: BoxFit.cover,
              ),
              borderRadius: BorderRadius.all(
                Radius.circular(15),
              )),
        ),
        Column(
          children: [
            Padding(
              padding: EdgeInsets.all(8.0),
              child: Text(
                movieModel.title!,
                style: TextStyle(fontSize: 15, fontWeight: FontWeight.bold),
              ),
            ),
            Padding(
              padding: EdgeInsets.symmetric(horizontal: 5),
              child: Row(
                children: [
                  Icon(
                    Icons.star,
                    color: Colors.yellow,
                  ),
                  Text(movieModel.rating!.toString()),
                  SizedBox(
                    width: 20,
                  ),
                  Icon(Icons.watch_later_outlined),
                  Text(movieModel.duration! + "hour"),
                ],
              ),
            )
          ],
        )
      ]),
    );
  }
}

class BooKMarkWidget extends StatelessWidget {
  const BooKMarkWidget({
    super.key,
  });

  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: const EdgeInsets.all(20),
      child: SizedBox(
        width: 400,
        height: 300,
        child: ListView(
          scrollDirection: Axis.horizontal,
          children: [
            Expanded(
              child: Container(
                width: 260,
                height: 50,
                decoration: BoxDecoration(
                  borderRadius: BorderRadius.all(Radius.circular(20)),
                  image: DecorationImage(
                    image: AssetImage(
                        'assets/images/on_boarding.jpg'), // Replace with your image path
                    fit: BoxFit.cover,
                  ),
                ),
                child: Column(
                  children: [
                    SizedBox(
                      height: 170,
                    ),
                    Padding(
                      padding: const EdgeInsets.symmetric(
                          horizontal: 20, vertical: 10),
                      child: Container(
                        height: 100,
                        width: 300,
                        decoration: const BoxDecoration(
                            color: Colors.white,
                            borderRadius:
                                BorderRadius.all(Radius.circular(20))),
                        child: const Column(
                            crossAxisAlignment: CrossAxisAlignment.start,
                            children: [
                              Padding(
                                padding: EdgeInsets.symmetric(
                                    horizontal: 20, vertical: 10),
                                child: Text(
                                  "Autobiography",
                                  style: TextStyle(
                                      fontSize: 20,
                                      fontWeight: FontWeight.bold),
                                ),
                              ),
                              Padding(
                                padding: EdgeInsets.symmetric(horizontal: 20),
                                child: Row(
                                  children: [
                                    Icon(
                                      Icons.star,
                                      color: Colors.yellow,
                                    ),
                                    Text("4.5"),
                                    SizedBox(
                                      width: 20,
                                    ),
                                    Icon(Icons.watch_later_outlined),
                                    Text("1 hour"),
                                  ],
                                ),
                              ),
                            ]),
                      ),
                    )
                  ],
                ),
              ),
            ),

            // Add more widgets here...
          ],
        ),
      ),
    );
  }
}
