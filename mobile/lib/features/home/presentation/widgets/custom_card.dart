import 'package:flutter/material.dart';

class CustomCard extends StatelessWidget {
  final String title;
  final String rating;
  final String duration;
  final String image;
  CustomCard(
      {required this.title,
      required this.rating,
      required this.duration,
      required this.image});

  @override
  Widget build(BuildContext context) {
    return Card(
      elevation: 4,
      shape: RoundedRectangleBorder(
          borderRadius: BorderRadius.circular(20) // ed border radius here
          ),
      margin: EdgeInsets.symmetric(horizontal: 20, vertical: 10),
      child: Row(
        children: [
          Container(
            width: 130,
            height: 140,
            child: Image.network(
              image,
              fit: BoxFit.cover,
            ),
          ),
          Container(
            height: 140,
            margin: EdgeInsets.only(left: 30),
            child: Column(
              // crossAxisAlignment: CrossAxisAlignment.center,
              mainAxisAlignment: MainAxisAlignment.center,
              children: [
                Text(
                  title,
                  style: TextStyle(
                    fontSize: 18,
                    fontWeight: FontWeight.bold,
                  ),
                ),
                SizedBox(height: 25),
                Row(
                  children: [
                    Row(
                      children: [
                        Icon(
                          Icons.star,
                          color: Color.fromARGB(255, 217, 163, 0),
                        ),
                        Text(
                          rating,
                          style: TextStyle(
                            fontSize: 16,
                          ),
                        ),
                      ],
                    ),
                    SizedBox(width: 20),
                    Row(
                      children: [
                        Icon(Icons.history),
                        Text(
                          duration,
                          style: TextStyle(
                            fontSize: 14,
                          ),
                        ),
                      ],
                    ),
                  ],
                )
              ],
            ),
          ),
        ],
      ),
    );
  }
}
