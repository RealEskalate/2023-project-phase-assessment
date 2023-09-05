import 'package:flutter/material.dart';

class OnboardingPage extends StatefulWidget {
  const OnboardingPage({super.key});

  @override
  State<OnboardingPage> createState() => _OnboardingPageState();
}

class _OnboardingPageState extends State<OnboardingPage> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('OnboardingPage'),
      ),
      body: SafeArea(
        child: Column(
          children: <Widget>[
            PageView(
              children: <Widget>[
                Container(
                  width: double.infinity,
                  height: 500,
                  color: Colors.red,
                ),
                Container(
                  color: Colors.blue,
                  width: double.infinity,
                  height: 500,
                ),
                Container(
                  color: Colors.green,
                  width: double.infinity,
                  height: 500,
                ),
              ],
            ),
          ],
        ),
      ),
    );
  }
}
