import 'package:flutter/material.dart';

class MovieCardTitle extends StatelessWidget {
  const MovieCardTitle({super.key});

  @override
  Widget build(BuildContext context) {

    return Container(
      height: 50,
      color: Colors.white,
      padding: EdgeInsets.symmetric(horizontal: 15),
      child: Row(children: [
        Text(
          'Saved Movies',
          style: Theme.of(context).textTheme.titleLarge!.copyWith(
                fontWeight: FontWeight.w400,
              ),
        ),
        SizedBox(width: 20,),
        Icon(Icons.bookmark),
      ],),
    );
  }
}