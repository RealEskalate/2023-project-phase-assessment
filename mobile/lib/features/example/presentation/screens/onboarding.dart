import 'package:flutter/material.dart';
import 'package:mobile/features/example/presentation/widgets/image_slider.dart';

class Onboarding extends StatelessWidget {
  const Onboarding({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Column(
        children: [
          Expanded(
            flex: 6,
            child: ImageSlider(
              imageUrls: [
                'https://c8.alamy.com/comp/EJWP0H/titanic-movie-poster-1997-EJWP0H.jpg',
                'https://marketplace.canva.com/EAFVCFkAg3w/1/0/1131w/canva-red-and-black-horror-movie-poster-AOBSIAmLWOs.jpg',
                'https://parade.com/.image/t_share/MTkwNTgxMjk2NzkzNTkyOTU3/the-exorcist.jpg',
                // Add your image asset paths here
              ],
            ),
          ),
          Expanded(
            flex: 4,
            child: Container(
              decoration: BoxDecoration(
                color: Colors.white, // Background color
                borderRadius: BorderRadius.only(
                  topLeft: Radius.circular(
                      20.0), // Circular border on top-left corner
                  topRight: Radius.circular(
                      20.0), // Circular border on top-right corner
                ),
              ),
              child: Column(
                children: [
                  Padding(
                    padding: const EdgeInsets.only(
                        left: 40.0, right: 40, top: 20, bottom: 8),
                    child: Center(
                      child: Text(
                        "Streaming Movies and series. Watch instantly",
                        style: TextStyle(
                          color: Colors.black,
                          fontSize: 24,
                          fontWeight: FontWeight.w700,
                        ),
                      ),
                    ),
                  ),
                  Padding(
                    padding: const EdgeInsets.only(
                        left: 40.0, right: 40, top: 20, bottom: 8),
                    child: Text(
                      "enjoy all your favoirite movies and series on the go movies and series on the go",
                      style: TextStyle(
                        color: Colors.black,
                        fontSize: 16,
                        fontWeight: FontWeight.w400,
                      ),
                    ),
                  ),
                  Padding(
                    padding: const EdgeInsets.all(8.0),
                    child: ElevatedButton(
                      onPressed: () {
                        Navigator.pushReplacementNamed(context, '/home');
                      },
                      style: ElevatedButton.styleFrom(
                          minimumSize: const Size(250, 70),
                          shape: RoundedRectangleBorder(
                              borderRadius: BorderRadius.circular(10)),
                          backgroundColor: const Color(0xFF376AED)),
                      child: const Text(
                        'Get Started',
                        style: TextStyle(color: Colors.white),
                      ),
                    ),
                  ),
                ],
              ),
            ),
          ),
        ],
      ),
    );
  }
}
