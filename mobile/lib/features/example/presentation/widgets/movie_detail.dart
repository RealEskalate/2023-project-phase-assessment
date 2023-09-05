import 'package:flutter/material.dart';

import '../../domain/entities/movie.dart';

class MovieDetail extends StatelessWidget {
  final Movie movie;
  const MovieDetail({
    required this.movie,
    super.key});

  @override
  Widget build(BuildContext context) {
    return Padding(
        padding: EdgeInsets.all(20),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            Text(
              movie.title,
              style: TextStyle(
                fontSize: 30,
                fontWeight: FontWeight.bold,
              ),
            ),
            SizedBox(
              height: 20,
            ),
            Row(
              children: [
                Icon(
                  Icons.access_time,
                ),
                Text(
                  movie.duration,
                  style: TextStyle(
                    color: Colors.grey,
                  ),
                ),
                SizedBox(
                  width: 20,
                ),
                Text(
                  movie.category,
                  style: TextStyle(
                    color: Colors.grey,
                  ),
                ),
              ],
            ),
            SizedBox(
              height: 20,
            ),
            Text(
              movie.description,
            )
          ],
        ));
  }
}
