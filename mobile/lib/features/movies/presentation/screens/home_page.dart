import 'package:flutter/material.dart';
import 'package:mobile/features/movies/presentation/widgets/my_card.dart';

import '../../domain/entities/movie.dart';
import 'movie_detail_page.dart';

class HomeScreen extends StatefulWidget {
  const HomeScreen({super.key});

  @override
  State<HomeScreen> createState() => _HomeScreenState();
}

class _HomeScreenState extends State<HomeScreen> {
  @override
  Widget build(BuildContext context) {
    List<List> data = [
      ["assets/glass onion.jpg", "Action", "4.5", "1 hour"],
      ["assets/shutter island.jpg", "Action", "4.5", "1 hour"]
    ];
    return Scaffold(
      appBar: AppBar(
        iconTheme: const IconThemeData(color: Colors.black),
        title: const Center(
            child: Text(
          "Alem cinema",
          style: TextStyle(
            color: Colors.black,
            fontSize: 25,
          ),
        )),
        backgroundColor: Colors.white,
      ),
      body: Container(
        color: Colors.grey[300],
        width: MediaQuery.of(context).size.width,
        child: Column(
          children: [
            Row(
              children: [
                Padding(
                  padding: const EdgeInsets.only(
                      top: 20.0, left: 16, right: 8, bottom: 20),
                  child: SizedBox(
                    width: 300,
                    child: TextField(
                      decoration: InputDecoration(
                        filled: true,
                        fillColor: Colors.white,
                        hintText: 'Looking for show',
                        border: OutlineInputBorder(
                          borderRadius: BorderRadius.circular(10.0),
                          borderSide: const BorderSide(),
                        ),
                        focusedBorder: OutlineInputBorder(
                          borderRadius: BorderRadius.circular(10.0),
                          borderSide: const BorderSide(color: Colors.blue),
                        ),
                      ),
                    ),
                  ),
                ),
                Padding(
                  padding: const EdgeInsets.only(top: 20, bottom: 20),
                  child: SizedBox(
                      height: 57,
                      width: 60,
                      child: ElevatedButton.icon(
                        onPressed: () {},
                        label: const Text("Search"),
                        icon: const Icon(Icons.search),
                        style: ElevatedButton.styleFrom(
                          shape: RoundedRectangleBorder(
                            borderRadius: BorderRadius.circular(10.0),
                          ),
                        ),
                      )),
                )
              ],
            ),
            Container(
              width: MediaQuery.of(context).size.width,
              height: 50,
              color: Colors.white,
              child: Row(
                children: [
                  const Padding(
                    padding: EdgeInsets.all(14.0),
                    child: Text(
                      "Saved movies",
                      style: TextStyle(
                        fontSize: 20,
                        fontWeight: FontWeight.bold,
                      ),
                    ),
                  ),
                  IconButton(
                      onPressed: () {},
                      icon: const Icon(Icons.save_alt_outlined)),
                ],
              ),
            ),
            const SizedBox(
              height: 20,
            ),
            Padding(
              padding: const EdgeInsets.symmetric(horizontal: 12.0),
              child: SingleChildScrollView(
                scrollDirection: Axis.horizontal,
                child: Row(
                    children: List.generate(data.length,
                        (index) => HomeCard(cardData: data[index]))),
              ),
            ),
            Container(
              width: MediaQuery.of(context).size.width,
              height: 50,
              color: Colors.white,
              child: const Row(
                children: [
                  Padding(
                    padding: EdgeInsets.symmetric(horizontal: 30.0),
                    child: Text(
                      "All Movies",
                      style: TextStyle(
                        fontSize: 25,
                        fontWeight: FontWeight.bold,
                      ),
                    ),
                  ),
                ],
              ),
            ),
            Expanded(
              child: ListView.builder(
                  itemCount: data.length,
                  itemBuilder: (BuildContext context, index) {
                    return CardList(
                        cardData: data[index],
                        onDetail: () => navigateToMovieDetail(data[index]));
                  }),
            ),
          ],
        ),
      ),
    );
  }

  void navigateToMovieDetail(movie) {
    Navigator.push(
        context,
        MaterialPageRoute(
          builder: (context) => MovieDetailScreen(data: movie),
        ));
  }
}
