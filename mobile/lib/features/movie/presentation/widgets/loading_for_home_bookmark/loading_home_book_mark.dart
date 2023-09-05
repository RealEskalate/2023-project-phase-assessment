import 'package:flutter/material.dart';
import 'package:flutter/src/widgets/container.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:mobile/core/utils/app_dimension.dart';

class CircularIndicatorBookMarked extends StatelessWidget {
  const CircularIndicatorBookMarked({super.key});

  @override
  Widget build(BuildContext context) {
    return Container(
      width: 100,
      
      color: Colors.white,
      height:100,
      child: Center(
        child: CircularProgressIndicator(
          color: Colors.red,
        ),
      ),
    );
  }
}