import 'package:flutter/material.dart';

class SavedMovieWidget extends StatelessWidget {
  final String catagory, distribution, image;
  final int rate;
  const SavedMovieWidget({
    super.key,
    required this.catagory,
    required this.distribution,
    required this.rate,
    required this.image,
  });

  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: const EdgeInsets.all(10.0),
      child: Stack(
          children: [
            ClipRRect(
              borderRadius: BorderRadius.all(Radius.circular(15),),
              child: Image(
                  image: AssetImage(image),
                  fit: BoxFit.cover,
                  height: 200,
                  width: 140,
                ),
            ),
            Positioned(
              top: 150,
              left: 20,
              child: Container(
                height: 40,
                width: 100,
                decoration: BoxDecoration(
                  color: Colors.white,
                  borderRadius: BorderRadius.all(
                    Radius.circular(10),
                  ),
                ),
                child: Column(
                  mainAxisAlignment: MainAxisAlignment.spaceBetween,
                  children: [
                    Text(catagory),
                    Row(
                      mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                      children: [
                        Row(children: [
                          Icon(
                            Icons.star,
                          ),
                          Text(
                            "$rate",
                          ),
                        ]),
                        Row(
                          children: [
                            Icon(
                              Icons.timer_3_rounded,
                            ),
                            Text(distribution),
                          ],
                        )
                      ],
                    ),
                  ],
                ),
              ),
            ),
          ],
      ),
    );
  }
}
