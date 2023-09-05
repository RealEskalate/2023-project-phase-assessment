import 'package:flutter/foundation.dart';
import 'package:flutter/material.dart';

class CustomAppBar extends StatelessWidget {
  final String title;
  final Icon? icon;
  final BuildContext externalContext;
  const CustomAppBar(
      {super.key,
      required this.title,
      this.icon,
      required this.externalContext});

  @override
  Widget build(BuildContext context) {
    return Container(
      padding: EdgeInsets.symmetric(horizontal: 20),
      child: Row(
        mainAxisAlignment: MainAxisAlignment.spaceBetween,
        children: [
          IconButton(
            onPressed: () {
              Navigator.pop(externalContext);
            },
            icon: Icon(
              Icons.arrow_back_ios,
              color: Colors.black,
            ),
          ),
          Text(
            title,
            style: TextStyle(color: Colors.black),
          ),
          icon ?? Container()
        ],
      ),
    );
  }
}
