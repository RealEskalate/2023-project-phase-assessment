import 'package:flutter/material.dart';

import '../widgets/movie_poster.dart';
import '../widgets/onboarding_detail.dart';

class Onboarding extends StatelessWidget {
  const Onboarding({Key? key});

  @override
  Widget build(BuildContext context) {
    return Container(
      color: Colors.white,
      child: Column(
        children: [
          MoviePosterSlider(),
          OnboardingDetail()
        ],
      ),
    );
  }
}

class MoviePosterSlider extends StatefulWidget {
  @override
  _MoviePosterSliderState createState() => _MoviePosterSliderState();
}

class _MoviePosterSliderState extends State<MoviePosterSlider> {
  final List<String> movieImages = [
    "https://fastly.picsum.photos/id/1/200/300.jpg?hmac=jH5bDkLr6Tgy3oAg5khKCHeunZMHq0ehBZr6vGifPLY", // Replace with your movie poster images
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
    return Container(
      height: 400, // Adjust the height as needed
      child: Stack(
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
