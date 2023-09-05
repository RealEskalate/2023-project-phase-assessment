import 'package:flutter/material.dart';
import 'package:mobile/core/utils/app_dimension.dart';
import 'package:mobile/features/example/presentation/widgets/all_movies_widget/all_movies_widget.dart';
import 'package:mobile/features/example/presentation/widgets/saved_movie_card/saved_movie_card.dart';

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
        Container(
          width: AppDimension.width(350, context),
          height: AppDimension.height(350, context),
          child: ListView.builder(
            itemCount: 20,
            itemBuilder: (BuildContext context, int index) {
              return GestureDetector(
                  onTap: () {
                    Navigator.pushNamed(context, "/detail");
                  },
                  child: AllMoviesWidget());
            },
          ),
        ),
      ],
    );
  }
}
