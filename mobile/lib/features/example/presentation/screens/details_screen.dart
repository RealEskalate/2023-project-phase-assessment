import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:get/get.dart';
import 'package:mobile/features/example/domain/entities/Movie.dart';
import 'package:mobile/features/example/presentation/bloc/bookmark/bookmark_bloc.dart';

class Detail extends StatefulWidget {
  final Movie movie;
  const Detail({super.key, required this.movie});

  @override
  State<Detail> createState() => _DetailState();
}

class _DetailState extends State<Detail> {
  Widget buildOnboardingBody() {
    return Stack(
      children: [
        Container(
          margin: EdgeInsets.only(top: 20, bottom: 20),
          // color: Colors.yellow.withOpacity(0.1),
          width: 370,
          height: 300,
          // height: Get.height/2.1,
          decoration: BoxDecoration(
            borderRadius: BorderRadius.all(Radius.circular(25)),
            image: DecorationImage(
              image: NetworkImage(
                "${widget.movie.image}",
              ),
              fit: BoxFit.cover,
            ),
          ),

          //
        ),
        Positioned(
          bottom: 10,
          right: 40,
          child: Container(
            width: 55,
            height: 60,
            decoration: BoxDecoration(
              borderRadius: BorderRadius.circular(10.0),
              color: Colors.black,
            ),
            child: Column(
              children: [
                Icon(
                  Icons.star,
                  color: Colors.yellow,
                ),
                Text(
                  "${widget.movie.rating}",
                  style: TextStyle(color: Colors.white),
                )
              ],
            ),
          ),
        )
      ],
    );
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        leading: IconButton(
          icon: Icon(
            Icons.arrow_back, // Back button icon
            color: Colors.black,
          ),
          onPressed: () {
            // Navigate back to the previous page when the button is pressed
            Navigator.of(context).pop();
          },
        ),
        backgroundColor: Colors.white,
        title: Center(
          child: Text(
            'Detail',
            style: TextStyle(
              color: Colors.black,
            ),
          ),
        ),
        actions: [
          IconButton(
            icon: Icon(
              Icons.bookmark_outline,
              color: Colors.black,
            ),
            onPressed: () {
              BlocProvider.of<BookmarkBloc>(context).add(BookMarkMovie());
            },
          ),
        ],
      ),
      backgroundColor: Color(0xFFF4F7FF),
      body: Column(
        mainAxisAlignment: MainAxisAlignment.center,
        mainAxisSize: MainAxisSize.max,
        children: [
          // SizedBox(height: 20,),
          Container(
            child: buildOnboardingBody(),
          ),
          Expanded(
            child: Container(
              width: Get.width,
              decoration: BoxDecoration(
                color: const Color.fromARGB(255, 255, 255, 255),
                borderRadius: BorderRadius.only(
                  topLeft: Radius.circular(38),
                  topRight: Radius.circular(38),
                ),
              ),
              child: Column(
                children: [
                  Container(
                    margin: EdgeInsets.only(top: 40),
                    width: 275,
                    child: Text(
                      '${widget.movie.title}',
                      style: TextStyle(
                        color: Color(0xFF0D253C),
                        fontSize: 24,
                        // fontStyle: FontStyle.italic,
                        // fontFamily: 'Poppins',
                        fontWeight: FontWeight.bold,
                      ),
                    ),
                  ),
                  SizedBox(
                    height: 5,
                  ),
                  Container(
                    // margin: EdgeInsets.only(),
                    width: 275,
                    child: Row(
                      children: [
                        Icon(
                          Icons.access_time, // Clock icon
                          color: Colors.black, // Icon color
                        ),
                        Text(
                          '${widget.movie.duration} hour  |  ${widget.movie.category}',
                          style: TextStyle(
                            color: Color(0xFF0D253C),
                            // fontSize: 24,
                            // fontStyle: FontStyle.italic,
                            // fontFamily: 'Poppins',
                            fontWeight: FontWeight.w300,
                          ),
                        ),
                      ],
                    ),
                  ),
                  Container(
                    margin: EdgeInsets.only(top: 20),
                    width: 275,
                    height: 50,
                    child: SingleChildScrollView(
                      child: Text(
                        '${widget.movie.description}',
                        style: TextStyle(
                          color: Color(0xFF0D253C),
                          fontSize: 18,
                          // fontStyle: FontStyle.italic,
                          // fontFamily: 'Poppins',
                          fontWeight: FontWeight.w400,
                        ),
                      ),
                    ),
                  ),
                  SizedBox(
                    height: 10,
                  ),
                  SizedBox(
                    height: 40,
                    width: 280,
                    child: ElevatedButton(
                        onPressed: () {
                          // Navigate to the details page when the button is pressed
                          Navigator.pop(context);
                        },
                        child: Text(
                          "Watch Now",
                          style: TextStyle(
                            fontSize: 20,
                          ),
                        )),
                  )
                ],
              ),
            ),
          ),
        ],
      ),
    );
  }
}
