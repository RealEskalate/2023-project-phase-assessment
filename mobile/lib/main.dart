import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

import 'bloc_observer.dart';
import 'core/presentation/routes/router.dart';
import 'core/presentation/theme/app_theme.dart';

import 'features/movie/presentation/bloc/movie_bloc.dart';
import 'features/movie/presentation/bloc/movie_event.dart';
import 'injection/injection_container.dart' as di;

Future<void> main() async {
  WidgetsFlutterBinding.ensureInitialized();

  await di.init();
  Bloc.observer = SimpleBlocObserver();

  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    return ScreenUtilInit(
      designSize: const Size(390, 844),
      minTextAdapt: true,
      splitScreenMode: true,
      builder: (_, child) => MultiBlocProvider(
        providers: [
          BlocProvider<MovieBloc>(
            create: (_) =>
                di.serviceLocator<MovieBloc>()..add(LoadAllMoviesEvent()),
          ),
        ],
        child: MaterialApp.router(
          title: 'Flutter Demo',
          theme: AppTheme.themeData,
          debugShowCheckedModeBanner: false,
          routerConfig: router,
        ),
      ),
    );
  }
}
