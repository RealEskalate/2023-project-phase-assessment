import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:mobile/features/HomePage/presentation/bloc/homepage_bloc.dart';
import 'package:mobile/features/HomePage/presentation/pages/home_page.dart';
import 'package:smooth_page_indicator/smooth_page_indicator.dart';

class OnBoardingScreen extends StatelessWidget {
  OnBoardingScreen({super.key});
  PageController _controller = PageController();
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Stack(
        children: [
          Container(
            height: MediaQuery.sizeOf(context).height * 0.7,
            color: Colors.grey,
            child: Stack(
              children: [
                PageView(
                  controller: _controller,
                  children: [
                    Container(
                      color: Colors.blue,
                      width: double.infinity,
                      height: MediaQuery.sizeOf(context).height * 70,
                    ),
                    Container(
                      color: Colors.green,
                      width: double.infinity,
                      height: MediaQuery.sizeOf(context).height * 70,
                    ),
                    Container(
                      color: Colors.yellow,
                      width: double.infinity,
                      height: MediaQuery.sizeOf(context).height * 70,
                    ),
                  ],
                ),
                Align(
                  alignment: const Alignment(0, 0.4),
                  child: SmoothPageIndicator(
                    controller: _controller,
                    count: 3,
                    effect: const WormEffect(
                      dotWidth: 12,
                      dotHeight: 12,
                    ),
                  ),
                ),
              ],
            ),
          ),
          Align(
            alignment: Alignment.bottomCenter,
            child: Container(
              decoration: const BoxDecoration(
                color: Colors.white,
                borderRadius: BorderRadius.only(
                  topLeft: Radius.circular(50),
                  topRight: Radius.circular(50),
                ),
              ),
              height: MediaQuery.sizeOf(context).height * 0.45,
              width: MediaQuery.sizeOf(context).width,
              child: Column(
                crossAxisAlignment: CrossAxisAlignment.center,
                children: [
                  const SizedBox(height: 20),
                  SizedBox(
                    width: MediaQuery.sizeOf(context).width * 0.8,
                    child: const Text(
                      "Streaming Movie and TV. Watch instantly",
                      textAlign: TextAlign.center,
                      style: TextStyle(
                        fontSize: 40,
                        fontWeight: FontWeight.w600,
                      ),
                    ),
                  ),
                  const SizedBox(height: 20),
                  SizedBox(
                    width: MediaQuery.sizeOf(context).width * 0.8,
                    child: const Text(
                      "Enjoy all your favorite films and TV shows on your streaming devices",
                      textAlign: TextAlign.center,
                      style: TextStyle(
                        fontSize: 20,
                        color: Colors.black54,
                      ),
                    ),
                  ),
                  const SizedBox(height: 15),
                  GestureDetector(
                    onTap: () {
                       context.read<HomepageBloc>().add(GetDataEvent());
                      Navigator.push(
                        context,
                        MaterialPageRoute(
                          builder: (context) {
                            return MyHomePage();
                          },
                        ),
                      );
                    },
                    child: Container(
                      decoration: BoxDecoration(
                        color: Colors.blue,
                        borderRadius: BorderRadius.circular(10),
                      ),
                      width: MediaQuery.sizeOf(context).width * 0.7,
                      height: 60,
                      child: const Center(
                        child: Text(
                          "Get Started",
                          style: TextStyle(
                            color: Colors.white,
                            fontWeight: FontWeight.w600,
                          ),
                        ),
                      ),
                    ),
                  )
                ],
              ),
            ),
          ),
        ],
      ),
    );
  }
}
