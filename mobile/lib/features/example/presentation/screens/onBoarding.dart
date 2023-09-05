import 'package:flutter/material.dart';

class OnBoarding extends StatefulWidget {
  const OnBoarding({super.key});

  @override
  State<OnBoarding> createState() => _OnBoardingState();
}

class _OnBoardingState extends State<OnBoarding> {
  late PageController _pageController;
  int _pageIndex = 0;
  @override
  void initState() {
    _pageController = PageController(initialPage: 0);
    super.initState();
  }

  @override
  void dispose() {
    _pageController.dispose();
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Column(
        children: [
          Expanded(
            child: PageView.builder(
              itemCount: demo_data.length,
              controller: _pageController,
              onPageChanged: (index) {
                setState(() {
                  _pageIndex = index;
                });
              },
              itemBuilder: (context, index) => onboardingContent(
                  image: demo_data[index].image, pageIndex: index),
            ),
          ),
          onBoardingNavigation(
              pageIndex: _pageIndex, pageController: _pageController),
        ],
      ),
    );
  }
}

class onBoardingNavigation extends StatelessWidget {
  const onBoardingNavigation({
    super.key,
    required int pageIndex,
    required PageController pageController,
  })  : _pageIndex = pageIndex,
        _pageController = pageController;

  final int _pageIndex;
  final PageController _pageController;

  @override
  Widget build(BuildContext context) {
    return _pageIndex == demo_data.length - 1
        ? Container(
            padding: const EdgeInsets.only(bottom: 10),
            color: Colors.white,
            width: MediaQuery.of(context).size.width,
            child: Container(
              padding: const EdgeInsets.only(left: 50, right: 50),
              height: 60,
              width: 150,
              child: ElevatedButton(
                onPressed: () {
                  Navigator.pushReplacementNamed(context, '/Home');
                },
                style: ElevatedButton.styleFrom(
                    shape: RoundedRectangleBorder(
                        borderRadius: BorderRadius.circular(10)),
                    backgroundColor: const Color(0xFF376AED)),
                child: const Text(
                  'Get Started',
                  style: TextStyle(color: Colors.white),
                ),
              ),
            ),
          )
        : Container(
            padding: const EdgeInsets.only(bottom: 10),
            color: Colors.white,
            child: Row(
              children: [
                const SizedBox(
                  width: 50,
                ),
                const Spacer(),
                SizedBox(
                  height: 60,
                  width: 88,
                  child: ElevatedButton(
                    onPressed: () {
                      _pageController.nextPage(
                          duration: const Duration(milliseconds: 1000),
                          curve: Curves.ease);
                    },
                    style: ElevatedButton.styleFrom(
                        shape: RoundedRectangleBorder(
                            borderRadius: BorderRadius.circular(10)),
                        backgroundColor: const Color(0xFF376AED)),
                    child: const Icon(
                      Icons.arrow_forward,
                      color: Colors.white,
                    ),
                  ),
                ),
                const SizedBox(
                  width: 50,
                ),
              ],
            ),
          );
  }
}

class DotIndicator extends StatelessWidget {
  const DotIndicator({
    super.key,
    this.isActive = false,
  });

  final bool isActive;

  @override
  Widget build(BuildContext context) {
    return AnimatedContainer(
      duration: const Duration(milliseconds: 300),
      height: 8,
      width: isActive ? 18 : 12,
      decoration: BoxDecoration(
          color: isActive ? const Color(0xFF376AED) : Colors.grey,
          borderRadius: const BorderRadius.all(Radius.circular(12))),
    );
  }
}

class Onboard {
  late final String image;

  Onboard({required this.image});
}

final List<Onboard> demo_data = [
  Onboard(image: 'assets/images/onboarding.jpg'),
  Onboard(image: 'assets/images/onboarding.jpg'),
  Onboard(image: 'assets/images/onboarding.jpg'),
  Onboard(image: 'assets/images/onboarding.jpg'),
  Onboard(image: 'assets/images/onboarding.jpg'),
];

class onboardingContent extends StatelessWidget {
  const onboardingContent(
      {super.key, required this.image, required this.pageIndex});

  final String image;
  final int pageIndex;

  @override
  Widget build(BuildContext context) {
    return Stack(
      children: [
        Container(
          width: MediaQuery.of(context).size.width,
          child: Image.asset(image),
        ),
        Positioned(
          top: 520,
          left: 165, // Set the left position as needed
          child: Row(
            children: List.generate(
              demo_data.length,
              (index) => Padding(
                padding: const EdgeInsets.only(right: 8),
                child: DotIndicator(
                  isActive: index == pageIndex,
                ),
              ),
            ),
          ),
        ),
        Positioned(
          top: 550,
          child: Container(
            // alignment: Alignment(0, 0),
            width: MediaQuery.of(context).size.width,
            height: 230,
            decoration: const BoxDecoration(
              color: Colors.white,
              borderRadius: BorderRadius.only(
                topLeft: Radius.circular(20),
                topRight: Radius.circular(20),
              ),
            ),
            child: const Column(children: [
              SizedBox(height: 10),
              Text(
                'Streaming Movie \n'
                '  and TV. Watch\n'
                '        instantly',
                style: TextStyle(fontFamily: 'Poppins-SemiBold', fontSize: 26),
              ),
              SizedBox(height: 10),
              Text(
                'Enjoy all for your favorite films and TV\n'
                'shows on your streaming devices',
                style: TextStyle(fontFamily: 'Urbanist-Regular', fontSize: 18),
              ),
            ]),
          ),
        ),
      ],
    );
  }
}
