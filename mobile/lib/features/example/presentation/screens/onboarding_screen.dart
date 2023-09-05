import 'package:flutter/material.dart';
import 'package:http/http.dart';
import 'package:mobile/core/routes/movie_routes.dart';
import 'package:mobile/features/example/presentation/widgets/customized_button.dart';

class OnboardingScreen extends StatelessWidget {
  const OnboardingScreen({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Stack(
        children: [
          Positioned(
            top: 0,
            bottom: MediaQuery.of(context).size.height * 0.2,
            right: 0,
            left: 0,
            child: const Image(
              image: AssetImage('assets/images/article.jpg'),
              fit: BoxFit.cover,
            ),
          ),
          Positioned(
            top: MediaQuery.of(context).size.height * 0.6,
            bottom: 0,
            right: 0,
            left: 0,
            child: Container(
              padding: EdgeInsets.all(20),
              decoration: const BoxDecoration(
                color: Colors.white,
                borderRadius: BorderRadius.only(
                  topRight: Radius.circular(50),
                  topLeft: Radius.circular(50),
                ),
              ),
              child: const SingleChildScrollView(
                child: Column(
                  children: [
                    Text(
                      'Streaming movie and Tv. Watch instantly',
                      textAlign: TextAlign.center,
                      style: TextStyle(
                        fontSize: 30,
                        fontWeight: FontWeight.bold,
                        color: Colors.black,
                      ),
                    ),
                    SizedBox(
                      height: 20,
                    ),
                    Text(
                      'Enjoy all your favorite movies and TV shows on your streaming devices',
                      textAlign: TextAlign.center,
                      style: TextStyle(
                        fontSize: 15,
                        fontWeight: FontWeight.w600,
                        color: Colors.black,
                      ),
                    ),
                  ],
                ),
              ),
            ),
          ),
          Positioned(
            left: 100,
            bottom: 0,
            child: CustomizedButton(
              label: 'Get Started',
              onpressed: () =>
              Navigator.pushNamed(context, MovieAppRoutes.HOME),
            ),
          ),
        ],
      ),
    );
  }
}
