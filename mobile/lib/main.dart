import 'package:flutter/foundation.dart';
import 'package:flutter/material.dart';
import 'package:device_preview/device_preview.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:mobile/features/home/presentation/bloc/home_bloc.dart';
import 'package:mobile/features/onboarding/presentation/pages/onboarding.dart';
import "package:mobile/injection/injection_container.dart" as di;

void main() async {
  await di.init();

  runApp(DevicePreview(
      enabled: !kReleaseMode,
      builder: (context) => MultiBlocProvider(providers: [
            BlocProvider(create: (context) => HomeBloc()),
          ], child: const MyApp())));
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    return const MaterialApp(
      debugShowCheckedModeBanner: false,
      title: 'Alem Cinema',
      home: OnboardingPage(),
    );
  }
}
