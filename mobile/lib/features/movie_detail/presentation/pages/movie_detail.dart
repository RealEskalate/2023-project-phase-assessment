// here we will implement movie detail page

import 'package:flutter/material.dart';
import 'package:mobile/core/presentation/custom_app_bar.dart';

import '../../../home/domain/entities/movie.dart';

class MovieDetail extends StatefulWidget {
  const MovieDetail({super.key, required this.movie});
  final Movie movie;

  @override
  State<MovieDetail> createState() => _MovieDetailState();
}

class _MovieDetailState extends State<MovieDetail> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
        appBar: AppBar(
            automaticallyImplyLeading: false,
            backgroundColor: Colors.white,
            title: CustomAppBar(
              title: "Detail",
              icon: Icon(Icons.bookmark_outline, color: Colors.black),
              externalContext: context,
            )),
        body: Container(
          padding: EdgeInsets.only(bottom: 20),
          child: Column(
            mainAxisAlignment: MainAxisAlignment.spaceBetween,
            children: [
              Container(
                margin: EdgeInsets.only(top: 10),
                padding: EdgeInsets.all(20),
                child: Image.network(
                  widget.movie.image,
                  fit: BoxFit.fill,
                  height: 450,
                  width: double.infinity,
                ),
              ),
              Container(
                  padding: EdgeInsets.symmetric(horizontal: 20),
                  child: Column(
                    crossAxisAlignment: CrossAxisAlignment.start,
                    mainAxisAlignment: MainAxisAlignment.spaceBetween,
                    children: [
                      Text(
                        widget.movie.title,
                        style: TextStyle(
                            fontSize: 22, fontWeight: FontWeight.w600),
                      ),
                      SizedBox(height: 30),
                      Row(children: [
                        Icon(Icons.access_time),
                        Text(widget.movie.duration),
                        SizedBox(
                          width: 20,
                        ),
                        Icon(Icons.star),
                        Text(widget.movie.rating)
                      ]),
                      SizedBox(height: 30),
                      SingleChildScrollView(
                        child: Text(
                          widget.movie.description,
                          style: TextStyle(fontSize: 18),
                        ),
                      ),
                    ],
                  )),
              Container(
                height: 60,
                width: double.infinity,
                margin: const EdgeInsets.symmetric(horizontal: 40),
                child: ElevatedButton(
                    onPressed: () {},
                    child: Text(
                      "Watch Now",
                      style: TextStyle(fontSize: 22),
                    )),
              )
            ],
          ),
        ));
  }
}
