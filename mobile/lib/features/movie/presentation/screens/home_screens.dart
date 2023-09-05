
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';
import 'package:mobile/features/movie/presentation/bloc/movie_bloc.dart';
import 'package:mobile/features/movie/presentation/widgets/bookmark_card_widget.dart';
import 'package:mobile/features/movie/presentation/widgets/movie_card_widget.dart';
import 'package:mobile/features/movie/presentation/widgets/search_bar_widget.dart';

import '../../domain/entities/movie.dart';
import '../widgets/header_widget.dart';

class HomeScreen extends StatefulWidget {
 
final BuildContext context;

  HomeScreen({Key? key, required this.context}) : super(key: key);
  @override
  State<HomeScreen> createState() => _HomeScreenState();
}

class _HomeScreenState extends State<HomeScreen> {
  void initState() {
    super.initState();
    BlocProvider.of<MovieBloc>(widget.context).add(GetAllMoviesEvent());
  }
  // Define an onTap callback
  void handleHeaderTap() {
    // Handle the tap action here
    Navigator.of(context).pop();

  }

  void searchByName() {
    // Handle the tap action here
    print('search tapped');
  }

  final List<Movie> movies = [
    Movie(
      id: "64f60760c5539df836e07fe3",
      category: "Action",
      title: "The Lost Treasure",
      description:
          "A group of adventurers embarks on a quest to find a long-lost treasure hidden deep in a mysterious jungle.",
      duration: "2h 15m",
      image:
          "https://fastly.picsum.photos/id/1/200/300.jpg?hmac=jH5bDkLr6Tgy3oAg5khKCHeunZMHq0ehBZr6vGifPLY",
      rating: "7.8",
      createdAt: "2023-09-04T16:35:44.676Z",
    ),
    Movie(
      id: "64f60760c5539df836e07fe3",
      category: "Action",
      title: "The Lost Treasure",
      description:
          "A group of adventurers embarks on a quest to find a long-lost treasure hidden deep in a mysterious jungle.",
      duration: "2h 15m",
      image:
          "https://fastly.picsum.photos/id/1/200/300.jpg?hmac=jH5bDkLr6Tgy3oAg5khKCHeunZMHq0ehBZr6vGifPLY",
      rating: "7.8",
      createdAt: "2023-09-04T16:35:44.676Z",
    ),
  ];

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Container(
        padding: EdgeInsets.only(top: 24.0),
        child: SingleChildScrollView(
          child: SizedBox(
              height: 778.h,

            child: Column(
              children: [
                // Pass the onTap callback to the HeaderWidget
                HeaderWidget(onBackTap: handleHeaderTap),
                SizedBox(
                  height: 15,
                ),
                SearchBarWidget(searchByName: searchByName),
                SizedBox(height: 15.h),
                // BookMarkCard(),
                Expanded(
                  child: ListView(
                    scrollDirection: Axis.horizontal,
                    children: [
                      for (final movie in movies) BookMarkCard(),
                    ],
                  ),
                ),
                SizedBox(height: 10.h),
                Container(
                  width: double.infinity,
                  padding: EdgeInsets.all(16.0),
                  decoration: BoxDecoration(
                    color: Colors.white, // You can change the background color
                  ),
                  child: Container(
                    padding: EdgeInsets.only(left: 10),
                    child: Text(
                      "All Movies",
                      style: TextStyle(
                        fontSize: 20.0,
                        fontWeight: FontWeight.bold,
                      ),
                    ),
                  ),
                ),
          
                Expanded(
                  child: ListView.builder(
                    itemCount: movies.length,
                    itemBuilder: (context, index) {
                      return MovieCardWidget();
                    },
                  ),
                ),
              ],
            ),
          ),
        ),
      ),
    );
  }
}
