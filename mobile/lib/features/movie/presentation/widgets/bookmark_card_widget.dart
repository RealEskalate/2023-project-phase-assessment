import 'package:flutter/material.dart';

class BookMarkCard extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Card(
      elevation: 4.0, // Card elevation for a shadow effect
      shape: RoundedRectangleBorder(
        borderRadius: BorderRadius.circular(15.0), // Rounded corners
      ),
      child: Column(
        children: [
          Container(
            height: 200.0,
            decoration: BoxDecoration(
              image: DecorationImage(
                image: AssetImage('assets/images/image.jpeg'), // Background image
                fit: BoxFit.cover,
              ),
            ),
            child: Container(
              padding: EdgeInsets.all(16.0),
              color: Color(0xAA000000), // Semi-transparent background overlay
              child: Column(
                mainAxisAlignment: MainAxisAlignment.center,
                children: [
                  Text(
                    'Autobiography',
                    style: TextStyle(
                      color: Colors.white,
                      fontSize: 24.0,
                      fontWeight: FontWeight.bold,
                    ),
                  ),
                  SizedBox(height: 16.0),
                  Row(
                    mainAxisAlignment: MainAxisAlignment.spaceAround,
                    children: [
                      Row(
                        children: [
                          Icon(
                            Icons.star,
                            color: Colors.yellow,
                          ),
                          SizedBox(width: 4.0),
                          Text(
                            '5.0',
                            style: TextStyle(
                              color: Colors.white,
                            ),
                          ),
                        ],
                      ),
                      Row(
                        children: [
                          Icon(
                            Icons.remove_red_eye,
                            color: Colors.white,
                          ),
                          SizedBox(width: 4.0),
                          Text(
                            '100K',
                            style: TextStyle(
                              color: Colors.white,
                            ),
                          ),
                        ],
                      ),
                    ],
                  ),
                ],
              ),
            ),
          ),
          // Other content for the card can be added here
        ],
      ),
    );
  }
}