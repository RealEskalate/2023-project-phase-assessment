import 'package:flutter/material.dart';

class DetailPage extends StatefulWidget {
  const DetailPage({super.key});

  @override
  State<DetailPage> createState() => _DetailPageState();
}

class _DetailPageState extends State<DetailPage> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        leading: IconButton(
          onPressed: () {
            Navigator.pop(context);
          },
          icon: Icon(Icons.arrow_back_ios),
        ),
        title: const Center(
          child: Text(
            'Detail',
            style: TextStyle(fontFamily: 'Poppins-SemiBold'),
          ),
        ),
        actions: [
          const Icon(
            Icons.bookmark_outline,
            color: Color(0xff376AED),
            size: 35,
          ),
        ],
      ),
      body: Column(
        children: [
          SizedBox(
            height: MediaQuery.of(context).size.height * 0.57,
            child: Stack(
              children: [
                Center(
                  child: Container(
                    width: MediaQuery.of(context).size.width * 0.9,
                    height: MediaQuery.of(context).size.height * 0.48,
                    decoration: BoxDecoration(
                      color: Color(0XFFF0F0FB),
                      borderRadius: BorderRadius.circular(10),
                    ),
                    child: ClipRRect(
                      borderRadius: BorderRadius.circular(15),
                      child: Image.asset(
                        'assets/images/onboarding.jpg',
                        fit: BoxFit.cover,
                        width: double.infinity,
                        height: double.infinity,
                      ),
                    ),
                  ),
                ),
                Positioned(
                  top: 400,
                  left: 300,
                  child: Container(
                    width: 60,
                    height: 70,
                    decoration: BoxDecoration(
                      color: Colors.black,
                      borderRadius: BorderRadius.circular(10),
                    ),
                    child: const Column(
                      children: [
                        SizedBox(height: 10),
                        Icon(
                          Icons.star,
                          color: Colors.yellow,
                          size: 32,
                        ),
                        SizedBox(width: 5),
                        Text(
                          '4.5',
                          style: TextStyle(
                            fontFamily: 'Urbanist-Light',
                            color: Colors.white,
                          ),
                        ),
                      ],
                    ),
                  ),
                )
              ],
            ),
          ),
          const Padding(
            padding: EdgeInsets.fromLTRB(10, 5, 180, 0),
            child: Text(
              'A Man Called otto',
              style: TextStyle(
                fontFamily: 'Poppins-SemiBold',
                color: Color(0xFF1A2558),
                fontSize: 20,
              ),
            ),
          ),
          Row(
            children: [
              const SizedBox(
                width: 15,
              ),
              Icon(
                Icons.access_time,
                color: Color(0xff376AED),
              ),
              Text(
                '1 hour',
                style: TextStyle(fontFamily: 'Urbanist-Light'),
              ),
              const SizedBox(
                width: 5,
              ),
              Text(
                '| Comedy & Drama',
                style: TextStyle(fontFamily: 'Urbanist-Light'),
              )
            ],
          ),
          Padding(
            padding: EdgeInsets.fromLTRB(25, 10, 25, 10),
            child: Text(
              'Otto(Tom Hanks) is a man who is easily angry after losing his wife. The situation begins to  change when the young faimly moves into proximity',
              style: TextStyle(
                fontFamily: 'Urbanist-Regular',
                fontSize: 16,
              ),
            ),
          ),
          Container(
            padding: const EdgeInsets.only(bottom: 10),
            color: Colors.white,
            width: MediaQuery.of(context).size.width,
            child: Container(
              padding: const EdgeInsets.only(left: 50, right: 50),
              height: 60,
              width: 150,
              child: ElevatedButton(
                onPressed: () {
                  Navigator.pushReplacementNamed(context, '/Home');
                },
                style: ElevatedButton.styleFrom(
                    shape: RoundedRectangleBorder(
                        borderRadius: BorderRadius.circular(10)),
                    backgroundColor: const Color(0xFF376AED)),
                child: const Text(
                  'Watch Now',
                  style: TextStyle(
                      fontSize: 18,
                      color: Colors.white,
                      fontFamily: 'Poppins-SemiBold'),
                ),
              ),
            ),
          )
        ],
      ),
    );
  }
}
