import 'package:flutter/material.dart';
import 'package:mobile/features/example/domain/entities/movie.dart';
import 'package:mobile/features/example/presentation/screens/detail.dart';

class MovieWidget extends StatelessWidget {
  MovieWidget(
      {super.key,
      this.movie});
  final Movie? movie;
 
  @override
  Widget build(BuildContext context) {
    return GestureDetector(
      onTap: () {
        Navigator.push(
            context,
            MaterialPageRoute(
                builder: (_) => Detail( movie : movie
                    )));
      },
      child: Hero(
        tag: movie!.image ?? "",
        child: Container(
          padding: EdgeInsets.only(left: 10, top: 5, bottom: 5),
          margin: EdgeInsets.only(left: 10, right: 10, top: 5, bottom: 5),
          decoration: BoxDecoration(
              color: Colors.white,
              borderRadius: BorderRadius.all(Radius.circular(10))),
          child: Row(
            children: [
              ClipRRect(
                borderRadius: BorderRadius.all(Radius.circular(10)),
                child: Image.network(
                  movie!.image ?? "",
                  width: 120,
                  height: 100,
                  fit: BoxFit.cover,
                ),
              ),
              SizedBox(width: 20),
              Column(
                crossAxisAlignment: CrossAxisAlignment.center,
                children: [
                  Text(movie!.title.toString(), style: TextStyle(fontSize: 18)),
                  SizedBox(height: 10),
                  Row(
                    mainAxisAlignment: MainAxisAlignment.center,
                    children: [
                      Icon(
                        Icons.star,
                        color: Colors.yellow,
                      ),
                      SizedBox(width: 5),
                      Text(movie!.rating.toString()),
                      SizedBox(width: 15),
                      Icon(
                        Icons.access_time,
                        color: Colors.blue,
                      ),
                      SizedBox(width: 5),
                      Text(movie!.duration.toString())
                    ],
                  )
                ],
              )
            ],
          ),
        ),
      ),
    );
    ;
  }
}
