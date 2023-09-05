import 'package:flutter/material.dart';
import 'package:second/feature/homepage/presentation/pages/widgets/bottom_sheet.dart';

import 'widgets/picture.dart';

class HomePage extends StatelessWidget {
  const HomePage({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: SafeArea(
        child: Column(
            children: [
              PictureWidget(),
              CustomizeBottomSheet(),
            ],
          ),
        ),
    );
  }
}
