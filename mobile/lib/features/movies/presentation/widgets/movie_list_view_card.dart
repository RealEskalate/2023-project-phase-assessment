import 'package:flutter/material.dart';
import 'package:mobile/features/movies/domain/entities/movie.dart';
import 'package:mobile/features/movies/presentation/screens/detail_screen.dart';
// verticl view of card
class MovieListView extends StatelessWidget {
  List<Movie> movie;
  MovieListView({super.key, required this.movie});

  @override
  Widget build(BuildContext context) {
    double height = MediaQuery.of(context).size.height;
    return Container(
      height: height * 0.8,
      padding: EdgeInsets.symmetric(horizontal: 10),
      child: ListView.builder(

        itemCount: movie.length,
        itemBuilder: (context, index) {
          return Column(
            children: [
              MovieListViewCard(movie: movie[index]),
              SizedBox(height: 10),
            ],
          );
        },
      ),
    );
  }
}
class MovieListViewCard extends StatelessWidget {
  Movie movie;
  MovieListViewCard({super.key, required this.movie});

  @override
  Widget build(BuildContext context) {
    double width = MediaQuery.of(context).size.width;
    return GestureDetector(
      onTap: (){
        Navigator.of(context).push(MaterialPageRoute(builder: (context) => DetailScreen(movie: movie)));
      },
      child: Container(
        
        padding: EdgeInsets.all(8.0),
        decoration: BoxDecoration(borderRadius: BorderRadius.circular(20), color: Colors.white),
        child: Row(
          children: [
            Container(
              width: width/ 2.2,
              height: 110,
              decoration: BoxDecoration(
                  image: DecorationImage(
                    image: NetworkImage(movie.image),
                    fit: BoxFit.cover,
                  ),
                  borderRadius: BorderRadius.circular(20)),
            ),
            const SizedBox(
              width: 10,
            ),
            Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                Container(
                  width: 150,
                  child: Row(
                    children: [
                      Expanded(
                        child: Text(
                          movie.title,
                          style: Theme.of(context).textTheme.titleMedium!.copyWith(
                                fontWeight: FontWeight.bold,
                              ),
                              maxLines: 2,
                              overflow: TextOverflow.ellipsis,
                        ),
                      ),
                    ],
                  ),
                ),
                const SizedBox(height: 10),
                Row(
                  children: [
                    Row(
                      children: [
                        const Icon(Icons.star, color: Colors.yellow),
                        Text(
                          movie.rating.toString(),
                          style: Theme.of(context).textTheme.labelLarge!.copyWith(
                                color: Colors.black54,
                              ),
                        ),
                      ],
                    ),
                    const SizedBox(width: 20),
                    Row(children: [
                      Icon(Icons.access_time,
                          color: Theme.of(context).colorScheme.primary),
                      Text(
                        movie.duration,
                        style: Theme.of(context).textTheme.labelLarge!.copyWith(
                              color: Colors.black54,
                            ),
                      )
                    ])
                  ],
                )
              ],
            )
          ],
        ),
      ),
    );
  }
}
