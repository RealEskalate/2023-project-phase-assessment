import 'package:flutter/material.dart';

class DetailHeaderWidget extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Row(
      mainAxisAlignment: MainAxisAlignment.spaceBetween,
      children: [
        IconButton(
          icon: Icon(Icons.arrow_back),
          onPressed: () {
            // Handle the back button action here
            Navigator.of(context).pop();
          },
        ),
        Text(
          "Detail",
          style: TextStyle(
            fontSize: 20, // Adjust the font size as needed
            fontWeight: FontWeight.bold, // Add fontWeight as needed
          ),
        ),

        IconButton(
          icon: Icon(Icons.bookmark),
          onPressed: () {
            // Handle the bookmark icon action here
          },
        ),
      ],
    );
  }
}
