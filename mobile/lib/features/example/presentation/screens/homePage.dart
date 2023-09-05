// ignore_for_file: public_member_api_docs, sort_constructors_first
import 'package:flutter/material.dart';
import 'package:mobile/features/example/presentation/widgets/savedMovies.dart';

class Home extends StatefulWidget {
  const Home({super.key});

  @override
  State<Home> createState() => _HomeState();
}

class _HomeState extends State<Home> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Center(
          child: Text(
            'Alem Cinema',
            style: TextStyle(fontFamily: 'Poppins-SemiBold'),
          ),
        ),
      ),
      body: SingleChildScrollView(
        child: Column(
          children: [
            Container(
              margin:
                  const EdgeInsets.only(top: 0, right: 20, left: 20, bottom: 0),
              height: 50,
              decoration: BoxDecoration(
                color: Colors.white,
                borderRadius: BorderRadius.circular(12),
              ),
              child: Row(
                children: [
                  Expanded(
                    child: TextField(
                      decoration: InputDecoration(
                        hintText: "  Looking for shows",
                        hintStyle: TextStyle(
                          fontFamily: 'Poppins-ExtraLight',
                          color: Colors.grey.shade400,
                          fontSize: 15,
                        ),
                        contentPadding: const EdgeInsets.only(
                            left: 10, top: 12, bottom: 12), // Add padding here
                        border: InputBorder.none,
                      ),
                    ),
                  ),
                  Container(
                    width: 50,
                    height: 100,
                    decoration: BoxDecoration(
                      color: const Color(0xff376AED),
                      borderRadius: BorderRadius.circular(12),
                    ),
                    child: IconButton(
                      icon: const Icon(
                        Icons.search,
                        size: 32,
                      ),
                      color: Colors.white,
                      onPressed: () {
                        // Navigator.push(
                        //   context,
                        //   MaterialPageRoute(
                        //     builder: (context) => const SearchResult(
                        //       keyword: '',
                        //     ),
                        //   ),
                        // );
                      },
                    ),
                  ),
                  const Padding(padding: EdgeInsets.only(bottom: 7))
                ],
              ),
            ),
            const SizedBox(
              height: 20,
            ),
            Container(
              height: 70,
              decoration: BoxDecoration(color: Colors.white),
              child: const Row(
                children: [
                  SizedBox(
                    width: 10,
                  ),
                  Text(
                    'Saved Movies',
                    style: TextStyle(
                      fontFamily: 'Urbanist-Regular',
                      fontSize: 24,
                    ),
                  ),
                  Icon(
                    Icons.bookmark_outline,
                    color: Color(0xff376AED),
                    size: 35,
                  ),
                ],
              ),
            ),

            //Saved Movies Slider
            SizedBox(
              height: MediaQuery.of(context).size.height * 0.3,
              child: ListView.builder(
                scrollDirection: Axis.horizontal,
                itemCount: 3,
                itemBuilder: (context, index) {
                  return Container(
                    width: MediaQuery.of(context).size.width * 0.5,
                    height: MediaQuery.of(context).size.height * 0.3,
                    margin: const EdgeInsets.symmetric(horizontal: 8.0),
                    decoration: BoxDecoration(
                      color: Colors.blue,
                      borderRadius: BorderRadius.circular(15),
                    ),
                    child: InkWell(
                      onTap: () {
                        Navigator.pushNamed(context, '/Detail');
                      },
                      child: Stack(
                        children: [
                          ClipRRect(
                            borderRadius: BorderRadius.circular(15),
                            child: Image.asset(
                              'assets/images/onboarding.jpg',
                              fit: BoxFit.cover,
                              width: double.infinity,
                              height: double.infinity,
                            ),
                          ),
                          Positioned(
                            top: 165,
                            left: 10,
                            child: Container(
                              width: MediaQuery.of(context).size.width * 0.43,
                              height: MediaQuery.of(context).size.height * 0.09,
                              decoration: BoxDecoration(
                                color: Colors.white,
                                borderRadius: BorderRadius.circular(12),
                              ),
                              child: const Column(
                                children: [
                                  SizedBox(
                                    height: 10,
                                  ),
                                  Text(
                                    'Autobiography',
                                    style: TextStyle(
                                      fontFamily: 'Urbanist-Regular',
                                      fontSize: 17,
                                    ),
                                  ),
                                  Row(
                                    children: [
                                      SizedBox(width: 10),
                                      Icon(
                                        Icons.star,
                                        color: Colors.yellow,
                                      ),
                                      SizedBox(width: 5),
                                      Text(
                                        '4.5',
                                        style: TextStyle(
                                            fontFamily: 'Urbanist-Light'),
                                      ),
                                      SizedBox(width: 30),
                                      Icon(
                                        Icons.access_time,
                                        color: Color(0xff376AED),
                                      ),
                                      SizedBox(width: 5),
                                      Text(
                                        '1 hour',
                                        style: TextStyle(
                                            fontFamily: 'Urbanist-Light'),
                                      )
                                    ],
                                  )
                                ],
                              ),
                            ),
                          ),
                        ],
                      ),
                    ),
                  );
                },
              ),
            ),

            const Padding(
              padding: EdgeInsets.fromLTRB(10, 5, 270, 0),
              child: Text(
                'All Movies',
                style: TextStyle(
                  fontFamily: 'Poppins-SemiBold',
                  color: Color(0xFF1A2558),
                  fontSize: 20,
                ),
              ),
            ),
            Container(
              height: MediaQuery.of(context).size.height * 0.39,
              width: MediaQuery.of(context).size.width * 0.94,
              child: ListView.builder(
                itemCount: 5,
                itemBuilder: (context, index) {
                  return ConstrainedBox(
                    constraints: BoxConstraints(
                      maxWidth: MediaQuery.of(context).size.width * 0.8,
                    ),
                    child: CustomCard(
                      title: 'The Enchanted Quest',
                      rating: '4.5',
                      image: 'assets/images/onboarding.jpg',
                      time: '1 hour',
                    ),
                  );
                },
              ),
            ),
          ],
        ),
      ),
    );
  }
}

