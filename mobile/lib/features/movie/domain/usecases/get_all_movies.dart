import 'package:flutter/material.dart';

class GetAllMoviesPage extends StatelessWidget {
  const GetAllMoviesPage({super.key});

  @override
  Widget build(BuildContext context) {
    return SafeArea(
        child: Scaffold(
      body: Column(
        children: [
          const Row(
            children: [
              Icon(Icons.arrow_back),
              Text("Alem Cinema")
            ],
          ),
          Row(
            children: [
              TextFormField(),
              
            ],
          )
        ],
      ),
    ));
  }
}
