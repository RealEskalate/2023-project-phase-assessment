
import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';
import 'package:mobile/features/example/domain/entities/movie.dart';

class MovieCard extends StatelessWidget {
  final Movie movie;
  final VoidCallback onMovieSelect;
  const MovieCard(
      {super.key, required this.movie, required this.onMovieSelect});

  @override
  Widget build(BuildContext context) {
    return InkWell(
      onTap: onMovieSelect,
      child: Container(
        alignment: Alignment.center,
        width: 280.w,
        decoration: BoxDecoration(
          color: Colors.white,
          borderRadius: BorderRadius.circular(20),
        ),
        child: Row(
          children: [
            SizedBox(
              width: 15.w,
            ),
            ClipRRect(
                borderRadius: BorderRadius.circular(15),
                child: Image.asset(
                  movie.image,
                  width: 120,
                  height: 80,
                  fit: BoxFit.cover,
                )),
            SizedBox(
              width: 10.w,
            ),
            Expanded(
              child: Column(
                children: [
                  Text(movie.title),
                  Row(
                    children: [
                      Row(
                        children: [
                          Icon(
                            Icons.star,
                            color: Colors.yellow,
                          ),
                          Text(movie.rating.toString())
                        ],
                      ),
                      SizedBox(
                        width: 10.w,
                      ),
                      Row(
                        children: [
                          Icon(
                            Icons.access_time,
                            color: Colors.blue,
                          ),
                          Text(movie.duration),
                        ],
                      ),
                    ],
                  )
                ],
              ),
            )
          ],
        ),
      ),
    );
  }
}