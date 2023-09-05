import 'package:flutter/material.dart';
import 'package:mobile/core/utils/app_dimension.dart';
import 'package:mobile/features/example/presentation/screens/saved_and_all_movies.dart';
import 'package:mobile/features/example/presentation/widgets/all_movies_widget/all_movies_widget.dart';
import 'package:mobile/features/example/presentation/widgets/saved_movie_card/saved_movie_card.dart';
import 'package:mobile/features/example/presentation/widgets/searchedResult/searchedResult.dart';

class HomePage extends StatefulWidget {
  const HomePage({super.key});

  @override
  State<HomePage> createState() => _HomePageState();
}

class _HomePageState extends State<HomePage> {
  bool is_searching = false;

  TextEditingController _seachController = TextEditingController();
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: Colors.grey.shade200,
      appBar: AppBar(
        backgroundColor: Colors.white,
        leading: IconButton(
          icon: Icon(Icons.arrow_back),
          onPressed: () {
            if(is_searching==true){
              Navigator.pushNamed(context, "/home");
            }
            else{
              Navigator.pushNamed(context, "/");
            }
          },
        ),
        title: Container(
            margin: EdgeInsets.only(left: AppDimension.width(60, context)),
            child: Text('Alem Cinema')),
      ),
      body: SingleChildScrollView(
        child: Column(
          children: [
            Container(
              margin: EdgeInsets.only(
                  left: AppDimension.width(40, context),
                  top: AppDimension.height(40, context)),
              child: Row(
                children: [
                  Container(
                    width: AppDimension.height(350, context),
                    decoration: BoxDecoration(
                      borderRadius: BorderRadius.circular(
                          AppDimension.height(10, context)),
                      color: Colors.white,
                      border: Border.all(
                        color: Colors.white, // Border color
                        width: 1.0, // Border width
                      ),
                    ),
                    child: Padding(
                      padding: EdgeInsets.only(
                          left: AppDimension.width(10, context)),
                      child: TextField(
                        controller: _seachController,
                        decoration: InputDecoration(
                          hintText: 'Search and Article',
                          border: InputBorder.none,
                        ),
                        style: TextStyle(
                          color: Colors.black,
                          fontSize: AppDimension.height(25, context),
                        ),
                      ),
                    ),
                  ),
                  Container(
                    margin:
                        EdgeInsets.only(left: AppDimension.width(10, context)),
                    height: AppDimension.height(60, context),
                    width: AppDimension.width(60, context),
                    decoration: BoxDecoration(
                        color: Colors.blue,
                        borderRadius: BorderRadius.circular(
                            AppDimension.height(10, context))),
                    child: IconButton(
                      icon: Icon(Icons.search, color: Colors.white),
                      onPressed: () {
                        setState(() {
                          is_searching = true;
                        });
                      },
                    ),
                  ),
                ],
              ),
            ),
            is_searching ? SearchedResult() : SavedAndAllMovies()
          ],
        ),
      ),
    );
  }
}





// Container(
//               margin: EdgeInsets.only(top: AppDimension.height(40, context)),
//               width: double.infinity,
//               height: AppDimension.height(60, context),
//               color: Colors.white,
//               child: Row(
//                 children: [
//                   Container(
//                     margin: EdgeInsets.symmetric(
//                         horizontal: AppDimension.width(20, context)),
//                     child: Text(
//                       "Saved Movie",
//                       style:
//                           TextStyle(fontSize: AppDimension.height(30, context)),
//                     ),
//                   ),
//                   Container(
//                     child: Icon(
//                       Icons.bookmark,
//                       color: Colors.blue,
//                       size: AppDimension.height(40, context),
//                     ),
//                   )
//                 ],
//               ),
//             ),
//             Container(
//               width: double.infinity,
//               height: AppDimension.height(390, context),
//               child: ListView.builder(
//                 scrollDirection: Axis.horizontal,
//                 itemCount: 10,
//                 itemBuilder: (BuildContext context, int index) {
//                   return GestureDetector(
//                       onTap: () {
//                         Navigator.pushNamed(context, "/detail");
//                       },
//                       child: SavedMovieCard());
//                 },
//               ),
//             ),
//             Container(
//               width: double.infinity,
//               height: AppDimension.height(60, context),
//               color: Colors.white,
//               child: Row(
//                 children: [
//                   Container(
//                     margin: EdgeInsets.symmetric(
//                         horizontal: AppDimension.width(20, context)),
//                     child: Text(
//                       "All Movies",
//                       style:
//                           TextStyle(fontSize: AppDimension.height(30, context)),
//                     ),
//                   ),
//                 ],
//               ),
//             ),
//             Container(
//               width: AppDimension.width(350, context),
//               height: AppDimension.height(350, context),
//               child: ListView.builder(
//                 itemCount: 20,
//                 itemBuilder: (BuildContext context, int index) {
//                   return GestureDetector(
//                       onTap: () {
//                         Navigator.pushNamed(context, "/detail");
//                       },
//                       child: AllMoviesWidget());
//                 },
//               ),
//             ),