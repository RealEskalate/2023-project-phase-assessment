import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

import '../../../../core/presentation/theme/app_colors.dart';
import '../../../../injection/injection_container.dart';
import '../bloc/movie_bloc.dart';
import '../bloc/movie_event.dart';
import '../bloc/movie_state.dart';
import '../widgets/movie_card.dart';
import '../widgets/movie_card_list.dart';
import '../widgets/movie_row_card.dart';
import '../widgets/movie_row_card_list.dart';
import '../widgets/search_bar.dart';

class HomeScreen extends StatelessWidget {
  const HomeScreen({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        elevation: 0.0,
        backgroundColor: AppColors.white,
        leading: const Icon(
          Icons.arrow_back,
          color: AppColors.black,
        ),
        title: const Center(
          child: Text(
            'Alem Cinema',
            style: TextStyle(color: AppColors.black, fontSize: 20.0),
          ),
        ),
      ),
      body: MultiBlocProvider(
        providers: [
          BlocProvider(
            create: (context) =>
                serviceLocator<MovieBloc>()..add(LoadAllMoviesEvent()),
          ),
        ],
        child: BlocBuilder<MovieBloc, MovieState>(
          builder: (context, _) => buildBody(context),
        ),
      ),
    );
  }

  Widget buildBody(BuildContext context) {
    return Container(
      padding: EdgeInsets.all(10.0),
      child: Column(crossAxisAlignment: CrossAxisAlignment.start, children: [
        CustomSearchBar(),
        SizedBox(
          height: 20.h,
        ),
        Row(
          children: [
            Text(
              'Saved Movies',
              style: Theme.of(context).textTheme.titleMedium,
            ),
            Icon(
              Icons.bookmark_border_outlined,
              color: AppColors.blue,
            )
          ],
        ),

        //
        SingleChildScrollView(
          scrollDirection: Axis.horizontal,
          child: MovieRowCardList(
            movies: [],
          ),
        ),

        Text(
          'All Movies',
          style: Theme.of(context).textTheme.displayMedium,
        ),

        //
        SizedBox(
          height: 250.w,
          child: SingleChildScrollView(
            child: MovieCardList(
              movies: [],
            ),
          ),
        )
      ]),
    );
  }
}
