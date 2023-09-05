import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';
import 'package:go_router/go_router.dart';

import '../../../../core/presentation/routes/routes.dart';
import '../../../../core/presentation/theme/app_colors.dart';
import '../bloc/movie_bloc.dart';
import '../bloc/movie_event.dart';

class SplashContainer extends StatelessWidget {
  const SplashContainer({
    super.key,
  });

  @override
  Widget build(BuildContext context) {
    return SizedBox(
      height: 320.h,
      width: 390.w,
      child: Container(
        width: 330.w,
        padding: const EdgeInsets.all(15.0),
        decoration: BoxDecoration(
            color: Colors.white, borderRadius: BorderRadius.circular(40.0)),
        child: Column(
            mainAxisAlignment: MainAxisAlignment.spaceEvenly,
            crossAxisAlignment: CrossAxisAlignment.center,
            children: [
              SizedBox(
                width: 350.w,
                child: const Text(
                  'Streaming Movie and TV. Watch instantly',
                  style: TextStyle(
                    fontFamily: 'Poppins',
                    color: AppColors.darkerBlue,
                    fontSize: 35,
                    fontWeight: FontWeight.w600,
                  ),
                ),
              ),
              Text(
                'Enjoy all you favorite films and TV shows on your streaming devices',
                style: Theme.of(context).textTheme.bodyMedium,
              ),
              SizedBox(
                width: 350.w,
                height: 50.h,
                child: ElevatedButton(
                  onPressed: () {
                    context.push(Routes.home);
                    BlocProvider.of<MovieBloc>(context)
                        .add(LoadAllMoviesEvent());
                  },
                  child: const Text('Get Started'),
                ),
              )
            ]),
      ),
    );
  }
}
