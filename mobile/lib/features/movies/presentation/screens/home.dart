import 'dart:developer';

import 'package:flutter/material.dart';
import 'package:mobile/features/movies/presentation/widgets/MovieList.dart';

//
class Home extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('Movies'),
      ),
      //body has search bar
      body: SingleChildScrollView(
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            //search bar row with text field and iconbutton
            // Row(
            //   children: [
            //     Container(
            //       margin: EdgeInsets.fromLTRB(20, 20, 0, 0),
            //       child: Expanded(
            //         child: TextField(
            //           decoration: InputDecoration(
            //             border: OutlineInputBorder(),
            //             labelText: 'Search',
            //           ),
            //         ),
            //       ),
            //     ),
            //     Expanded(
            //       child: IconButton(
            //         icon: Icon(Icons.search),
            //         onPressed: () {
            //           log("search clicked");
            //         },
            //       ),
            //     )
            //   ],
            // ),

            Row(
              children: [
                Flexible(
                    flex: 3,
                    child: TextField(
                      decoration: InputDecoration(
                        border: OutlineInputBorder(),
                        hintText: 'Search',
                      ),
                    )),
                Expanded(
                  flex: 1,
                  child: IconButton(
                    icon: Icon(Icons.search),
                    onPressed: () {
                      log("search clicked");
                    },
                  ),
                )
              ],
            ),

            Text("Saved movies"),

            // SavedMovieCard(),

            SingleChildScrollView(
              scrollDirection: Axis.horizontal,
              child: Row(
                children: [
                  SavedMovieCard(),
                  SavedMovieCard(),
                  SavedMovieCard(),
                ],
              ),
            ),
            Text("All movies"),

            MovieList(),
          ],
        ),
      ),
    );
  }
}

class SavedMovieCard extends StatelessWidget {
  const SavedMovieCard({
    super.key,
  });

  @override
  Widget build(BuildContext context) {
    return Container(
        height: MediaQuery.of(context).size.height * 0.33,
        // width: MediaQuery.of(context).size.width * 0.65,
        margin: EdgeInsets.fromLTRB(10, 0, 10, 0),
        decoration: BoxDecoration(
          border: Border.all(
            color: Colors.black,
            width: 2,
          ),
          borderRadius: BorderRadius.circular(20),
          image: DecorationImage(
            image: AssetImage('assets/333.jpg'),
            fit: BoxFit.fill,
          ),
        ),
        // height: MediaQuery.of(context
        //).size.height * 0.33,
        child: // Text("data"),
            Align(
                alignment: Alignment.bottomCenter,
                child: Container(
                  margin: EdgeInsets.all(10),
                  padding: EdgeInsets.all(10),
                  decoration: BoxDecoration(
                    borderRadius: BorderRadius.circular(15),
                    color: Colors.white,
                  ),
                  height: 70,
                  child: const Column(
                      crossAxisAlignment: CrossAxisAlignment.center,
                      mainAxisAlignment: MainAxisAlignment.end,
                      children: [
                        Text(
                          "Title",
                          style: TextStyle(color: Colors.black),
                        ),
                        Row(
                          mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                          children: [
                            //star icon
                            Icon(
                              Icons.star,
                              color: Colors.yellow,
                            ),
                            Text(
                              "4.5",
                            ),
                            //clock icon
                            Icon(
                              Icons.access_time,
                              color: Colors.blue,
                            ),
                            Text("1 hour"),
                          ],
                        )
                      ]),
                )));
  }
}
