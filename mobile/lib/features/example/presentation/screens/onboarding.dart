import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart'; // Import Flutter BLoC package.
import '../bloc/onboarding_state.dart';
import '../widgets/onboardingPage.dart';


class Onboarding extends StatefulWidget {
  const Onboarding({super.key});

  @override
  _OnboardingState createState() => _OnboardingState();
}

class _OnboardingState extends State<Onboarding> {
  final PageController _pageController = PageController();
  double _currentPage = 0.0;

  @override
  void initState() {
    super.initState();
    _pageController.addListener(() {
      setState(() {
        _currentPage = _pageController.page!;
      });
    });
  }

  @override
  void dispose() {
    _pageController.dispose();
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: BlocBuilder<OnboardingBloc, OnboardingState>(
        builder: (context, state) {
          if (state is OnboardingDataLoaded) {
            // Display the swipable movie pages when data is loaded.
            return Column(
              children: [
                Expanded(
                  flex: 3,
                  child: PageView(
                    controller: _pageController,
                    children: [
                      OnboardingPage(image: 'image/tom.jpg'),
                      OnboardingPage(image: 'image/avatar.jpg'),
                      OnboardingPage(image: 'image/avatar.jpg'),
                    ],
                  ),
                ),
                Expanded(
                  flex: 2,
                  child: Column(
                    mainAxisAlignment: MainAxisAlignment.center,
                    children: [
                      const Text(
                        'Stream and Watch Movies Online',
                        style: TextStyle(
                          fontSize: 24,
                          fontWeight: FontWeight.bold,
                        ),
                      ),
                      SizedBox(height: 20),
                      ElevatedButton(
                        onPressed: () {
                          Navigator.pushReplacementNamed(context, '/home');
                        },
                        style: ElevatedButton.styleFrom(
                          backgroundColor: Colors.blue,
                        ),
                        child: const Text(
                          'Get Started',
                          style: TextStyle(
                            color: Colors.white,
                          ),
                        ),
                      ),
                    ],
                  ),
                ),
              ],
            );
          } else if (state is OnboardingLoading) {
            // Display a loading indicator while data is being fetched.
            return const Center(child: CircularProgressIndicator());
          } else if (state is OnboardingError) {
            // Handle the error state.
            return Center(
              child: Text('Error: ${state.errorMessage}'),
            );
          } else {
            // Display the initial state.
            return const Center(child: CircularProgressIndicator());
          }
        },
      ),
      floatingActionButtonLocation: FloatingActionButtonLocation.centerDocked,
      floatingActionButton: FloatingActionButton.extended(
        onPressed: () {
          BlocProvider.of<OnboardingBloc>(context).add(OnboardingLoadData());
        },
        backgroundColor: Colors.blue,
        label: const Text(
          'Get Started',
          style: TextStyle(
            color: Colors.white,
          ),
        ),
      ),
    );
  }
}
