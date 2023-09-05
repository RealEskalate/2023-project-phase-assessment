import 'package:flutter/material.dart';

class HeaderWidget extends StatelessWidget {
  final VoidCallback onBackTap;

  HeaderWidget({required this.onBackTap});

  @override
  Widget build(BuildContext context) {
    return Container(
      padding: EdgeInsets.all(16.0),
      decoration: BoxDecoration(
        color: Colors.white, // You can change the background color
      ),
      child: Row(
          mainAxisAlignment: MainAxisAlignment.spaceAround,

        children: [
          // Back Arrow Icon
          GestureDetector(
            onTap: (){},
            child: Icon(
              Icons.arrow_back,
              color: Colors.black,
              size: 30.0,
            ),
          ),
          SizedBox(width: 16.0), // Add some spacing between the back arrow and text
          
          // "Alem Cinema" Text
          Text(
            'Alem Cinema',
            style: TextStyle(
              color: Colors.black,
              fontSize: 24.0,
              fontWeight: FontWeight.bold,
            ),
          ),
        ],
      ),
    );
  }
}
