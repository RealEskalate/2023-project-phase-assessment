import 'package:flutter/foundation.dart';
import 'package:flutter/material.dart';

class CustomAppBar extends StatefulWidget {
  final String title;
  final Icon? icon;
  final BuildContext externalContext;

  const CustomAppBar(
      {super.key,
      required this.title,
      this.icon,
      required this.externalContext});

  @override
  State<CustomAppBar> createState() => _CustomAppBarState();
}

class _CustomAppBarState extends State<CustomAppBar> {
  bool isSaved = true;

  @override
  Widget build(BuildContext context) {
    return Container(
      padding: EdgeInsets.symmetric(horizontal: 20),
      child: Row(
        mainAxisAlignment: MainAxisAlignment.spaceBetween,
        children: [
          IconButton(
            onPressed: () {
              Navigator.pop(widget.externalContext);
            },
            icon: Icon(
              Icons.arrow_back_ios,
              color: Colors.black,
            ),
          ),
          Text(
            widget.title,
            style: TextStyle(color: Colors.black),
          ),
          (widget.icon != null)
              ? IconButton(
                  onPressed: () {
                    setState(() {
                      isSaved = !isSaved;
                    });
                  },
                  icon: isSaved
                      ? Icon(
                          Icons.bookmark,
                          color: Colors.black,
                        )
                      : Icon(
                          Icons.bookmark_outline,
                          color: Colors.black,
                        ))
              : Container()
        ],
      ),
    );
  }
}
