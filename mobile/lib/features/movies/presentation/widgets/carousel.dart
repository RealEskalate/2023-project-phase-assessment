import 'package:flutter/material.dart';
import 'package:flutter_carousel_widget/flutter_carousel_widget.dart';

class CustomCarousel extends StatelessWidget {
  const CustomCarousel({super.key});

  @override
  Widget build(BuildContext context) {
    double height = MediaQuery.of(context).size.height;
    double width = MediaQuery.of(context).size.width;
    return ExpandableCarousel(
      options: CarouselOptions(
        viewportFraction: 1.0,
        height: height * 0.6,
        showIndicator: true,
        autoPlay: false,
        slideIndicator: const CircularSlideIndicator(
            indicatorBackgroundColor: Colors.grey,
            currentIndicatorColor: Colors.blue,
            padding: EdgeInsets.symmetric(vertical: 50)),
      ),
      items: [
        "https://media-cache.cinematerial.com/p/500x/nvzxjkhg/spider-man-across-the-spider-verse-movie-poster.jpg?v=1682534125",
        "https://media-cache.cinematerial.com/p/500x/ksyj0r7v/spider-man-across-the-spider-verse-movie-poster.jpg?v=1684438447",
        "https://media-cache.cinematerial.com/p/500x/catlpguq/spider-man-across-the-spider-verse-movie-poster.jpg?v=1686328650"
        "https://upload.wikimedia.org/wikipedia/en/8/8a/The_Avengers_%282012_film%29_poster.jpg",
      ].map((i) {
        return Builder(
          builder: (BuildContext context) {
            return Expanded(
              child: Container(
                height: height * 0.6,
                width: width,
                decoration: BoxDecoration(
                    color: Colors.red,
                    image: DecorationImage(
                      image: NetworkImage(i),
                      fit: BoxFit.cover,
                    ),
                    borderRadius: BorderRadius.circular(0)),
              ),
            );
          },
        );
      }).toList(),
    );
  }
}
