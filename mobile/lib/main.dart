import 'package:flutter/material.dart';
import 'package:mobile/movie_app.dart';
import 'injection/injection_container.dart' as dependency_injection;

void main() async{
  WidgetsFlutterBinding.ensureInitialized();
  await dependency_injection.init();
  runApp(const MovieApp());
}

