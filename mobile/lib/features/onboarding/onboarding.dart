import 'package:flutter/material.dart';

class OnboardingPage extends StatefulWidget {
  @override
  _OnboardingPageState createState() => _OnboardingPageState();
}

class _OnboardingPageState extends State<OnboardingPage> {
  final PageController _pageController = PageController(initialPage: 0);
  int _currentPage = 0;
  final int _totalPages = 5;

  List<String> pageImages = [
    'assets/images/onboarding.png',
    'assets/images/onboarding.png',
    'assets/images/onboarding.png',
    'assets/images/onboarding.png',
    'assets/images/onboarding.png',
  ];

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Stack(
        children: [
          PageView.builder(
            controller: _pageController,
            onPageChanged: (int page) {
              setState(() {
                _currentPage = page;
              });
            },
            itemCount: _totalPages,
            itemBuilder: (BuildContext context, int index) {
              return Container(
                width: double.infinity,
                height: double.infinity,
                color:
                    Colors.blue, // Replace with your desired background color
                child: Image.asset(
                  pageImages[index],
                  width: double.infinity,
                  height: double.infinity,
                  fit: BoxFit.cover,
                ),
              );
            },
          ),
          Positioned(
            top: 430,
            left: 0,
            right: 0,
            child: Column(
              crossAxisAlignment: CrossAxisAlignment.center,
              children: [
                // Text(
                //   'Page ${_currentPage + 1} of $_totalPages',
                //   style: TextStyle(fontSize: 18, color: Colors.white),
                // ),
                SizedBox(height: 20),
                Row(
                  mainAxisAlignment: MainAxisAlignment.center,
                  children: [
                    for (int i = 0; i < _totalPages; i++)
                      Padding(
                        padding: const EdgeInsets.symmetric(horizontal: 4.0),
                        child: Container(
                          width: 10,
                          height: 10,
                          decoration: BoxDecoration(
                            shape: BoxShape.circle,
                            color:
                                i == _currentPage ? Colors.blue : Colors.grey,
                          ),
                        ),
                      ),
                  ],
                ),
              ],
            ),
          ),
          Positioned(
            bottom: 0,
            left: 0,
            right: 0,
            child: Container(
              height: MediaQuery.of(context).size.height * 0.4,
              color: Colors.white, // Replace with your desired container color
              child: Column(
                mainAxisAlignment: MainAxisAlignment.center,
                children: [
                  Text(
                    'Streaming movie and TV. watch instantly',
                    style: TextStyle(fontSize: 40, fontWeight: FontWeight.bold),
                  ),
                  SizedBox(height: 10),
                  Text(
                    'enjoy all your favourite films and TV shows on your streaming devices',
                    style: TextStyle(fontSize: 20),
                  ),
                  SizedBox(height: 20),
                  ElevatedButton(
                    onPressed: () {
                      // Handle "Get Started" button press
                    },
                    style: ElevatedButton.styleFrom(
                      primary:
                          Colors.blue, // Change the button's background color
                      onPrimary: Colors.white, // Change the button's text color
                      padding: EdgeInsets.symmetric(
                          horizontal: 40,
                          vertical: 16), // Adjust the button's padding
                      shape: RoundedRectangleBorder(
                        borderRadius: BorderRadius.circular(
                            15), // Adjust the button's border radius
                      ),
                    ),
                    child: Text(
                      'Get Started',
                      style: TextStyle(
                        fontSize: 20,
                        fontWeight: FontWeight
                            .bold, // Add or adjust the button's text style
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
