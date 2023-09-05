import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:mobile/features/movies/domain/entities/movie.dart';
import 'package:mobile/features/movies/presentation/cubit/bookmark_cubit.dart';
import 'package:mobile/injection/setup.dart';

class DetailScreen extends StatelessWidget {
  Movie movie;
  DetailScreen({super.key, required this.movie});

  @override
  Widget build(BuildContext context) {
    double height = MediaQuery.of(context).size.height;
    double width = MediaQuery.of(context).size.width;
    return BlocProvider(
      create: (context) => sl<BookmarkCubit>()..loadedBookMark(movie),
      child: BlocBuilder<BookmarkCubit, BookmarkState>(
        builder: (context, state) {
          return Scaffold(
              floatingActionButtonLocation:
                  FloatingActionButtonLocation.centerFloat,
              floatingActionButton: Flexible(
                flex: 1,
                child: FilledButton.icon(
                  style: ButtonStyle(
                    backgroundColor: MaterialStateProperty.all(
                        Theme.of(context).colorScheme.primary),
                    padding: MaterialStateProperty.all(EdgeInsets.symmetric(
                        vertical: 20, horizontal: width * 0.3)),
                    shape: MaterialStateProperty.all(
                      RoundedRectangleBorder(
                        borderRadius: BorderRadius.circular(20),
                      ),
                    ),
                  ),
                  onPressed: () {
                    Navigator.of(context).pop();
                  },
                  label: Text("Watch Now"),
                  icon: Icon(Icons.play_arrow),
                ),
              ),
              appBar: AppBar(
                title: Text("Detail"),
                leading: IconButton(
                  icon: Icon(Icons.arrow_back_ios_new),
                  onPressed: () {
                    Navigator.of(context).pop();
                  },
                ),
                actions: [
                  IconButton(
                    icon: state is BookMarkLoaded && state.isBookmarked
                        ? Icon(Icons.bookmark,
                            color: Theme.of(context).colorScheme.primary)
                        : Icon(Icons.bookmark_border),
                    onPressed: () {
                      context.read<BookmarkCubit>().bookMarkMovie(movie);
                    },
                  ),
                ],
                centerTitle: true,
              ),
              body: SingleChildScrollView(
                controller: ScrollController(),
                child: Container(
                  child: Padding(
                    padding: const EdgeInsets.symmetric(horizontal: 16.0),
                    child: Column(
                      crossAxisAlignment: CrossAxisAlignment.start,
                      children: [
                        Container(
                          height: height * 0.55,
                          child: Stack(
                            children: [
                              Container(
                                height: height * 0.5,
                                decoration: BoxDecoration(
                                    image: DecorationImage(
                                      image: NetworkImage(movie.image),
                                      fit: BoxFit.cover,
                                    ),
                                    borderRadius: BorderRadius.circular(20)),
                              ),
                              Positioned(
                                child: Container(
                                  height: 70,
                                  width: 60,

                                  decoration: BoxDecoration(
                                    borderRadius: BorderRadius.circular(10),
                                    color: Theme.of(context)
                                        .colorScheme
                                        .onBackground,
                                    boxShadow: [
                                      BoxShadow(
                                        color: Colors.black26,
                                        blurRadius: 5.0,
                                        spreadRadius: 1.0,
                                        offset: Offset(2.0, 2.0),
                                      ),
                                    ],
                                  ),

                                  // color: Theme.of(context).colorScheme.onBackground,
                                  child: Column(
                                    mainAxisAlignment: MainAxisAlignment.center,
                                    children: [
                                      Icon(Icons.star,
                                          color: Colors.yellow, size: 35),
                                      Text(
                                        movie.rating.toString(),
                                        style: Theme.of(context)
                                            .textTheme
                                            .titleMedium!
                                            .copyWith(color: Colors.white),
                                      )
                                    ],
                                  ),
                                ),
                                right: 30,
                                bottom: 0,
                              )
                            ],
                          ),
                        ),
                        Text(
                          movie.title,
                          style:
                              Theme.of(context).textTheme.titleLarge!.copyWith(
                                    fontWeight: FontWeight.bold,
                                  ),
                        ),
                        SizedBox(height: 10),
                        Row(
                          children: [
                            Icon(
                              Icons.access_time,
                              color: Theme.of(context).colorScheme.primary,
                            ),
                            Text(
                              movie.duration + " | " + movie.category,
                              style: Theme.of(context)
                                  .textTheme
                                  .titleSmall!
                                  .copyWith(
                                      color: Colors.black54, fontSize: 16),
                            ),
                          ],
                        ),
                        SizedBox(height: 10),
                        Text(
                          movie.description,
                          style:
                              Theme.of(context).textTheme.bodyLarge!.copyWith(
                                    color: Colors.black54,
                                    fontWeight: FontWeight.w500,
                                  ),
                        ),
                      ],
                    ),
                  ),
                ),
              ));
        },
      ),
    );
  }
}
