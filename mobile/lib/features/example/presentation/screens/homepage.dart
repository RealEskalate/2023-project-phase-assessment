import 'dart:async';

import 'package:flutter/material.dart';
import 'package:mobile/features/example/data/datasources/remote_data_source.dart';
import 'package:mobile/features/example/data/models/film_models.dart';
import 'package:mobile/features/example/domain/usecases/getmovies.dart';
import 'package:mobile/features/example/presentation/bloc/movie_bloc.dart';
import 'package:mobile/features/example/presentation/bloc/movie_event.dart';
import 'package:mobile/features/example/presentation/widgets/header.dart';
import 'package:mobile/features/example/presentation/widgets/horizontalList.dart';
import 'package:mobile/features/example/presentation/widgets/search_result.dart';
import 'package:mobile/features/example/presentation/widgets/tips_card.dart';
//import

List<Movie> sampleMovies = [
  Movie(
      id: '1',
      category: 'Action',
      title: 'The Lost Treasure',
      description:
          'A group of adventurers embarks on a quest to find a long-lost treasure hidden deep in a mysterious jungle.',
      duration: '2h 15m',
      image:
          'https://fastly.picsum.photos/id/1/200/300.jpg?hmac=jH5bDkLr6Tgy3oAg5khKCHeunZMHq0ehBZr6vGifPLY',
      rating: 7.8,
      createdAt: DateTime.now()),
  Movie(
    id: '2',
    category: 'Fantasy',
    title: 'The Enchanted Quest',
    description:
        'Join a young wizard and their friends on a magical journey to save their realm from darkness.',
    duration: '2h 20m',
    image:
        'https://fastly.picsum.photos/id/14/2500/1667.jpg?hmac=ssQyTcZRRumHXVbQAVlXTx-MGBxm6NHWD3SryQ48G-o',
    rating: 7.3,
    createdAt: DateTime.now(),
  ),
  Movie(
    id: '3',
    category: 'Fantasy',
    title: 'The Quest for the Crystal',
    description:
        'Join a group of heroes on a perilous journey to find a legendary crystal with unimaginable power.',
    duration: '2h 25m',
    image:
        'https://fastly.picsum.photos/id/30/1280/901.jpg?hmac=A_hpFyEavMBB7Dsmmp53kPXKmatwM05MUDatlWSgATE',
    rating: 7.6,
    createdAt: DateTime.now(),
  ),
  // Add more sample movies as needed
];

class Homepage extends StatefulWidget {
  const Homepage({super.key});

  @override
  State<Homepage> createState() => _HomepageState();
}

class _HomepageState extends State<Homepage> {
  MovieBloc movieBloc = MovieBloc(
      fetchMoviesUseCase: FetchMoviesUseCase(
          dataSource: UserApiDataSource(baseUrl: 'YOUR_BASE_URL')));

  @override
  void initState() {
    super.initState();
    movieBloc.add(FetchMoviesEvent());
  }

  List<String> tags = ["Movies", "Series", "Kids", "Documentaries"];

  int _currentPage = 0;
  String fullName = '';
  final TextEditingController _searchController = TextEditingController();
  final StreamController<String> _searchStreamController =
      StreamController<String>();

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Container(
        decoration: const BoxDecoration(
          color: Color(0xffF8FAFF),
        ),
        child: Column(
          children: [
            Padding(
              padding: const EdgeInsets.only(top: 20.0),
              child: CustomHeader(name: "Hi Mehari Tesfaye"),
            ),
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
                      controller: _searchController,
                      onChanged: (value) {
                        _searchStreamController.add(value);
                      },
                      decoration: InputDecoration(
                        hintText: "Search an article...",
                        hintStyle: TextStyle(
                          fontFamily: 'Poppins-ExtraLight',
                          color: Colors.grey.shade400,
                          fontSize: 15,
                        ),
                        contentPadding: const EdgeInsets.only(
                            left: 10, top: 12, bottom: 12), // Add padding here
                        border: InputBorder.none,
                        suffixIcon: Container(
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
                              Navigator.push(
                                context,
                                MaterialPageRoute(
                                  builder: (context) => const SearchResult(
                                    keyword: '',
                                  ),
                                ),
                              );
                            },
                          ),
                        ),
                      ),
                    ),
                  ),
                ],
              ),
            ),
            Padding(
              padding: const EdgeInsets.only(top: 8.0),
              child: Container(
                height: 70,
                margin: const EdgeInsets.symmetric(horizontal: 0),
                child: ListView.builder(
                  scrollDirection: Axis.horizontal,
                  itemCount: tags.length,
                  itemBuilder: (ctx, index) {
                    return Container(
                      constraints:
                          const BoxConstraints(minWidth: 70, minHeight: 50),
                      margin: const EdgeInsets.symmetric(
                          horizontal: 5, vertical: 18.5),
                      decoration: BoxDecoration(
                        color: _currentPage == index
                            ? const Color(0xff376AED)
                            : null,
                        borderRadius: BorderRadius.circular(20),
                        border: _currentPage == index
                            ? null
                            : Border.all(
                                color: const Color(0xff376AED), width: 2),
                      ),
                      child: TextButton(
                        onPressed: () {
                          if (mounted) {
                            setState(() {
                              _currentPage = index;
                            });
                          }
                        },
                        child: Padding(
                          padding: const EdgeInsets.only(left: 3, right: 3),
                          child: Text(
                            tags[index],
                            style: TextStyle(
                              color: _currentPage == index
                                  ? Colors.white
                                  : const Color(0xff376AED),
                              fontSize: 11.5,
                              fontFamily: 'Poppins-Regular',
                            ),
                          ),
                        ),
                      ),
                    );
                  },
                ),
              ),
            ),
            Expanded(
              child: ListView.builder(
                scrollDirection: Axis.horizontal,
                itemCount: sampleMovies.length,
                itemBuilder: (context, index) {
                  return Horizontal(index: index, object: sampleMovies[index]);
                },
              ),
            ),
            Padding(
              padding: const EdgeInsets.only(
                  left: 20.0, right: 20, top: 20, bottom: 8),
              child: Row(
                mainAxisAlignment: MainAxisAlignment.spaceBetween,
                children: [
                  Text(
                    "10 Tips",
                    style: TextStyle(
                      color: Colors.blue,
                      fontSize: 24,
                      fontWeight: FontWeight.w700,
                    ),
                  ),
                  Text(
                    "See All",
                    style: TextStyle(
                      color: Colors.blue,
                      fontSize: 16,
                      fontWeight: FontWeight.w400,
                    ),
                  ),
                ],
              ),
            ),
            Container(
              child: Expanded(
                child: ListView.builder(
                  itemCount: sampleMovies.length,
                  itemBuilder: (context, index) {
                    return Tipscard(index: index, object: sampleMovies[index]);
                  },
                ),
              ),
            ),
          ],
        ),
      ),
    );
  }
}
