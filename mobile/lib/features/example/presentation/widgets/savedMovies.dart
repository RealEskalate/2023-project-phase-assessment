import 'package:flutter/material.dart';

class SavedMovies extends StatefulWidget {
  const SavedMovies({super.key});

  @override
  State<SavedMovies> createState() => _SavedMoviesState();
}

class _SavedMoviesState extends State<SavedMovies> {
  @override
  Widget build(BuildContext context) {
    return ListView.builder(
      scrollDirection: Axis.horizontal,
      itemCount: 3,
      itemBuilder: (context, index) {
        return Container(
          width: 80,
          height: 150,
          margin: EdgeInsets.symmetric(horizontal: 8.0),
          child: Stack(
            children: [
              Container(
                width: 80,
                height: 150,
                child: Image.asset('assets/images/onboarding.jpg'),
              )
            ],
          ),
        );
      },
    );
  }
}
