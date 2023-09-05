import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

import '../../../../core/presentation/app_colors.dart';

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
    return SizedBox(
      width: MediaQuery.of(context).size.width - 40,
      child: Row(
        children: [
          Expanded(
            child: TextField(
              controller: _textEditingController,
              style: const TextStyle(
                color: AppColors.darkerBlue,
                fontFamily: 'Poppins',
                fontSize: 18,
              ),
              decoration: InputDecoration(
                hintText: 'looking for shows',
                hintStyle: const TextStyle(
                  color: AppColors.gray300,
                  fontFamily: 'Poppins',
                  fontSize: 14,
                  fontWeight: FontWeight.w200,
                ),
                filled: true,
                fillColor: AppColors.white,
                border: OutlineInputBorder(
                  borderRadius: BorderRadius.circular(10.0),
                  borderSide: BorderSide.none,
                ),
                contentPadding:
                    const EdgeInsets.fromLTRB(15.0, 10.0, 10.0, 0.0).w,
                focusedBorder: OutlineInputBorder(
                  borderRadius: BorderRadius.circular(10.0),
                  borderSide: const BorderSide(color: AppColors.blue),
                ),
              ),
              onSubmitted: (value) {
                // BlocProvider.of<ArticleBloc>(context)
                //     .add(FilterArticlesEvent(Tag(name: ''), value));
              },
            ),
          ),
          SizedBox(
            width: 16.w,
          ),
          GestureDetector(
            onTap: () {},
            child: const SearchIcon(),
          ),
        ],
      ),
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
