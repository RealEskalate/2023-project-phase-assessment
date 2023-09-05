import 'package:flutter/material.dart';
import 'package:mobile/features/example/presentation/screens/onboarding.dart';
import 'package:shared_preferences/shared_preferences.dart';

Future<void> main() async {
  WidgetsFlutterBinding.ensureInitialized();

  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return FutureBuilder<SharedPreferences>(
      future: SharedPreferences.getInstance(),
      builder: (context, snapshot) {
        if (snapshot.connectionState == ConnectionState.waiting) {
          return const CircularProgressIndicator();
        } else if (snapshot.hasError) {
          return Center(child: Text('Error: ${snapshot.error}'));
        } else {
          final prefs = snapshot.data!;
          final authToken = prefs.getString('auth_token');
          final initialRoute = '/';

          return MaterialApp(
            debugShowCheckedModeBanner: false,
            title: 'Alem cinema',
            theme: ThemeData(
              colorScheme: ColorScheme.fromSeed(
                seedColor: Colors.white,
                secondary: const Color(0xffEE6F57),
              ),
              useMaterial3: true,
            ),
            initialRoute: initialRoute,
            routes: {
              '/': (context) => const Onboarding(),
              '/home': (context) => const Placeholder(),
              '/detail': (context) => const Placeholder(),
              // Define routes here
            },
          );
        }
      },
    );
  }
}
