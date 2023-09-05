import 'package:flutter/material.dart';

class DetailPage extends StatelessWidget {
  const DetailPage({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        leading: IconButton(
            onPressed: () {
              Navigator.pop(context);
            },
            icon: const Icon(
              Icons.arrow_back_rounded,
              size: 40,
            )),
        title: Text("Detail"),
        actions: [
          Padding(
            padding: const EdgeInsets.fromLTRB(0, 0, 10, 0),
            child: const Icon(
              Icons.bookmark_outline_sharp,
              size: 35,
            ),
          ),
        ],
        centerTitle: true,
      ),
      body: SingleChildScrollView(
          child: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          Container(
            height: 380,
            width: 400,
            margin: EdgeInsets.symmetric(horizontal: 10, vertical: 20),
            decoration: BoxDecoration(
                image: DecorationImage(
                  image: AssetImage(
                      'assets/images/download.jpg'), // Replace with your image path
                  fit: BoxFit.cover,
                ),
                borderRadius: BorderRadius.all(Radius.circular(20))),
          ),
          SizedBox(
            height: 20,
          ),
          const Padding(
            padding: EdgeInsets.symmetric(horizontal: 20),
            child: Text(
              "A Man Called Otto",
              style: TextStyle(fontSize: 25, fontWeight: FontWeight.bold),
            ),
          ),
          const Padding(
            padding: EdgeInsets.symmetric(horizontal: 20),
            child: Row(
              children: [
                Icon(Icons.watch_later_outlined),
                Text("1 hour | "),
                Text("Comedy & Drama")
              ],
            ),
          ),
          const Padding(
            padding: EdgeInsets.symmetric(horizontal: 20),
            child: Expanded(
              child: Text(
                "fd;akflfllfklc",
              ),
            ),
          ),
          SizedBox(
            height: 20,
          ),
          Padding(
            padding: const EdgeInsets.symmetric(horizontal: 25, vertical: 20),
            child: ElevatedButton(
              onPressed: () {},
              child: const Text(
                "Watch Now",
                style: TextStyle(
                  color: Colors.white,
                  fontSize: 20,
                  fontWeight: FontWeight.bold,
                ),
              ),
              style: ElevatedButton.styleFrom(
                backgroundColor: Colors.blue,
                shape: RoundedRectangleBorder(
                  borderRadius: BorderRadius.circular(
                      10), // Adjust the value to control the roundness
                ),
                minimumSize: Size(300,
                    50), // Adjust the width and height to make the button larger
              ),
            ),
          ),
        ],
      )),
    );
  }
}
