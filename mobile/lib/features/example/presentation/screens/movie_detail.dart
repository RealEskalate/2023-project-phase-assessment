import 'package:flutter/material.dart';

class MovieDetailPage extends StatefulWidget {
  const MovieDetailPage({super.key});

  @override
  State<MovieDetailPage> createState() => _MovieDetailPageState();
}

class _MovieDetailPageState extends State<MovieDetailPage> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      
      
      appBar:  PreferredSize(
        preferredSize:  Size.fromHeight(60),
        child: AppBar(
          flexibleSpace: Container(
            decoration: const BoxDecoration(color: Colors.white),
          ),
          title: Padding(
            padding: const EdgeInsets.symmetric(horizontal: 15),
            child: Row(
              mainAxisAlignment: MainAxisAlignment.start,
              children: [
                Icon(Icons.chevron_left),
                SizedBox(width: 120,),
                Container(
                  margin: EdgeInsets.only(left: 15),
                  child: Text(
                    "Detail",
                    style: TextStyle(
                      color: Colors.black,
                    ),
                  ),
                ),
              ],
                  
            ),
          ),
        ),
      ),
      body: Container(
        child: Text('hello moview'),
      ),
    );
  }
}