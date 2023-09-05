import 'package:flutter/material.dart';

class MovieListTitle extends StatelessWidget {
  const MovieListTitle({super.key});

  @override
  Widget build(BuildContext context) {
    return Container(
      height: 40,
      color: Colors.white,
      padding: EdgeInsets.symmetric(horizontal: 15),
      child: Row(children: [
        Text(
          'All Movies',
          style: Theme.of(context).textTheme.titleLarge!.copyWith(
                fontWeight: FontWeight.w500,
              ),
        ),
      ],),
    );
  }
}