import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:get/get.dart';
import 'package:mobile/features/example/presentation/bloc/get_movies_bloc.dart';

class OnboardingPage  extends StatefulWidget {
  const OnboardingPage ({super.key});

  @override
  State<OnboardingPage > createState() => _OnboardingPageState();
}

class _OnboardingPageState extends State<OnboardingPage > {
  late PageController _pageController;
  int currentIndex = 0;

  var duration = const Duration(milliseconds: 250);
  var curveEase = Curves.ease;

  neaxtPage() {
    _pageController.nextPage(duration: duration, curve: curveEase);
  }

  previousPage() {
    _pageController.previousPage(duration: duration, curve: curveEase);
  }

  onChangedPage(int index) {
    setState(() {
      currentIndex = index;
    });
  }

  @override
  void initState() {
    _pageController = PageController();
    super.initState();
  }

  Widget buildOnboardingBody() {
    return Container(
      // color: Colors.yellow.withOpacity(0.1),
      width: Get.width,
      height: Get.height / 2.8,
      child: Stack(children: [
        Container(
          width: double.infinity,
          decoration: BoxDecoration(
            image: DecorationImage(
              //  image: AssetImage("assets/images/sunset.png"),

              image: NetworkImage(
                  "https://stat.ameba.jp/user_images/20230205/08/rekifunesalmon/50/57/j/o0600090015238965956.jpg"),
              fit: BoxFit.cover,
            ),
          ),
        ),
        //
        Positioned(
          bottom: 20,
          left: 0,
          right: 0,
          child: Row(
              mainAxisAlignment: MainAxisAlignment.center,
              crossAxisAlignment: CrossAxisAlignment.end,
              children: [
                DotIndicator(
                  positionIndex: 0,
                  currentIndex: currentIndex,
                ),
                SizedBox(
                  width: 8,
                ),
                DotIndicator(
                  positionIndex: 1,
                  currentIndex: currentIndex,
                ),
                SizedBox(
                  width: 8,
                ),
                DotIndicator(
                  positionIndex: 2,
                  currentIndex: currentIndex,
                ),
                SizedBox(
                  width: 8,
                ),
                DotIndicator(
                  positionIndex: 3,
                  currentIndex: currentIndex,
                ),
                SizedBox(
                  width: 8,
                ),
                DotIndicator(
                  positionIndex: 4,
                  currentIndex: currentIndex,
                ),
              ]),
        ),
      ]),
    );
  }

  

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: Color.fromARGB(255, 236, 236, 236),
      body: Column(
        mainAxisAlignment: MainAxisAlignment.spaceBetween,
        mainAxisSize: MainAxisSize.max,
        children: [
          Container(
            width: double.infinity,
            height: Get.height / 1.7,
            child: PageView(
              controller: _pageController,
              onPageChanged: onChangedPage,
              children: [
                buildOnboardingBody(),
                buildOnboardingBody(),
                buildOnboardingBody(),
                buildOnboardingBody(),
                buildOnboardingBody(),
              ],
            ),
          ),
          Expanded(
            child: Container(
              width: Get.width,
              decoration: BoxDecoration(
                color: const Color.fromARGB(255, 255, 255, 255),
                borderRadius: BorderRadius.only(
                  topLeft: Radius.circular(48),
                  topRight: Radius.circular(48),
                ),
              ),
              child: Column(
                children: [
                  Container(
                    margin: EdgeInsets.only(top: 40),
                    width: 275,
                    child: Text(
                      'Streaming a moive and Tv.Watch instanlty',
                      style: TextStyle(
                        color: Color(0xFF0D253C),
                        fontSize: 24,
                        // fontStyle: FontStyle.italic,
                        // fontFamily: 'Poppins',
                        fontWeight: FontWeight.bold,
                      ),
                    ),
                  ),
                  SizedBox(
                    height: 20,
                  ),
                  Container(
                    // margin: EdgeInsets.only(),
                    width: 275,
                    child: Text(
                      'Enjoy all your favourite films and Tv shows on your streaming device',
                      style: TextStyle(
                        color: Color(0xFF0D253C),
                        fontSize: 24,
                        // fontStyle: FontStyle.italic,
                        // fontFamily: 'Poppins',
                        fontWeight: FontWeight.normal,
                      ),
                    ),
                  ),
                  SizedBox(
                    height: 80,
                  ),
                  SizedBox(
                    height: 55,
                    width: 280,
                    child: ElevatedButton(
                        onPressed: () {
                // Navigate to the details page when the button is pressed
               BlocProvider.of<GetMoviesBloc>(context).add(GetStarted());
               BlocProvider.of<GetMoviesBloc>(context).add(GetAllMovie());
              },
                        child: Text(
                          "Get Started",
                          style: TextStyle(
                            fontSize: 20,
                          ),
                        )),
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

class DotIndicator extends StatelessWidget {
  final int positionIndex;
  final int currentIndex;

  const DotIndicator(
      {super.key, required this.positionIndex, required this.currentIndex});

  @override
  Widget build(BuildContext context) {
    return AnimatedContainer(
      margin: EdgeInsets.only(left: 5, top: 20),
      height: 10,
      width: positionIndex == currentIndex ? 20 : 10,
      decoration: BoxDecoration(
          color:
              positionIndex == currentIndex ? Colors.blue : Color(0xFFF4F7FF),
          borderRadius: BorderRadius.circular(32)),
      duration: Duration(milliseconds: 250),
    );
  }
}
