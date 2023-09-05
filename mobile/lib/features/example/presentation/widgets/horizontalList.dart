// Container for the image
import 'package:flutter/material.dart';
import 'package:mobile/core/utils/human_readable_time.dart';
import 'package:mobile/features/example/data/models/film_models.dart';
import 'package:mobile/features/example/presentation/screens/detailpage.dart';

class Horizontal extends StatelessWidget {
  final Movie object;
  final int index;

  const Horizontal({
    Key? key,
    required this.index,
    required this.object,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    // double screenHeight = MediaQuery.of(context).size.height;
    return Padding(
      padding: const EdgeInsets.only(
          bottom: 10, left: 10, right: 10), // Adjust the padding as needed
      child: InkWell(
        onTap: () {
          //navigate to ViewBlog() without named
          Navigator.push(
            context,
            MaterialPageRoute(
              builder: (context) => MovieDetail(movie: object),
            ),
          );
        },
        child: Container(
          decoration: BoxDecoration(
            // Background color
            borderRadius: BorderRadius.circular(50), // Circular border radius
          ),
          width: 220, // Adjust as needed
          child: Stack(
            children: [
              // Image
              Image.network(
                object.image,
                fit: BoxFit.cover,
                width: double.infinity,
                height: double.infinity,
              ),
              // Overlay for info
              Positioned(
                bottom: 16,
                left: 16,
                right: 16,
                child: Container(
                  padding: EdgeInsets.all(16),
                  color: const Color.fromARGB(255, 255, 255, 255)
                      .withOpacity(0.6), // Adjust opacity as needed
                  child: Column(
                    crossAxisAlignment: CrossAxisAlignment.start,
                    children: [
                      // Amount of likes using icon and number

                      // Title
                      Text(
                        object.title,
                        style: TextStyle(
                          color: const Color.fromARGB(255, 0, 0, 0),
                          fontSize: 12,
                          fontWeight: FontWeight.bold,
                        ),
                      ),
                      // SizedBox(height: 8),
                      // Release date
                      Text(
                        formatDateTimeDifference(object.createdAt),
                        style: TextStyle(color: Color.fromARGB(255, 0, 0, 0)),
                      ),

                      Row(
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
                    ],
                  ),
                ),
              ),
            ],
          ),
        ),
      ),
    );
  }
}
