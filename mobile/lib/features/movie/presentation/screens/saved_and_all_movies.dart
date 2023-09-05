import 'package:flutter/material.dart';
import 'package:mobile/core/utils/app_dimension.dart';
import 'package:mobile/features/movie/presentation/widgets/all_movies_widget/all_movies_widget.dart';
import 'package:mobile/features/movie/presentation/widgets/saved_movie_card/saved_movie_card.dart';


class SavedAndAllMovies extends StatefulWidget {
  const SavedAndAllMovies({super.key});

  @override
  State<SavedAndAllMovies> createState() => _SavedAndAllMoviesState();
}

class _SavedAndAllMoviesState extends State<SavedAndAllMovies> {
  @override
  Widget build(BuildContext context) {
    return Column(
      children: [

        Container(
          margin: EdgeInsets.only(top: AppDimension.height(20, context),



          
          ),
          width: double.infinity,

          height: AppDimension.height(60, context),
          color: Colors.white,
          child: Container(
            margin: EdgeInsets.only(          left:  AppDimension.width(20, context),
          right: AppDimension.width(40, context),),
            child: Row(
              mainAxisAlignment: MainAxisAlignment.spaceBetween,
              children: [
                Container(
                  margin: EdgeInsets.symmetric(
                      horizontal: AppDimension.width(20, context)),
                  child: Text(
                    "All Movies",
                    style: TextStyle(fontSize: AppDimension.height(30, context)),
                  ),
                ),
                Icon(Icons.bookmark_border,
                color: Colors.blue,
                size: AppDimension.height(35, context),
                )
          
              ],
            ),
          ),
        ),

        Container(
          width: double.infinity,
          height: AppDimension.height(390, context),
          child: ListView.builder(
            scrollDirection: Axis.horizontal,
            itemCount: 10,
            itemBuilder: (BuildContext context, int index) {
              return GestureDetector(
                  onTap: () {
                    Navigator.pushNamed(context, "/detail");
                  },
                  child: SavedMovieCard());
            },
          ),
        ),
        Container(
          width: double.infinity,
          height: AppDimension.height(60, context),
          color: Colors.white,
          child: Row(
            children: [
              Container(
                margin: EdgeInsets.symmetric(
                    horizontal: AppDimension.width(20, context)),
                child: Text(
                  "All Movies",
                  style: TextStyle(fontSize: AppDimension.height(30, context)),
                ),
              ),
            ],
          ),
        ),


        Column(
  children: [
    Container(
      width: AppDimension.width(350, context),
      child: ListView.builder(
        physics: NeverScrollableScrollPhysics(),
        shrinkWrap: true, // Allow the ListView to take up only as much height as needed
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
)

      ],
    );
  }
}
