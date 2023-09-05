import 'package:flutter/material.dart';
import 'package:mobile/features/home/presentation/pages/home.dart';

class OnboardingPage extends StatelessWidget {
  const OnboardingPage({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        body: Container(
      height: double.infinity,
      child: Container(
        child: Container(
          child: Stack(
            alignment: Alignment.bottomCenter,
            children: [
              Container(
                height: double.infinity,
                child: Image.network(
                  "https://cdn.wallpapersafari.com/80/79/O0iPsN.jpg",
                  fit: BoxFit.cover,
                  width: double.infinity,
                  // height: 200,
                ),
              ),
              Container(
                // margin: EdgeInsets.only(top: 180),
                height: 300,
                // width: 100,
                decoration: const BoxDecoration(
                    color: Color.fromARGB(250, 255, 255, 255),
                    borderRadius: BorderRadius.only(
                      topLeft: Radius.circular(40),
                      topRight: Radius.circular(40),
                    )),
                child: Container(
                  width: double.infinity,
                  padding: const EdgeInsets.only(top: 25),
                  child: Column(
                    mainAxisAlignment: MainAxisAlignment.spaceAround,
                    children: [
                      Container(
                        width: 230,
                        child: const Text(
                          "Streaming movie and TV. Watch instantly.",
                          textAlign: TextAlign.center,
                          style: TextStyle(
                              fontSize: 26, fontWeight: FontWeight.bold),
                        ),
                      ),
                      // SizedBox(height: 20),
                      Container(
                        padding: const EdgeInsets.symmetric(horizontal: 30),
                        child: const Text(
                          "Enjoy your favorite films and TV shows on your streaming devices.",
                          style: TextStyle(
                            fontSize: 18,
                          ),
                        ),
                      ),
                      // SizedBox(height: 60),

                      Container(
                        height: 60,
                        width: double.infinity,
                        margin: const EdgeInsets.symmetric(horizontal: 40),
                        child: ElevatedButton(
                            onPressed: () {
                              Navigator.push(
                                  context,
                                  MaterialPageRoute(
                                      builder: (context) => HomePage()));
                            },
                            child: Text(
                              "Get Started",
                              style: TextStyle(fontSize: 22),
                            )),
                      )
                      // SizedBox(height: 20),
                    ],
                  ),
                ),
              ),
            ],
          ),
        ),
      ),
    ));
  }
}
