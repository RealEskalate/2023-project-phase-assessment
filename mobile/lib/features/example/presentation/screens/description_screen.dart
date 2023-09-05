
import 'package:flutter/material.dart';
import 'package:go_router/go_router.dart';
import 'package:mobile/features/example/presentation/widgets/movie_description.dart';

class DescriptionScreen extends StatelessWidget {
  final String id;

  const DescriptionScreen({super.key, required this.id});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        appBar: AppBar(
          backgroundColor: Colors.white,
          elevation: 0,
          leading: BackButton(
            onPressed: () => context.pop(),
            color: Colors.black,
          ),
          actions: [
            IconButton(
                onPressed: () {},
                icon: Icon(
                  Icons.bookmark_outline,
                  color: Colors.black,
                ))
          ],
          title: Text(
            "Detail",
            style: TextStyle(color: Colors.black),
          ),
        ),
        body: MovieDesription());
  }
}