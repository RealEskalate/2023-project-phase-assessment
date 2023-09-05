import 'package:flutter/material.dart';

class MovieDetailpage extends StatelessWidget {
  const MovieDetailpage({super.key});

  @override
  Widget build(BuildContext context) {
    return SafeArea(
      child: Scaffold(
        body: Container(
          child: Column(
            children: [
              Row(
                mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                children: [
                  Icon(Icons.arrow_back),
                  Text("Detail", style: TextStyle(fontWeight: FontWeight.bold)),
                  Icon(Icons.bookmark_outline_rounded)
                ],
              ),
              Image.asset("assets/images/image1.jpg"),
              Text("A Man Called Otto"),
              Row(
                children: [
                  Icon(Icons.access_time),
                  Text("1 hour"),
                  Text("|"),
                  Text("Comedy & Drama")
                ],
              ),
              Text("Otto(Tom Hanks) is a man who is easily angry after losing his life. The situation begins to change when the young family moves into proximity"),
              ElevatedButton(
                onPressed: (){}, 
                child: Text("Watch Now"))
            ],
          ),
        ),
      ),
    );
  }
}
