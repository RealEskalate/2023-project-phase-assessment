import 'package:flutter/material.dart';
import 'package:mobile/core/utils/app_dimension.dart';
import 'package:mobile/features/movie/presentation/widgets/all_movies_widget/all_movies_widget.dart';

class SearchedResult extends StatelessWidget {
  const SearchedResult({super.key});

  @override
  Widget build(BuildContext context) {
    return Column(
      children: [
        Container(
          width: AppDimension.width(350, context),
          child: ListView.builder(
            physics: NeverScrollableScrollPhysics(),
            shrinkWrap:true, 
            itemCount: 10,
            itemBuilder: (BuildContext context, int index) {
              return GestureDetector(
                onTap: () {
                  Navigator.pushNamed(context, "/detail");
                },
                child: AllMoviesWidget(),
              );
            },
          ),
        ),
      ],
    );
  }
}
