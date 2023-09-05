import 'package:flutter/foundation.dart';
import 'package:flutter/material.dart';

import '../../domain/entities/movie.dart';

class SavedMovieCard extends StatelessWidget {
  const SavedMovieCard({super.key, required this.movie});
  final Movie movie;
  @override
  Widget build(BuildContext context) {
    return Container(
      margin: EdgeInsets.symmetric(horizontal: 5),
      child: Stack(alignment: Alignment.bottomCenter, children: [
        Image.network(
          movie.image,
          width: 200,
          height: 300,
          fit: BoxFit.cover,
        ),
        Container(
          padding: EdgeInsets.symmetric(vertical: 10, horizontal: 20),
          margin: EdgeInsets.only(bottom: 10),
          // width: 200,
          color: Colors.white,
          height: 80,
          child: Column(
            mainAxisAlignment: MainAxisAlignment.spaceAround,
            children: [
              Text(
                movie.title,
                style: TextStyle(fontSize: 18, fontWeight: FontWeight.w500),
              ),
              Row(
                children: [
                  Row(
                    children: [
                      Icon(
                        Icons.star,
                        color: Color.fromARGB(255, 209, 189, 7),
                      ),
                      Text(movie.rating)
                    ],
                  ),
                  SizedBox(
                    width: 20,
                  ),
                  Row(
                    children: [Icon(Icons.access_time), Text(movie.duration)],
                  )
                ],
              )
            ],
          ),
        )
      ]),
    );
  }
}
