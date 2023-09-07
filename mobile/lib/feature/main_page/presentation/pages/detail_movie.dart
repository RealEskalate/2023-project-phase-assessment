import 'package:flutter/material.dart';

class DetailMovie extends StatelessWidget {
  const DetailMovie({
    super.key,
  });

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Center(child: Text("Detail")),
        backgroundColor: Color.fromRGBO(213, 230, 249, 1),
      ),
      body: Column(
        children: [
          Expanded(
            flex: 60,
            child: Padding(
              padding: const EdgeInsets.all(0.0),
              child: Stack(
                
                children: [
                  Image(
                    image: AssetImage("asset/12.jpg"),
                    fit: BoxFit.cover,
                  ),
                  Positioned(
                    bottom: 1,
                    right: 2,
                    child: Container(
                      padding: EdgeInsets.all(10),
                      decoration: BoxDecoration(
                        color: Colors.black87,
                        borderRadius: BorderRadius.all(
                          Radius.circular(10),
                        ),
                      ),
                      child: Column(
                        mainAxisSize: MainAxisSize.min,
                        children: [
                          Icon(
                            Icons.star,
                            color: Colors.amber,
                          ),
                          Text(
                            "7.5",
                            style: TextStyle(color: Colors.white),
                          ),
                        ],
                      ),
                    ),
                  ),
                ],
              ),
            ),
          ),
          Expanded(
              flex: 40,
              child: Container(
                color: Colors.amber,
              ))
        ],
      ),
    );
  }
}
