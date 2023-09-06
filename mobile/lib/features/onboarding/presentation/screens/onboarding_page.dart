import 'package:flutter/material.dart';
import 'package:go_router/go_router.dart';

class OnboardingScreen extends StatelessWidget {
  const OnboardingScreen({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: Colors.white,
      body: Stack(children: [
        ClipRRect(
          child: Image.asset('assets/images/tom_hanks.jpg',
              width: double.infinity, fit: BoxFit.cover),
        ),
        Column(
          children: [
            const Spacer(),
            Positioned(
              bottom: 0,
              left: 0,
              right: 0,
              height: 300,
              child: Container(
                padding: const EdgeInsets.only(top: 20, left: 40, right: 40),
                decoration: const BoxDecoration(
                    color: Colors.white,
                    borderRadius: BorderRadius.only(
                      topLeft: Radius.circular(60),
                      topRight: Radius.circular(60),
                    )),
                child: Column(
                  children: [
                    const SizedBox(height: 20),
                    const Text(
                      "Streaming movie and Tv. Watch instantly",
                      style:
                          TextStyle(fontWeight: FontWeight.bold, fontSize: 40),
                      textAlign: TextAlign.center,
                    ),
                    const SizedBox(height: 20),
                    const Text(
                      "Enjoy all your favourite films and TV shows on your streaming devices",
                      style: TextStyle(fontSize: 18),
                      textAlign: TextAlign.center,
                    ),
                    const SizedBox(height: 40),
                    GetStartedButton(),
                    const SizedBox(height: 20),
                  ],
                ),
              ),
            ),
          ],
        )
      ]),
    );
  }
}

class GetStartedButton extends StatelessWidget {
  const GetStartedButton({
    super.key,
  });

  @override
  Widget build(BuildContext context) {
    return ElevatedButton(
      onPressed: () {context.go('/home');},
      style: ElevatedButton.styleFrom(
        backgroundColor:
            const Color.fromARGB(255, 27, 149, 249),
        minimumSize: const Size(300, 50),
        shape: RoundedRectangleBorder(
            borderRadius: BorderRadius.circular(10)),
      ),
      child: const Text(
        "Get Started",
        style: TextStyle(
            fontSize: 19,
            fontWeight: FontWeight.bold,
            color: Colors.white),
      ),
    );
  }
}
