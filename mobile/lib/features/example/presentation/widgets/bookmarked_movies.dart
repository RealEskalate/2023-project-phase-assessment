import 'package:flutter/material.dart';

import 'bookmarked_card.dart';

class BookmarkedMovies extends StatelessWidget {
  const BookmarkedMovies({super.key});

  @override
  Widget build(BuildContext context) {
    return Container(
      child: Stack(
        children: [
          Container(
            width: 200,
            height: 300,
            child: Image(
              fit: BoxFit.cover,
              image: AssetImage('assets/images/article.jpg'),
            ),
          ),
          Positioned(
            bottom: 15,
            left: 20,
            right: 20,
            child: Container(
              width: 100,
              height: 60,
              decoration: BoxDecoration(
                color: Colors.white,
                borderRadius: BorderRadius.circular(10),
              ),
              child: const Column(
                mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                children: [
                  Text(                   
                    "AutoBiography",
                    maxLines: 1,
                    overflow: TextOverflow.ellipsis,
                    style: TextStyle(
                      fontSize: 16,
                      fontWeight: FontWeight.bold,
                    )
                  ),
                  Row(
                    children: [
                      Icon(
                        Icons.star,
                        color: Colors.yellow,
                      ),
                      Text(
                        "9.5",
                      ),
                    SizedBox(
                      width: 10,
                    ),
                    Icon(
                      Icons.access_time,
                    ),
                      Text(
                        "2h 30m",
                    )
                    ],
                  )
                ],
              ),
            ),
          )
        ],
      ),
    );
  }
}
