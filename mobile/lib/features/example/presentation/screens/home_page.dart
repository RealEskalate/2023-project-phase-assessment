// ignore_for_file: public_member_api_docs, sort_constructors_first
import 'package:flutter/material.dart';

import 'package:mobile/features/example/domain/entities/Movie.dart';
import 'package:mobile/features/example/presentation/screens/details_screen.dart';

class HomePage extends StatefulWidget {
  final List<Movie> moviesData;

  const HomePage({super.key, required this.moviesData});
  @override
  _HomePageState createState() => _HomePageState();
}

class _HomePageState extends State<HomePage> {
  TextEditingController _searchController = TextEditingController();
  List<Movie> filteredMovies = [];
  bool _isSearching = false;

  @override
  void initState() {
    super.initState();
    filteredMovies = widget.moviesData;
  }

  void _searchMovies(String query) {
    print(query);
    setState(() {
      if (query.isEmpty) {
        filteredMovies = widget.moviesData;
      } else {
        filteredMovies = widget.moviesData.where((movie) {
          return movie.title.toLowerCase().contains(query.toLowerCase());
        }).toList();
      }
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        elevation: 0,
        backgroundColor: Colors.white, // Set app bar background to white
        title: Center(
          child: Text(
            'Alem Cinema',
            style: TextStyle(color: Colors.black),
          ),
        ),
        leading: IconButton(
          icon: Icon(Icons.arrow_back),
          color: Colors.black,
          onPressed: () {
            setState(() {
              _isSearching = false; // Exit search mode
              _searchController.clear();
              _searchMovies('');
            });
          },
        ),
      ),
      body: Column(
        children: [
          // Search Field with customization
          Padding(
            padding: const EdgeInsets.all(16.0),
            child: Container(
              decoration: BoxDecoration(
                borderRadius: BorderRadius.circular(8.0),
                color: Colors.white, // Set white background for the container
              ),
              child: Padding(
                padding: const EdgeInsets.symmetric(horizontal: 8.0),
                child: Row(
                  children: [
                    SizedBox(width: 8.0),
                    Expanded(
                      child: TextField(
                        controller: _searchController,
                        decoration: InputDecoration(
                          hintText: 'Looking for shows', // Set search hint
                          border: InputBorder.none, // Remove input field border
                        ),
                        // Implement search functionality here
                      ),
                    ),
                    GestureDetector(
                      onTap: () {
                        setState(() {
                          _isSearching = !_isSearching; // Toggle search mode

                          if (!_isSearching) {
                            // Clear search and show all movies when exiting search mode
                            _searchController.clear();
                            _searchMovies('');
                          } else {
                            // Execute search immediately when entering search mode
                            () => _searchMovies(_searchController.text);
                          }

                          // Add code here to perform any additional refresh actions.
                          // For example, you can reload data from an API or update any other
                          // state variables that need refreshing.
                        });
                      },
                      child: Container(
                        decoration: BoxDecoration(
                          color:
                              Colors.blue, // Set blue background for the icon
                          borderRadius: BorderRadius.circular(5),
                        ),
                        padding: EdgeInsets.all(11),
                        child: Icon(
                          Icons.search,
                          color: Colors.white, // Set blue color for the icon
                        ),
                      ),
                    ),
                  ],
                ),
              ),
            ),
          ),
          if (!_isSearching)
            Container(
                margin: EdgeInsets.all(8),
                alignment: Alignment.bottomLeft,
                child: Row(
                  children: [
                    Text(
                      "Saved Movies",
                      style:
                          TextStyle(fontWeight: FontWeight.bold, fontSize: 20),
                      textAlign: TextAlign.left,
                    ),
                    Icon(
                      Icons.bookmark_border_outlined,
                      color: Colors.blue,
                    )
                  ],
                )),
          // Movie Cards Section
          if (!_isSearching) _buildMovieCards(),
          Container(
            alignment: Alignment.bottomLeft,
            margin: EdgeInsets.all(8),
            child: Text(
              !_isSearching ? "All Movies" : "Search Results",
              style: TextStyle(fontSize: 15, fontWeight: FontWeight.bold),
            ),
          ),
          // List of All Movies in Cinema
          if (!_isSearching || _isSearching) _buildAllMoviesList(),
        ],
      ),
    );
  }

  Widget _buildMovieCards() {
    return Container(
      height: 200,
      child: ListView.builder(
        scrollDirection: Axis.horizontal,
        itemCount: widget.moviesData.length,
        itemBuilder: (context, index) {
          final movie = widget.moviesData[index];
          return GestureDetector(
            onTap: () {
              Navigator.of(context).push(MaterialPageRoute(
                  builder: (context) => Detail(movie: movie)));
            },
            child: Padding(
              padding: const EdgeInsets.all(8.0),
              child: Stack(
                children: [
                  // Movie Image (Behind Card)
                  Positioned(
                    child: Container(
                      width: 180, // Adjust the width as needed
                      height: 200, // Adjust the height as needed
                      decoration: BoxDecoration(
                        borderRadius: BorderRadius.circular(8),
                        image: DecorationImage(
                          image: NetworkImage(movie.image),
                          fit: BoxFit.cover,
                        ),
                      ),
                    ),
                  ),
                  // Card with Movie Name (Overlay)
                  Positioned(
                    bottom: 8,
                    left: 10,
                    child: Align(
                      alignment: Alignment.bottomCenter,
                      child: Container(
                        width: 155, // Adjust the width of the card
                        height: 60, // Adjust the height of the card
                        decoration: BoxDecoration(
                            color: Colors.white,
                            borderRadius: BorderRadius.circular(8)),
                        padding: EdgeInsets.all(8.0),
                        child: Column(
                          crossAxisAlignment: CrossAxisAlignment.start,
                          children: [
                            Text(
                              movie.title,
                              style: TextStyle(fontWeight: FontWeight.bold),
                            ),
                            Row(
                              children: [
                                Row(
                                  children: [
                                    Icon(
                                      Icons.star,
                                      color: Colors.yellow,
                                    ),
                                    Text('${movie.rating}/10'),
                                  ],
                                ),
                                Row(
                                  children: [
                                    Icon(
                                      Icons.access_time,
                                      color: Colors.blue,
                                    ),
                                    Text('${movie.duration}'),
                                  ],
                                ),
                              ],
                            ),
                          ],
                        ),
                      ),
                    ),
                  ),
                ],
              ),
            ),
          );
        },
      ),
    );
  }

  Widget _buildAllMoviesList() {
    return Expanded(
      child: ListView.builder(
        itemCount: filteredMovies.length,
        itemBuilder: (context, index) {
          final movie = filteredMovies[index];
          return Padding(
            padding: const EdgeInsets.all(8.0),
            child: Container(
              margin: EdgeInsets.all(4),
              child: ListTile(
                leading: Image.network(movie.image, width: 100, height: 100),
                title: Text(movie.title),
                subtitle: Column(
                  crossAxisAlignment: CrossAxisAlignment.start,
                  children: [
                    Row(
                      children: [
                        Icon(
                          Icons.star,
                          color: Colors.yellow,
                        ),
                        Text('${movie.rating}/10'),
                      ],
                    ),
                    Row(
                      children: [
                        Icon(
                          Icons.access_time,
                          color: Colors.blue,
                        ),
                        Text('${movie.duration}'),
                      ],
                    ),
                  ],
                ),
              ),
            ),
          );
        },
      ),
    );
  }
}
