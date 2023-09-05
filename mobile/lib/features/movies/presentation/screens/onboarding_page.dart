import 'package:dartz/dartz.dart';
import 'package:flutter/material.dart';

import 'home_page.dart';

class OnboardingPage extends StatelessWidget {
  const OnboardingPage({super.key});

  @override
  Widget build(BuildContext context) {
    List<String> onboardingText = [
      "Streaming movie",
      "and TV. Watch",
      "instantly"
    ];
    double deviceWidth = MediaQuery.of(context).size.width;
    double deviceHeight = MediaQuery.of(context).size.height;

    return Scaffold(
      body: Container(
        color: Colors.white,
        child: Stack(children: [
          Positioned.fill(
            child: Image.asset(
              "assets/tom hanks.jpg",
              fit: BoxFit.cover,
            ),
          ),
          Positioned(
            top: deviceHeight / 1.70,
            child: Container(
              width: deviceWidth,
              height: deviceHeight,
              decoration: const BoxDecoration(
                  color: Color.fromARGB(255, 255, 255, 255),
                  borderRadius: BorderRadius.only(
                      topLeft: Radius.circular(50),
                      topRight: Radius.circular(50))),
              child: const Padding(
                padding: EdgeInsets.only(top: 30, bottom: 20),
                child: Column(
                  children: [
                    Text(
                      "Streaming movie",
                      style: TextStyle(
                          color: Colors.black,
                          fontSize: 37,
                          fontWeight: FontWeight.bold),
                    ),
                    SizedBox(
                      height: 7,
                    ),
                    Text(
                      "and TV. Watch",
                      style: TextStyle(
                          color: Colors.black,
                          fontSize: 35,
                          fontWeight: FontWeight.bold),
                    ),
                    SizedBox(
                      height: 7,
                    ),
                    Text(
                      "instantly",
                      style: TextStyle(
                          color: Colors.black,
                          fontSize: 35,
                          fontWeight: FontWeight.bold),
                    ),
                    SizedBox(
                      height: 14,
                    ),
                    Text(
                      "enjoy all your favorite films and TV",
                      style: TextStyle(color: Colors.black, fontSize: 16),
                    ),
                    Text(
                      "shows on your streaming device",
                      style: TextStyle(color: Colors.black, fontSize: 16),
                    ),
                  ],
                ),
              ),
            ),
          ),
          Positioned(
              left: 30,
              top: deviceHeight / 1.14,
              child: SizedBox(
                width: 350,
                height: 60,
                child: ElevatedButton(
                  onPressed: () {
                    Navigator.push(
                        context,
                        MaterialPageRoute(
                          builder: (context) => const HomeScreen(),
                        ));
                  },
                  style: ElevatedButton.styleFrom(
                      backgroundColor: const Color(0xFF3FAEE5),
                      foregroundColor: Colors.white,
                      shape: RoundedRectangleBorder(
                        borderRadius: BorderRadius.circular(15),
                      )),
                  child: const Text(
                    "GET STARTED",
                    style: TextStyle(fontSize: 20, fontWeight: FontWeight.bold),
                  ),
                ),
              ))
        ]),
      ),
    );
  }
}
