import 'package:flutter/material.dart';
import 'package:mobile/features/movie/presentation/widgets/bookmark_card_widget.dart';
import 'package:mobile/features/movie/presentation/widgets/movie_card_widget.dart';
import 'package:mobile/features/movie/presentation/widgets/search_bar_widget.dart';

import '../widgets/header_widget.dart';

class HomeScreen extends StatelessWidget {
  const HomeScreen({super.key});

  // Define an onTap callback
  void handleHeaderTap() {
    // Handle the tap action here
    print('Header tapped');
  }

  void searchByName() {
    // Handle the tap action here
    print('search tapped');
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Container(
        padding: EdgeInsets.only(top: 24.0),
        child: Column(
          children: [
            // Pass the onTap callback to the HeaderWidget
            HeaderWidget(onBackTap: handleHeaderTap),
            SizedBox(
              height: 15,
            ),
            SearchBarWidget(searchByName: searchByName),
            SizedBox(height: 15),
            BookMarkCard(),
            SizedBox(height: 10),
            Container(
              width: double.infinity,
              padding: EdgeInsets.all(16.0),
              decoration: BoxDecoration(
                color: Colors.white, // You can change the background color
              ),
              child: Container(
                padding: EdgeInsets.only(left: 10),
                child: Text(
                  "All Movies",
                  style: TextStyle(
                    fontSize: 20.0,
                    fontWeight: FontWeight.bold,
                  ),
                ),
              ),
            ),
            MovieCardWidget(),
          ],
        ),
      ),
    );
  }
}
