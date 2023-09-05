import 'package:flutter/material.dart';

class MovieDetailScreen extends StatelessWidget {
  const MovieDetailScreen({super.key, required this.data});
  final List data;

  @override
  Widget build(BuildContext context) {
    double deviceWidth = MediaQuery.of(context).size.width;
    double deviceHeight = MediaQuery.of(context).size.height;
    return Scaffold(
      appBar: AppBar(
        iconTheme: const IconThemeData(color: Colors.black),
        title: const Center(
            child: Text(
          "Movie Detail",
          style: TextStyle(
            color: Colors.black,
            fontSize: 25,
          ),
        )),
        actions: [
          IconButton(
            icon: const Icon(Icons.save_alt_outlined),
            onPressed: () {},
          )
        ],
        backgroundColor: Colors.white,
      ),
      body: Container(
        margin: const EdgeInsets.all(8),
        width: 400,
        height: 450,
        decoration: BoxDecoration(
          borderRadius: BorderRadius.circular(20),
          image: const DecorationImage(
            image: AssetImage(
              "assets/tom hanks.jpg",
            ),
            fit: BoxFit.cover,
          ),
        ),
        child: Stack(
          children: [
            Positioned(
                top: 300,
                left: 150,
                child: Container(
                  color: Colors.amber,
                ))
          ],
        ),
      ),
    );
  }
}
