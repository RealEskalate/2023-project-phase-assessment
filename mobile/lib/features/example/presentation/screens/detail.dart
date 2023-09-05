import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:mobile/features/example/domain/entities/movie.dart';
import 'package:mobile/features/example/presentation/bloc/movie_bloc.dart';

class Detail extends StatefulWidget {
  const Detail({Key? key, this.movie});
  final Movie? movie;

  @override
  State<Detail> createState() => _DetailState();
}

class _DetailState extends State<Detail> {
  bool? b = false;
  @override
  Widget build(BuildContext context) {
    return BlocBuilder<MovieBloc, MovieState>(
      builder: (context, state) {
        return Scaffold(
          appBar: AppBar(
            centerTitle: true,
            backgroundColor: Colors.white,
            leading: IconButton(
              icon: Icon(Icons.arrow_back),
              color: Colors.black,
              onPressed: () {
                context.read<MovieBloc>().add(GetMovies());
                Navigator.pop(context);
              },
            ),
            title: Text(
              widget.movie!.title.toString(),
              style: TextStyle(color: Colors.black),
            ),
            actions: [
              IconButton(
                icon: Icon(b == false ? Icons.bookmark_border : Icons.bookmark),
                color: Colors.black,
                onPressed: () {
                  setState(() {
                    b = true;
                  });
                  context.read<MovieBloc>().add(BookMarkMovie(widget.movie!));
                },
              ),
            ],
          ),
          body: Container(
            margin: EdgeInsets.symmetric(horizontal: 20),
            child: Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                Stack(
                  children: [
                    Hero(
                      tag: widget.movie!.image ?? "",
                      child: ClipRRect(
                        borderRadius: BorderRadius.all(Radius.circular(20)),
                        child: Image.network(
                          widget.movie!.image ?? "",
                          width: double.infinity,
                          height: 450,
                          fit: BoxFit.cover,
                        ),
                      ),
                    ),
                    Positioned(
                      bottom: 1,
                      right: 10,
                      child: Container(
                        padding: EdgeInsets.all(10),
                        decoration: BoxDecoration(
                          color: const Color.fromARGB(255, 31, 30, 30),
                          borderRadius: BorderRadius.all(Radius.circular(10)),
                        ),
                        child: Column(
                          children: [
                            Icon(
                              Icons.star,
                              color: Colors.yellow,
                            ),
                            Text(
                              widget.movie!.rating.toString(),
                              style: TextStyle(color: Colors.white),
                            ),
                          ],
                        ),
                      ),
                    )
                  ],
                ),
                SizedBox(height: 15),
                Text(
                  widget.movie!.title.toString(),
                  style: TextStyle(
                    fontSize: 20,
                    fontWeight: FontWeight.bold,
                  ),
                ),
                SizedBox(height: 10),
                Row(
                  children: [
                    Icon(
                      Icons.access_time,
                      color: Colors.blue,
                    ),
                    SizedBox(width: 4),
                    Text(widget.movie!.duration.toString()),
                    SizedBox(width: 10),
                    Text(" | "),
                    Text(widget.movie!.category.toString()),
                    SizedBox(width: 10),
                  ],
                ),
                SizedBox(height: 10),
                Text(
                  widget.movie!.description.toString(),
                  style: TextStyle(
                    overflow: TextOverflow.clip,
                  ),
                ),
                SizedBox(height: 80),
                Container(
                  width: double.infinity,
                  child: ElevatedButton(
                    onPressed: () {},
                    style: ElevatedButton.styleFrom(
                      padding:
                          EdgeInsets.symmetric(horizontal: 20, vertical: 20),
                      shape: RoundedRectangleBorder(
                        borderRadius: BorderRadius.circular(15),
                      ),
                      backgroundColor: Colors.blue,
                    ),
                    child: Text(
                      "Watch now",
                      style: TextStyle(color: Colors.white, fontSize: 18),
                    ),
                  ),
                ),
              ],
            ),
          ),
        );
      },
    );
  }
}
