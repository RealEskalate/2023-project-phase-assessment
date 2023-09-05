import 'dart:developer';

import 'package:flutter/material.dart';
import 'package:mobile/features/movies/data/datasources/remote_data_source.dart';
import 'package:mobile/features/movies/data/repository/movie_repo_impl.dart';

import '../../domain/usecases/get_all_movies.dart';

class MovieDetail extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
        appBar: AppBar(
          title: Text('Movie Detail'),
        ),
        body: Center(
          child: Container(
            margin: EdgeInsets.all(20),
            child: Column(
              children: [
                Image.asset("assets/333.jpg"),
                Text("Movie Title",
                    style: TextStyle(
                      color: Colors.black,
                      fontWeight: FontWeight.bold,
                      fontSize: 20,
                    )),
                Row(
                  children: [
                    Text("1 hour"),
                    Text(" | "),
                    Text("Comedy and drama"),
                  ],
                ),
                Spacer(),

                Text(
                    "Photo-realistic portrait of an astronaut floating in space with the Earth in the background. Use camera with a 200mm lens at F 1.2 aperture setting to blur the background and isolate the subject. The lighting should be dramatic and dreamlike with the sun shining on the astronaut’s face and spacesuit."),
                // ElevatedButton(onPressed: () {}, child: Text("Watch Now"))
                GestureDetector(
                    onTap: () async {
                      log("watch now");

                      // Navigator.pushNamed(context, '/task-detail')
                    },
                    child: Container(
                        height: 60,
                        padding: const EdgeInsets.all(20),
                        margin: const EdgeInsets.all(10),
                        decoration: BoxDecoration(
                          borderRadius: BorderRadius.circular(20),
                          color: Color.fromARGB(255, 28, 111, 235),
                        ),
                        child: const Center(
                          child: Text(
                            'Watch now',
                            style: TextStyle(
                              color: Colors.white,
                              fontWeight: FontWeight.bold,
                            ),
                          ),
                        )))
              ],
            ),
          ),
        ));
    // TODO: implement build
  }
}
