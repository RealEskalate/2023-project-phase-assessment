import 'package:flutter/material.dart';

class MoviePoster extends StatelessWidget {
  final String movieImage;

  MoviePoster({required this.movieImage});

  @override
  Widget build(BuildContext context) {
    return Container(
      padding: EdgeInsets.all(40.0),
      width: double.infinity,
      height: 600, // Increase the height of this container
      decoration: BoxDecoration(
        image: DecorationImage(
          image: NetworkImage(movieImage),
          fit: BoxFit
              .cover, // Maintain the aspect ratio and cover the entire container
        ),
      ),
      child: Column(
        mainAxisAlignment: MainAxisAlignment.center,
        children: [
          Text(
            'TOM HANKS IS A MAN CALLED OTTO',
            style: TextStyle(
              fontSize: 32,
              fontWeight: FontWeight.bold,
              color: Colors.white,
            ),
            textAlign: TextAlign.center,
          ),
          SizedBox(height: 20),
          Text(
            'BASED ON THE INTERNATIONAL BEST SELLER',
            style: TextStyle(
              fontSize: 18,
              color: Colors.white,
            ),
            textAlign: TextAlign.center,
          ),
        ],
      ),
    );
  }
}
