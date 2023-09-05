import 'dart:developer';

import 'package:flutter/material.dart';

class Onboarding extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
//copilot
    // print("started");
    return Scaffold(
      body: SafeArea(
        child: Column(children: [
          Container(
              decoration: BoxDecoration(
                  gradient: LinearGradient(
                      begin: Alignment.topCenter,
                      end: Alignment.bottomCenter,
                      colors: [Colors.purple, Colors.pink])),
              height: MediaQuery.of(context).size.height * 0.6,
              width: MediaQuery.of(context).size.width,
              child: Image.asset(
                'assets/333.jpg',
                fit: BoxFit.fitWidth,
              )),
          Container(
            width: MediaQuery.of(context).size.width,
            decoration: BoxDecoration(
                color: Colors.white,
                borderRadius: BorderRadius.only(
                    topLeft: Radius.circular(10),
                    topRight: Radius.circular(10))),
            child: Column(children: [
              Text("Streaming movie and TV. Watch instantly \n",
                  textAlign: TextAlign.center,
                  style: TextStyle(
                    color: Colors.black,
                    fontWeight: FontWeight.bold,
                    fontSize: 30,
                  )),
              Text("Enjoy all your favorite movies and TV shows"),
              Container(
                padding: EdgeInsets.all(20),
                width: MediaQuery.of(context).size.width * 0.9,
                // heigh
                child: ElevatedButton(
                    onPressed: () {
                      // print("Get Started");
                      log("get started clicked");
                      Navigator.pushNamed(context, '/home');
                    },
                    child: Text("Get Started")),
              )
            ]),
          ),
        ]),
      ),
    );
  }
}
