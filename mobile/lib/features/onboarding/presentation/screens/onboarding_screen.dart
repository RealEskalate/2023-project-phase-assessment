import 'package:flutter/material.dart';

class Onboarding extends StatelessWidget {
  const Onboarding({super.key});

  @override
  Widget build(BuildContext context) {
    return Container(
      child: Row(children: [
        MoviePosterSlider(),
        Container(
          child: Row(
            children: [
              Text(
                "Streaming Movie and TV. Watch Instantly",
                style: TextStyle(
                  fontSize: 24,
                  fontWeight: FontWeight.w400,
                ),
                maxLines: 3,
              ),
              Text(
                "Enjoy all your favourite films and TV shows on your streaming devices",
                style: TextStyle(
                  fontSize: 16,
                  fontWeight: FontWeight.w200,
                ),
                maxLines: 2,
              ),
              ElevatedButton(
                onPressed: () {},
                child: Text(
                  "Get Started",
                  style: TextStyle(
                    color: Colors.white,
                    fontSize: 20,
                    fontWeight: FontWeight.w300,
                  ),
                ),
              ),
            ],
          ),
        )
      ]),
    );
  }
}

class MoviePosterSlider extends StatefulWidget {
  @override
  _MoviePosterSliderState createState() => _MoviePosterSliderState();
}

class _MoviePosterSliderState extends State<MoviePosterSlider> {
  final List<String> movieImages = [
    'assets/movie_poster1.jpg', // Replace with your movie poster images
    'assets/movie_poster2.jpg',
    'assets/movie_poster3.jpg',
  ];

  PageController _pageController = PageController();
  int _currentPage = 0;

  @override
  void initState() {
    super.initState();

    _pageController.addListener(() {
      setState(() {
        _currentPage = _pageController.page!.round();
      });
    });
  }

  @override
  void dispose() {
    _pageController.dispose();
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Stack(
        children: [
          PageView.builder(
            controller: _pageController,
            itemCount: movieImages.length,
            itemBuilder: (context, index) {
              return MoviePoster(movieImage: movieImages[index]);
            },
          ),
          Positioned(
            bottom: 20,
            left: 0,
            right: 0,
            child: Row(
              mainAxisAlignment: MainAxisAlignment.center,
              children: List.generate(
                movieImages.length,
                (index) => buildDot(index),
              ),
            ),
          ),
        ],
      ),
    );
  }

  Widget buildDot(int index) {
    return Container(
      margin: EdgeInsets.symmetric(horizontal: 4),
      width: 8,
      height: 8,
      decoration: BoxDecoration(
        shape: BoxShape.circle,
        color: _currentPage == index ? Colors.white : Colors.grey,
      ),
    );
  }
}

class MoviePoster extends StatelessWidget {
  final String movieImage;

  MoviePoster({required this.movieImage});

  @override
  Widget build(BuildContext context) {
    return Container(
      width: double.infinity,
      height: double.infinity,
      decoration: BoxDecoration(
        image: DecorationImage(
          image: AssetImage(movieImage),
          fit: BoxFit.cover,
        ),
      ),
      child: Column(
        mainAxisAlignment: MainAxisAlignment.center,
        children: [
          Text(
            'TOM HANKS IS A MAN CALLED OTTO',
            style: TextStyle(
              fontSize: 32,
              fontWeight: FontWeight.bold,
              color: Colors.white,
            ),
          ),
          SizedBox(height: 20),
          Text(
            'BASED ON THE INTERNATIONAL BEST SELLER',
            style: TextStyle(
              fontSize: 18,
              color: Colors.white,
            ),
          ),
        ],
      ),
    );
  }
}
