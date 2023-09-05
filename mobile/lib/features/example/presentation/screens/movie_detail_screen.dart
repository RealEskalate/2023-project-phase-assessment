import 'package:flutter/material.dart';
import 'package:mobile/features/example/domain/entities/movie.dart';
import 'package:mobile/features/example/presentation/widgets/customized_button.dart';

import '../widgets/movie_detail.dart';

class MovieDetailScreen extends StatelessWidget {
  final Movie movie;
  const MovieDetailScreen({required this.movie, super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
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
          'Detail',
          style: TextStyle(
            color: Colors.black,
          ),
        ),
        actions: [
          IconButton(
            onPressed: () {},
            icon: const Icon(
              Icons.bookmark_border_outlined,
              color: Colors.black,
              size: 25,
            ),
          ),
        ],
        backgroundColor: Colors.white,
        elevation: 0,
      ),
      body: Column(
        children: [
          Expanded(
            child: SingleChildScrollView(
              child: Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  Container(
                    height:320,
                    child: Stack(
                      children: [
                         SizedBox(
                          width: double.infinity,
                          height: 300,
                          child: Image(
                            image: NetworkImage(movie.image),
                            fit: BoxFit.cover,
                          ),
                        ),
                        Positioned(
                          right: 50,
                          bottom: 10,
                          child: Container(
                              width: 70,
                              height: 70,
                              decoration: BoxDecoration(
                                color: Colors.black,
                                borderRadius: BorderRadius.circular(10),
                              ),
                              child:  Column(
                                children: [
                                  Icon(
                                    Icons.star_rounded,
                                    color: Colors.yellow,
                                    size: 40,
                                  ),
                                  Text(
                                    movie.rating,
                                    style: TextStyle(
                                      fontSize: 16,
                                      color: Colors.grey,
                                    ),
                                  ),
                                ],
                              )),
                        ),
                      ],
                    ),
                  ),
                  SizedBox(height: 20),
                  MovieDetail(movie :movie),
                  
                ],
              ),
            ),
          ),
          CustomizedButton(
            onpressed: () {},
            label: 'Watch Now',
          ),
        ],
      ),
    );
  }
}