class CustomCard extends StatelessWidget {
  String title;
  String rating;
  String image;
  String time;
  CustomCard({
    Key? key,
    required this.title,
    required this.rating,
    required this.image,
    required this.time,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return InkWell(
      onTap: () {
        Navigator.pushNamed(context, '/Detail');
      },
      child: SizedBox(
        height: 120,
        // width: MediaQuery.of(context).size.width * 0.8,
        child: Card(
          color: Colors.white,
          child: Row(
            children: [
              SizedBox(width: 10),
              Container(
                height: 90,
                width: 100,
                decoration: BoxDecoration(
                  color: Color(0XFFF0F0FB),
                  borderRadius: BorderRadius.circular(10),
                ),
                child: ClipRRect(
                  borderRadius: BorderRadius.circular(15),
                  child: Image.asset(
                    image, // << image of the movie goes here
                    fit: BoxFit.cover,
                    width: double.infinity,
                    height: double.infinity,
                  ),
                ),
              ),
              SizedBox(width: 10),
              Container(
                padding: EdgeInsets.only(top: 15),
                child: Column(
                  crossAxisAlignment: CrossAxisAlignment.start,
                  children: [
                    Text(
                      title, // Title of the movie goes here
                      style: TextStyle(
                          fontSize: 18,
                          fontWeight: FontWeight.bold,
                          color: Colors.black),
                    ),
                    SizedBox(
                      height: 10,
                    ),
                    Row(
                      children: [
                        Icon(
                          Icons.star,
                          color: Colors.yellow,
                        ),
                        SizedBox(width: 5),
                        Text(
                          rating, // <<< rating of the movie goes here
                          style: TextStyle(fontFamily: 'Urbanist-Light'),
                        ),
                        SizedBox(width: 30),
                        Icon(
                          Icons.access_time,
                          color: Color(0xff376AED),
                        ),
                        SizedBox(width: 5),
                        Text(
                          time, // << Total time of the movie goes here
                          style: TextStyle(fontFamily: 'Urbanist-Light'),
                        )
                      ],
                    )
                  ],
                ),
              ),
            ],
          ),
        ),
      ),
    );
  }
}
