import 'package:flutter/material.dart';
import 'package:flutter/src/widgets/container.dart';
import 'package:flutter/src/widgets/framework.dart';

class CircularProgessIndicator extends StatelessWidget {
  const CircularProgessIndicator({super.key});

  @override
  Widget build(BuildContext context) {
    return Center(
      child: CircularProgressIndicator(
        
        color: Colors.red,
      ),
    );
  }
}