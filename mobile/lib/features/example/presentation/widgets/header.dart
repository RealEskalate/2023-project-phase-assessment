import 'package:flutter/material.dart';

class CustomHeader extends StatelessWidget {
  final String name;
  final bool hasNotification;

  CustomHeader({
    required this.name,
    this.hasNotification = false,
  });

  @override
  Widget build(BuildContext context) {
    return Container(
      color: Colors.white,
      padding: EdgeInsets.all(16.0),
      child: Row(
        mainAxisAlignment: MainAxisAlignment.spaceBetween,
        children: [
          Row(
            children: [
              CircleAvatar(
                radius: 30,
                backgroundColor:
                    Colors.grey, // You can set a default background color
                backgroundImage: AssetImage(
                    'assets/images/coding.png'), // Replace with your image asset
              ),
              SizedBox(width: 10),
              Text(
                name,
                style: TextStyle(
                  fontSize: 20,
                  fontWeight: FontWeight.bold,
                ),
              ),
            ],
          ),
          Icon(
            Icons.notifications,
            color: hasNotification ? Colors.red : Colors.grey,
            size: 30,
          ),
        ],
      ),
    );
  }
}
