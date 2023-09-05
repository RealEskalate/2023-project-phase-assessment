import 'package:flutter/material.dart';

class CustomizeMovieWidget extends StatelessWidget {
  final String title, distribution, image;
  final int rate;
  const CustomizeMovieWidget(
      {super.key,
      required this.title,
      required this.rate,
      required this.distribution,
      required this.image});

  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: const EdgeInsets.symmetric(vertical: 10, horizontal: 20),
      child: Container(
        decoration: BoxDecoration(
          color: Colors.white,
          borderRadius: BorderRadius.all(
            Radius.circular(20),
          ),
        ),
        child: Row(
          children: [
            ClipRRect(
              borderRadius: BorderRadius.all(
                Radius.circular(15),
              ),
              child: Image(
                image: AssetImage(image),
                fit: BoxFit.cover,
                height: 80,
                width: 60,
              ),
            ),
            SizedBox(
              width: 50,
            ),
            Column(
              children: [
                Text("$title"),
                Row(
                  children: [
                    Row(
                      children: [
                        Icon(
                          Icons.star,
                        ),
                        Text(
                          "$rate",
                        ),
                      ],
                    ),
                    Row(
                      children: [
                        Icon(
                          Icons.timer_3_rounded,
                        ),
                        Text(distribution),
                      ],
                    ),
                  ],
                ),
              ],
            ),
          ],
        ),
      ),
    );
  }
}
