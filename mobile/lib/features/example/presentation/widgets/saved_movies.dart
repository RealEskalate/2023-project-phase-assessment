import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:mobile/features/example/domain/entities/movie.dart';
import 'package:mobile/features/example/presentation/bloc/movie_bloc.dart';
import 'package:mobile/features/example/presentation/screens/detail.dart';

class SavedMovies extends StatelessWidget {
  const SavedMovies({super.key});

  @override
  Widget build(BuildContext context) {
    return BlocBuilder<MovieBloc, MovieState>(
      builder: (context, state) {
        return Container(
          height: 350,
          width: double.infinity,
          padding: EdgeInsets.all(10),
          child: state is MovieLoaded
              ? ListView.separated(
                  separatorBuilder: (_, __) => SizedBox(width: 10),
                  scrollDirection: Axis.horizontal,
                  itemCount: state.bookmarks.length,
                  itemBuilder: (context, index) {
                    return Box(
                        state.bookmarks[state.bookmarks.length - index - 1],
                        context);
                  },
                )
              : Text(""),
        );
      },
    );
  }

  Widget Box(Movie movie, context) {
    return GestureDetector(
      onTap: () => {
        Navigator.push(
            context,
            MaterialPageRoute(
                builder: (_) => Detail(
                      movie: movie,
                    )))
      },
      child: Container(
        // margin: EdgeInsets.symmetric(horizontal: 10),
        width: 300,
        decoration: BoxDecoration(
          borderRadius: BorderRadius.all(Radius.circular(20)),
        ),
        child: Stack(
          children: [
            ClipRRect(
              borderRadius: BorderRadius.all(Radius.circular(20)),
              child: Image.network(
                movie.image!,
                width: 300,
                height: 340,
                fit: BoxFit.cover,
              ),
            ),
            Positioned(
              left: 50,
              right: 50,
              bottom: 15,
              child: Container(
                width: 200,
                height: 70,
                decoration: BoxDecoration(
                    color: const Color.fromARGB(255, 255, 255, 255),
                    borderRadius: BorderRadius.all(Radius.circular(20))),
                child: Column(
                  mainAxisAlignment: MainAxisAlignment.center,
                  crossAxisAlignment: CrossAxisAlignment.center,
                  children: [
                    Text(movie!.category.toString(),
                        style: TextStyle(fontSize: 16)),
                    SizedBox(height: 5),
                    Row(
                      mainAxisAlignment: MainAxisAlignment.center,
                      children: [
                        Icon(
                          Icons.star,
                          color: Colors.yellow,
                        ),
                        SizedBox(width: 5),
                        Text(movie.rating.toString()),
                        SizedBox(width: 15),
                        Icon(
                          Icons.access_time,
                          color: Colors.blue,
                        ),
                        SizedBox(width: 5),
                        Text(movie.duration.toString())
                      ],
                    )
                  ],
                ),
              ),
            )
          ],
        ),
      ),
    );
  }
}
