import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:mobile/features/example/presentation/bloc/get_movies/get_movies_bloc.dart';

class OnboardingPage extends StatefulWidget {
  @override
  _OnboardingPageState createState() => _OnboardingPageState();
}

class _OnboardingPageState extends State<OnboardingPage> {
  final PageController _controller = PageController();
  final int _numPages = 3; // Number of onboarding pages (adjust as needed).
  int _currentPage = 0;

  @override
  void dispose() {
    _controller.dispose();
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    return BlocConsumer<GetMoviesBloc, GetMoviesState>(
      listener: (context, state) {
        if(state is GetMovies){
          BlocProvider.of<GetMoviesBloc>(context).add(GetAllMovie());
        }
      },
      builder: (context, state) {
        return Scaffold(
          body: Column(
            children: [
              Flexible(
                flex: 2, // Adjust the flex value to control image height
                child: Stack(
                  alignment: Alignment.bottomCenter,
                  children: [
                    PageView.builder(
                      controller: _controller,
                      onPageChanged: (int page) {
                        setState(() {
                          _currentPage = page;
                        });
                      },
                      itemCount: _numPages,
                      itemBuilder: (context, index) {
                        // You can load images dynamically based on the index
                        // For example:
                        String imagePath =
                            'assets/images/onboarding_$index.png';
                        return Image.asset(
                          imagePath,
                          fit: BoxFit.cover,
                        );
                      },
                    ),
                    _buildPageIndicator(), // Dot indicator inside the image
                  ],
                ),
              ),
              Flexible(
                flex: 1, // Adjust the flex value to control container height
                child: Container(
                  decoration: const BoxDecoration(
                    borderRadius: const BorderRadius.only(
                      topLeft: Radius.circular(50),
                      topRight: Radius.circular(50),
                    ),
                  ),
                  padding: EdgeInsets.all(16.0),
                  child: Padding(
                    padding: const EdgeInsets.symmetric(horizontal: 16),
                    child: Column(
                      crossAxisAlignment: CrossAxisAlignment.center,
                      children: [
                        Text(
                          'Streaming movies and TV. Watch instantly',
                          style: TextStyle(
                            fontSize: 20,
                            fontWeight: FontWeight.bold,
                          ),
                          textAlign: TextAlign.center,
                        ),
                        SizedBox(height: 10),
                        Text(
                          'Enjoy all your favorite films and TV shows on your streaming devices',
                          style: TextStyle(
                            fontSize: 16,
                            color: Colors.grey,
                          ),
                          textAlign: TextAlign.center,
                        ),
                        SizedBox(height: 20),
                        Container(
                          width: double.infinity,
                          child: ElevatedButton(
                            onPressed: () {
                              BlocProvider.of<GetMoviesBloc>(context).add(GetStarted());
                              BlocProvider.of<GetMoviesBloc>(context).add(GetAllMovie());
                            },
                            child: Text('Get Started'),
                            style: ElevatedButton.styleFrom(
                              backgroundColor: Colors
                                  .blue, // Background color for the button
                            ),
                          ),
                        ),
                      ],
                    ),
                  ),
                ),
              ),
            ],
          ),
        );
      },
    );
  }

  Widget _buildPageIndicator() {
    List<Widget> indicators = [];
    for (int i = 0; i < _numPages; i++) {
      indicators.add(_buildIndicator(i));
    }
    return Row(
      mainAxisAlignment: MainAxisAlignment.center,
      children: indicators,
    );
  }

  Widget _buildIndicator(int index) {
    bool isCurrentPage = index == _currentPage;
    return Container(
      width: 8.0,
      height: 8.0,
      margin: EdgeInsets.symmetric(horizontal: 4.0),
      decoration: BoxDecoration(
        shape: BoxShape.circle,
        color: isCurrentPage ? Colors.blue : Colors.grey,
      ),
    );
  }
}
