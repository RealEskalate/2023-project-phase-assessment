import 'package:flutter/material.dart';
import 'package:mobile/core/utils/app_dimension.dart';

class OnBoardingPage extends StatefulWidget {
  const OnBoardingPage({super.key});

  @override
  State<OnBoardingPage> createState() => _OnBoardingPageState();
}

class _OnBoardingPageState extends State<OnBoardingPage> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
        body: SafeArea(
      child: Stack(
        children: [
          Container(
            width: double.infinity,
            height: double.infinity,
            child: Image.asset(
              "assets/images/onboarding.jpg",
              fit: BoxFit.cover,
            ),
          ),
          Container(
            margin: EdgeInsets.only(top: AppDimension.height(450, context)),
            width: double.infinity,
            height: double.infinity,
            decoration: BoxDecoration(
                color: Colors.white,
                borderRadius: BorderRadius.only(
                    topLeft: Radius.circular(AppDimension.height(45, context)),
                    topRight:
                        Radius.circular(AppDimension.height(45, context)))),
          ),
          Container(
            margin: EdgeInsets.only(top: AppDimension.height(480, context)),
            child: Center(
              child: Column(
                children: [
                  Container(
                    height: AppDimension.height(100, context),
                    width: AppDimension.width(200, context),
                    child: Text(
                      "Streaming movie and TV. Watch instantly",
                      textAlign: TextAlign.center,
                      style: TextStyle(
                          fontSize: AppDimension.height(35, context),
                          fontWeight: FontWeight.w600),
                    ),
                  ),
                  Container(
                      margin: EdgeInsets.only(
                          top: AppDimension.height(45, context)),
                      width: AppDimension.width(250, context),
                      child: Text(
                        "Enjoy all your favourite films and TV shows on your streaming devices",
                        textAlign: TextAlign.center,
                        style: TextStyle(
                            fontWeight: FontWeight.w400,
                            fontSize: AppDimension.height(20, context)),
                      )),
                ],
              ),
            ),
          ),
          Center(
            child: Container(
              margin: EdgeInsets.only(top: AppDimension.height(700, context)),
              width: AppDimension.width(200, context), // Set the desired width
              height:
                  AppDimension.height(50, context), // Set the desired height
              child: ElevatedButton(
                onPressed: () {
                  Navigator.pushNamed(context, '/home');
                },
                style: ElevatedButton.styleFrom(
                  primary: Colors.blue, // Background color
                  onPrimary: Colors.white,
                  shape: RoundedRectangleBorder(
                    borderRadius: BorderRadius.circular(AppDimension.height(
                        10, context)), // Remove the border radius
                  ), // Text color
                ),
                child: Text('Get Started'),
              ),
            ),
          )
        ],
      ),
    ));
  }
}
