import 'dart:async';

import 'package:carousel_slider/carousel_slider.dart';

import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:second/feature/main_page/presentation/bloc/search/bloc/search_bloc.dart';
import 'package:second/feature/main_page/presentation/pages/widgets/saved_movie.dart';

import 'widgets/customize_text_field.dart';
import 'widgets/movie_customize_widget.dart';

class AllMovieMainPage extends StatefulWidget {
  const AllMovieMainPage({super.key});

  @override
  State<AllMovieMainPage> createState() => _AllMovieMainPageState();
}

class _AllMovieMainPageState extends State<AllMovieMainPage> {
  bool isNotSearching = true;
  final TextEditingController searchController = TextEditingController();
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        backgroundColor: Color.fromRGBO(213, 230, 249, 1),
        title: Center(
          child: Text("Alem Cinema"),
        ),
      ),
      body: Container(
        color: Color.fromRGBO(213, 230, 249, 1),
        child: Column(
          children: [
            Expanded(
              flex: 10,
              child: Center(
                child: Padding(
                  padding: const EdgeInsets.symmetric(horizontal: 15.0),
                  child: TextField(
                    onChanged: (value) {
                      if (value.isEmpty) {
                        setState(() {
                          isNotSearching = true;
                        });
                      } else {
                        setState(() {
                          isNotSearching = false;
                        });
                        BlocProvider.of<SearchBloc>(context).add(
                          SearchEventClick(movieName: value),
                        );
                      }
                    },
                    controller: searchController,
                    decoration: InputDecoration(
                      filled: true,
                      fillColor: Color.fromARGB(123, 242, 255, 255),
                      hintText: "Looking Forward",
                      hintStyle: TextStyle(
                        color: Colors.grey,
                      ),
                      border: OutlineInputBorder(
                        borderRadius: BorderRadius.all(
                          Radius.circular(10.0),
                        ),
                      ),
                    ),
                  ),
                ),
              ),
            ),
            Expanded(
              flex: 30,
              child: Column(
                crossAxisAlignment: CrossAxisAlignment.stretch,
                children: [
                  Expanded(
                    flex: 15,
                    child: Container(
                      color: Color.fromARGB(123, 242, 255, 255),
                      child: ListTile(
                        title: Text("Saved Movies"),
                        trailing: Icon(
                          Icons.bookmark_border,
                        ),
                      ),
                    ),
                  ),
                  Expanded(
                    flex: 85,
                    child: Padding(
                      padding: const EdgeInsets.symmetric(vertical: 3.0),
                      child: CarouselSlider(
                        options: CarouselOptions(
                          viewportFraction: 0.58,
                          autoPlay: true,
                          autoPlayInterval: Duration(seconds: 3),
                          autoPlayAnimationDuration:
                              Duration(milliseconds: 800),
                          autoPlayCurve: Curves.fastEaseInToSlowEaseOut,
                          enlargeCenterPage: true,
                        ),
                        items: [1, 2, 3, 4, 5].map((i) {
                          return Builder(
                            builder: (BuildContext context) {
                              return CustomizeMovieWidget();
                            },
                          );
                        }).toList(),
                      ),
                    ),
                  )
                ],
              ),
            ),
            Expanded(
              flex: 60,
              child: Column(
                children: [
                  Expanded(
                    flex: 8,
                    child: Container(
                      color: Color.fromARGB(123, 242, 255, 255),
                      child: ListTile(
                        title: Text("All Movies"),
                        trailing: Icon(
                          Icons.movie,
                        ),
                      ),
                    ),
                  ),
                  Expanded(
                    flex: 92,
                    child: ListView(
                      children: [
                        MovieColWidget(),
                        MovieColWidget(),
                        MovieColWidget(),
                        MovieColWidget(),
                        MovieColWidget(),
                        MovieColWidget(),

                      ],
                    ),
                  ),
                ],
              ),
            ),
          ],
        ),
      ),
    );
  }
}
