import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

import '../../../../core/presentation/theme/app_colors.dart';
import '../bloc/movie_bloc.dart';
import '../bloc/movie_event.dart';

class CustomSearchBar extends StatefulWidget {
  const CustomSearchBar({Key? key});

  @override
  _CustomSearchBarState createState() => _CustomSearchBarState();
}

class _CustomSearchBarState extends State<CustomSearchBar> {
  final TextEditingController _textEditingController = TextEditingController();

  @override
  void dispose() {
    _textEditingController.dispose();
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    return Row(
      mainAxisAlignment: MainAxisAlignment.spaceAround,
      children: [
        Container(
          height: 60.h,
          width: 250.w,
          decoration: BoxDecoration(
              borderRadius: BorderRadius.circular(10.0),
              color: AppColors.white),
          child: TextField(
              decoration: const InputDecoration(
                hintText: 'Looking for Shows',
              ),
              controller: _textEditingController),
        ),
        SizedBox(
          width: 15.0,
        ),
        GestureDetector(
          onTap: () {
             final value = _textEditingController.text;
                    BlocProvider.of<MovieBloc>(context)
                        .add(FilterMoviesEvent(value));
          },
          child: SearchIcon())
      ],
    );
  }
}

class SearchIcon extends StatelessWidget {
  const SearchIcon({Key? key});

  @override
  Widget build(BuildContext context) {
    return Container(
      height: 60.h,
      width: 52.w,
      decoration: BoxDecoration(
        borderRadius: BorderRadius.circular(10.0),
        color: AppColors.lightBlue,
      ),
      child: const Icon(
        Icons.search,
        size: 30,
        color: AppColors.white,
      ),
    );
  }
}
