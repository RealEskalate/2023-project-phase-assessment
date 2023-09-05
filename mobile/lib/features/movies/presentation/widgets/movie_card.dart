import 'package:flutter/material.dart';
import 'package:mobile/features/movies/domain/entities/movie.dart';
import 'package:mobile/features/movies/presentation/screens/detail_screen.dart';

// horizontall scrollable Movie List
class MovieList extends StatelessWidget {
  List<Movie> movies;
  MovieList({super.key, required this.movies});


  @override
  Widget build(BuildContext context) {
    double height = MediaQuery.of(context).size.height;
    return Container(
      height: height* 0.43,
      child: ListView.builder(
        scrollDirection: Axis.horizontal,
        itemCount: movies.length,
        itemBuilder: (context, index) {
          return Padding(
            padding: const EdgeInsets.all(8.0),
            child: MovieCard(movie: movies[index]),
          );
        },
      ),
    );
  }
}
class MovieCard extends StatelessWidget {
  Movie movie;
  MovieCard({super.key, required this.movie});

  @override
  Widget build(BuildContext context) {
    return GestureDetector(
      onTap: (){
        Navigator.of(context).push(MaterialPageRoute(builder: (context) => DetailScreen(movie: movie)));
      },
      child: Container(
        width: 250,
        height: 400,
        padding: EdgeInsets.fromLTRB(0, 0, 0, 6),
        alignment: Alignment.bottomCenter,
        decoration: BoxDecoration(image: DecorationImage(image: NetworkImage(movie.image), fit: BoxFit.cover), borderRadius:  BorderRadius.circular(20)),child: CardTextSection(movie: movie)),
    );
  }
}

class CardTextSection extends StatelessWidget {
  const CardTextSection({
    super.key,
    required this.movie,
  });

  final Movie movie;

  @override
  Widget build(BuildContext context) {
    return Card(
       color: Colors.white,
       surfaceTintColor: Colors.white,
      child: Container(
       
        width: 220,
        height: 96,
        child: Padding(
          padding: const EdgeInsets.all(12.0),
          child: Column(
            
          crossAxisAlignment: CrossAxisAlignment.start,
          mainAxisAlignment: MainAxisAlignment.center,
          children: [
            Text(movie.title, style: Theme.of(context).textTheme.titleLarge!.copyWith(
              fontWeight: FontWeight.w700,
              fontSize: 20,
            ),),
            SizedBox(height: 10),
            Row(children: [
              Row(children: [
                Icon(Icons.star, color: Colors.yellow),
                Text(movie.rating.toString(), style: Theme.of(context).textTheme.labelLarge!.copyWith(
                  color: Colors.black54,
                ),),
              ]
                
              ,),
              SizedBox(width: 20),
              Row(children: [
                Icon(Icons.access_time, color: Theme.of(context).colorScheme.primary),
                Text(movie.duration, style: Theme.of(context).textTheme.labelLarge!.copyWith(
                  color: Colors.black54,
                ),)
              ])
            ],)
          ],),
        ),
      ),
    );
  }
}