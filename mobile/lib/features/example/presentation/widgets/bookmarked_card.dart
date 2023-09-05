import 'package:flutter/material.dart';
import 'package:mobile/features/example/presentation/widgets/bookmarked_movies.dart';

class BookmarkedCard extends StatelessWidget {
  const BookmarkedCard({super.key});

  @override
  Widget build(BuildContext context) {
    return Column(
      children: [
        const Row(
          children: [
            Text(
              'Saved Movies',
              style: TextStyle(
                color: Colors.black,
                fontSize: 20,
                fontFamily: 'Inter',
                fontWeight: FontWeight.w400,
              ),
            ),
            SizedBox(
              width: 10,
            ),
            Icon(
              Icons.bookmark_outline_outlined,
            ),
          ],
        ),
        SizedBox(
          height: 10,
        ),
        SizedBox(
          height: 300,
          width: 500,
          child: ListView.separated(
              separatorBuilder: (_, __) => const SizedBox(width: 20),
              scrollDirection: Axis.horizontal,
              itemCount: 5,
              itemBuilder: (_, ind) {
                return BookmarkedMovies();
              }),
        ),
      ],
    );
  }
}
