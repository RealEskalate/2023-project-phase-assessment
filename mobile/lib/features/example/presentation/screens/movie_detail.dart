import 'dart:developer';

import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:mobile/features/example/presentation/bloc/add_bookmark/add_bookmark_event.dart';
import 'package:mobile/features/example/presentation/bloc/add_bookmark/add_bookmark_state.dart';

import '../../domain/entities/movie.dart';
import '../bloc/bloc.dart';

class MovieDetailRoute extends StatefulWidget {
  final Movie movie;
  const MovieDetailRoute({super.key, required this.movie});

  @override
  State<MovieDetailRoute> createState() => _MovieDetailRouteState();
}

class _MovieDetailRouteState extends State<MovieDetailRoute> {
  bool is_bookmarked = false;
  bool _isDisposed = false; // Flag to track widget disposal

  @override
  void initState() {
    super.initState();
    // movies

    context.read<MoviesBloc>().stream.listen((state) {
      if (!_isDisposed) {
        if (state is AddingBookmarkState) {
          log("Saving Movies..");
        }
        if (state is AddedBookmarkState) {
          log("Movies are added ${state.isAdded}");
          setState(() {
            is_bookmarked = true;
          });
        }
        if (state is AddBookmarkError) {
          log("Error ${state.errorMessage}");
        }
      }
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        leading: IconButton(
          icon: const Icon(Icons.arrow_back),
          onPressed: () {
            // Add your back button action here
          },
        ),
        title: const Text('Movie Detail'),
        actions: [
          IconButton(
            icon: Icon(
              is_bookmarked ? Icons.bookmark : Icons.bookmark_outline,
              color: is_bookmarked
                  ? Colors.blue
                  : null, // Customize the color if bookmarked
            ),
            onPressed: () {
              context.read<MoviesBloc>().add(AddBookmarkEvent(
                    title: widget.movie.title!,
                    image: widget.movie.image!,
                    duration: widget.movie.duration!,
                    category: widget.movie.category!,
                    id: widget.movie.id!,
                    rating: widget.movie.rating!,
                    createdAt: widget.movie.createdAt.toString(),
                    description: widget.movie.description!,
                  ));
            },
          ),
        ],
      ),
      body: SingleChildScrollView(
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            Stack(
              alignment: Alignment.bottomRight,
              children: [
                Padding(
                  padding: const EdgeInsets.all(10),
                  child: Container(
                    width: double.infinity,
                    height: 300.0,
                    decoration: BoxDecoration(
                      image: DecorationImage(
                        image: NetworkImage(widget
                            .movie.image!), // Replace with your movie image URL
                        fit: BoxFit.cover,
                      ),
                      borderRadius: const BorderRadius.only(
                        bottomLeft: Radius.circular(20.0),
                        bottomRight: Radius.circular(20.0),
                        topLeft: Radius.circular(20.0),
                        topRight: Radius.circular(20.0),
                      ),
                    ),
                  ),
                ),
                const Padding(
                  padding: EdgeInsets.all(16.0),
                  child: Row(
                    mainAxisAlignment: MainAxisAlignment.end,
                    children: [
                      Icon(
                        Icons.star,
                        color: Colors.yellow,
                      ),
                      SizedBox(width: 8.0),
                      Text(
                        '4.5',
                        style: TextStyle(
                          fontSize: 18.0,
                          fontWeight: FontWeight.bold,
                        ),
                      ),
                    ],
                  ),
                ),
              ],
            ),
            Padding(
              padding: const EdgeInsets.all(16.0),
              child: Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  Text(
                    widget.movie.title!,
                    style: const TextStyle(
                      fontSize: 24.0,
                      fontWeight: FontWeight.bold,
                    ),
                  ),
                  const SizedBox(height: 8.0),
                  Row(
                    children: [
                      const Icon(Icons.access_time),
                      const SizedBox(width: 8.0),
                      Text(
                        widget.movie.duration!,
                        style: const TextStyle(fontSize: 16.0),
                      ),
                    ],
                  ),
                  const SizedBox(height: 8.0),
                  Row(
                    children: [
                      const Icon(Icons.category),
                      const SizedBox(width: 8.0),
                      Text(
                        widget.movie.category!,
                        style: const TextStyle(fontSize: 16.0),
                      ),
                    ],
                  ),
                  const SizedBox(height: 16.0),
                  Text(
                    widget.movie.description!,
                    style: const TextStyle(fontSize: 16.0),
                  ),
                  const SizedBox(height: 36.0),
                  Center(
                    child: ElevatedButton(
                      onPressed: () {
                        Navigator.pushReplacementNamed(context, '/home');
                      },
                      style: ElevatedButton.styleFrom(
                          shape: RoundedRectangleBorder(
                              borderRadius: BorderRadius.circular(10)),
                          backgroundColor: const Color(0xff337BFF)),
                      child: const Text(
                        'Watch Now',
                        style: TextStyle(fontSize: 20, color: Colors.white),
                      ),
                    ),
                  )
                ],
              ),
            ),
          ],
        ),
      ),
    );
  }

  @override
  void dispose() {
    _isDisposed = true;
    super.dispose();
  }
}
