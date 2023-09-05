import 'dart:async';

import 'package:flutter/material.dart';

import '../screens/search_result.dart';

Widget searchBar(BuildContext context) {
  final TextEditingController _searchController = TextEditingController();
  final StreamController<String> _searchStreamController =
      StreamController<String>();
  return Container(
    margin: const EdgeInsets.only(top: 0, right: 20, left: 20, bottom: 0),
    height: 50,
    decoration: BoxDecoration(
      color: Colors.white,
      borderRadius: BorderRadius.circular(12),
    ),
    child: Row(
      children: [
        Expanded(
          child: TextField(
            controller: _searchController,
            onChanged: (value) {
              _searchStreamController.add(value);
            },
            decoration: InputDecoration(
              hintText: "Looking for a shows?",
              hintStyle: TextStyle(
                fontFamily: 'Poppins-ExtraLight',
                color: Colors.grey.shade400,
                fontSize: 15,
              ),
              contentPadding: const EdgeInsets.only(
                  left: 10, top: 12, bottom: 12), // Add padding here
              border: InputBorder.none,
              suffixIcon: Container(
                width: 50,
                height: 100,
                decoration: BoxDecoration(
                  color: const Color(0xff337BFF),
                  borderRadius: BorderRadius.circular(12),
                ),
                child: IconButton(
                  icon: const Icon(
                    Icons.search,
                    size: 32,
                  ),
                  color: Colors.white,
                  onPressed: () {
                    Navigator.push(
                      context,
                      MaterialPageRoute(
                        builder: (context) => SearchResult(
                          keyword: _searchController.text,
                        ),
                      ),
                    );
                  },
                ),
              ),
            ),
          ),
        ),
        const Padding(padding: EdgeInsets.only(bottom: 7))
      ],
    ),
  );
}
