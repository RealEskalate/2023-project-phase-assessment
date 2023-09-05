import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:mobile/features/HomePage/presentation/bloc/homepage_bloc.dart';

import '../../data/models/movie_data_model.dart';

class MyHomePage extends StatelessWidget {
  MyHomePage({super.key});

  TextEditingController textEditingController = TextEditingController();

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        centerTitle: true,
        title: const Text("Alem Cinema"),
        backgroundColor: Colors.white,
      ),
      body: BlocBuilder<HomepageBloc, HomepageState>(
        builder: (context, state) {
          if (state is MovieDataLoaded){
            return landingPage(context, state.data);
          }
          else{
            return Center(child: CircularProgressIndicator());
          }
        },
      ),
      
    );
  }

  ListView landingPage(BuildContext context, List<Data> data) {
    return ListView(
      children: [
        const SizedBox(height: 20),
        Row(
          mainAxisAlignment: MainAxisAlignment.spaceAround,
          children: [
            Container(
              height: 60,
              width: MediaQuery.sizeOf(context).width * 0.7,
              decoration: BoxDecoration(
                color: Colors.white,
                borderRadius: BorderRadius.circular(20),
              ),
              child: Padding(
                padding: const EdgeInsets.symmetric(horizontal: 20),
                child: TextField(
                  controller: textEditingController,
                  decoration: const InputDecoration(
                    border: InputBorder.none,
                    hintText: "Looking for shows",
                  ),
                ),
              ),
            ),
            GestureDetector(
              onTap: () {},
              child: Container(
                decoration: BoxDecoration(
                  color: Colors.blue,
                  borderRadius: BorderRadius.circular(10),
                ),
                width: 60,
                height: 60,
                child: const Center(
                    child: Icon(Icons.search, color: Colors.white)),
              ),
            ),
          ],
        ),
        const SizedBox(height: 20),
        Container(
          color: Colors.white,
          padding: const EdgeInsets.symmetric(horizontal: 20),
          height: 50,
          child: const Row(
            children: [
              Text("Saved Movies", style: TextStyle(fontSize: 24)),
              Icon(
                Icons.bookmark_outline,
                size: 30,
                color: Colors.blue,
              ),
            ],
          ),
        ),
        const SizedBox(
          height: 20,
        ),
        SizedBox(
          height: 360,
          child: ListView.builder(
            scrollDirection: Axis.horizontal,
            itemCount: 5,
            itemBuilder: (context, index) {
              return movieBanner(data[index], context);
            },
          ),
        ),
        const SizedBox(height: 20),
        Container(
          color: Colors.white,
          padding: const EdgeInsets.symmetric(horizontal: 20),
          height: 50,
          child: const Text("All Movies", style: TextStyle(fontSize: 24)),
        ),
        Container(
          height: 300,
          child: ListView.builder(
            itemCount: data.length,
            itemBuilder: (context, index) {
              return customListTile(data[index]);
            },
          ),
        ),
      ],
    );
  }

  Widget customListTile(Data data) {
    return Container(
      height: 150,
      color: Colors.white,
      child: Row(
        children: [
          Container(
            height: 140,
            width: 180,
            padding: const EdgeInsets.all(8.0),
            child: ClipRRect(
              borderRadius: BorderRadius.circular(20),
              child: Image.network(
                data.image ??
                    "https://img.freepik.com/premium-vector/movie-theater-signboard-blue_34230-295.jpg",
                fit: BoxFit.cover,
              ),
            ),
          ),
           Column(
            crossAxisAlignment: CrossAxisAlignment.center,
            mainAxisAlignment: MainAxisAlignment.center,
            children: [
              Text(data.title??"No Title",
                style: TextStyle(fontSize: 20, fontWeight: FontWeight.w600),
              ),
              Row(
                mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                children: [
                  Row(
                    children: [
                      Icon(
                        Icons.star,
                        color: Colors.yellow,
                        size: 30,
                      ),
                      Text(
                        data.rating.toString()??"2.5",
                        style: TextStyle(fontSize: 20),
                      ),
                    ],
                  ),
                  Row(
                    children: [
                      Icon(
                        Icons.lock_clock,
                        color: Colors.blue,
                        size: 30,
                      ),
                      Text(
                        "${data.duration} hours",
                        style: TextStyle(fontSize: 20),
                      ),
                    ],
                  )
                ],
              )
            ],
          ),
        ],
      ),
    );
  }

  Widget movieBanner(Data data, BuildContext context) {
    return SizedBox(
      height: 360,
      width: 280,
      child: Stack(
        children: [
          Container(
            height: 360,
            width: 280,
            padding: const EdgeInsets.all(8.0),
            child: ClipRRect(
              borderRadius: BorderRadius.circular(20),
              child: Image.network(
                data.image ??
                    "https://img.freepik.com/premium-vector/movie-theater-signboard-blue_34230-295.jpg",
                fit: BoxFit.cover,
              ),
            ),
          ),
          Align(
            alignment: const Alignment(0, 0.8),
            child: Container(
              width: 200,
              height: 100,
              decoration: BoxDecoration(
                color: Colors.white,
                borderRadius: BorderRadius.circular(20),
              ),
              child: const Column(
                crossAxisAlignment: CrossAxisAlignment.center,
                mainAxisAlignment: MainAxisAlignment.center,
                children: [
                  Text(
                    "Title",
                    style: TextStyle(fontSize: 20, fontWeight: FontWeight.w600),
                  ),
                  Row(
                    mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                    children: [
                      Row(
                        children: [
                          Icon(
                            Icons.star,
                            color: Colors.yellow,
                            size: 30,
                          ),
                          Text(
                            '4.5',
                            style: TextStyle(fontSize: 20),
                          ),
                        ],
                      ),
                      Row(
                        children: [
                          Icon(
                            Icons.lock_clock,
                            color: Colors.blue,
                            size: 30,
                          ),
                          Text(
                            '1 hours',
                            style: TextStyle(fontSize: 20),
                          ),
                        ],
                      )
                    ],
                  )
                ],
              ),
            ),
          )
        ],
      ),
    );
  }
}
