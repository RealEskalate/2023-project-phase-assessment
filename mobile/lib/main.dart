import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

import 'core/observers/bloc_observer.dart';
import 'core/presentation/router/router.dart';
import 'features/movie/presentation/bloc/movie_bloc.dart';
import 'injection/movie_dependency_injection.dart' as di;

Future<void> main() async {
  WidgetsFlutterBinding.ensureInitialized();
  await di.init();

  // for debugging
  Bloc.observer = AppBlocObserver();
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    return ScreenUtilInit(
      designSize: const Size(390, 844),
      child: BlocProvider(
        create: (context) => di.getIt<MovieBloc>(),
        child: MaterialApp.router(
          title: 'A2SV 2023 Mobile Assessment',
          routerConfig: router,
        ),
      ),
    );
  }
}
