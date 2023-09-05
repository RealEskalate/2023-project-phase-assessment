import 'package:flutter/material.dart';
import 'package:mobile/features/example/presentation/screens/home_page.dart';

class OnboardingPage extends StatelessWidget {
  const OnboardingPage({super.key});

  @override
  Widget build(BuildContext context) {
    return SingleChildScrollView(
      child: Column(
        children: [
          const SizedBox(
            height: 450,
            // child: Placeholder(),
          ),
          Container(
            height: 320,
            width: 420,
            decoration: const BoxDecoration(
                color: Colors.white,
                borderRadius: BorderRadius.only(
                    topLeft: Radius.circular(30),
                    topRight: Radius.circular(30))),
            child: Column(children: [
              const Padding(
                padding: EdgeInsets.fromLTRB(20, 30, 20, 0),
                child: Text(
                  "Streaming movie",
                  style: TextStyle(fontSize: 32, fontWeight: FontWeight.bold),
                ),
              ),
              const Padding(
                padding: EdgeInsets.fromLTRB(20, 0, 20, 10),
                child: Text(
                  "and Tv. Watch",
                  style: TextStyle(fontSize: 32, fontWeight: FontWeight.bold),
                ),
              ),
              const Padding(
                padding: EdgeInsets.fromLTRB(20, 0, 20, 10),
                child: Text(
                  "instantly",
                  style: TextStyle(fontSize: 32, fontWeight: FontWeight.bold),
                ),
              ),
              const Padding(
                padding: EdgeInsets.fromLTRB(20, 0, 20, 0),
                child: Text(
                  "Enjoy all your favorite films and Tv",
                  style: TextStyle(
                    fontSize: 15,
                  ),
                ),
              ),
              const Padding(
                padding: EdgeInsets.fromLTRB(20, 0, 20, 35),
                child: Text(
                  "shows on your streaming devices",
                  style: TextStyle(
                    fontSize: 15,
                  ),
                ),
              ),
              ElevatedButton(
                onPressed: () {
                  Navigator.push(
                    context,
                    MaterialPageRoute(
                      builder: (context) => const HomePage(),
                    ),
                  );
                },
                child: const Text(
                  "Get Started",
                  style: TextStyle(
                    color: Colors.white,
                    fontSize: 20,
                    fontWeight: FontWeight.bold,
                  ),
                ),
                style: ElevatedButton.styleFrom(
                  backgroundColor: Colors.blue,
                  shape: RoundedRectangleBorder(
                    borderRadius: BorderRadius.circular(
                        10), // Adjust the value to control the roundness
                  ),
                  minimumSize: Size(300,
                      50), // Adjust the width and height to make the button larger
                ),
              ),
            ]),
          )
        ],
      ),
    );
  }
}

class OnBoardingFrame extends StatelessWidget {
  const OnBoardingFrame({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Container(
        decoration: BoxDecoration(
          image: DecorationImage(
            image: AssetImage('assets/images/download.jpg'),
            fit: BoxFit.cover, // Optional: Adjust the fit of the image
          ),
        ),
        child: OnboardingPage(),
      ),
    );
  }
}
