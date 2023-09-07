import 'package:flutter/material.dart';

class CustomizeMovieWidget extends StatelessWidget {
  const CustomizeMovieWidget({super.key});

  @override
  Widget build(BuildContext context) {
    return Container(
      width: 200,
      decoration: BoxDecoration(
        image: DecorationImage(
          image: AssetImage("asset/12.jpg"),
          fit: BoxFit.cover,
        ),
        borderRadius: BorderRadius.all(
          Radius.circular(20),
        ),
      ),
      child: Align(
        alignment: Alignment.bottomCenter,
        child: FractionalTranslation(
          translation: Offset(0, -0.1),
          child: Container(
            padding: const EdgeInsets.all(8.0),
            decoration: BoxDecoration(
              color: Colors.white,
              borderRadius: BorderRadius.all(Radius.circular(15)),
            ),
            child: Column(
              mainAxisSize: MainAxisSize.min,
              children: [
                Text("Autobiography"),
                Row(
                  mainAxisSize: MainAxisSize.min,
                  children: [
                    Row(
                      children: [
                        Icon(
                          Icons.access_alarm_rounded,
                        ),
                        Text("1 Hour"),
                      ],
                    ),
                    SizedBox(width: 10,),
                    Row(
                      children: [
                        Icon(
                          Icons.star,
                          color: Colors.amber,
                        ),
                        Text("7.5"),
                      ],
                    ),
                  ],
                ),
              ],
            ),
          ),
        ),
      ),
    );
  }
}
