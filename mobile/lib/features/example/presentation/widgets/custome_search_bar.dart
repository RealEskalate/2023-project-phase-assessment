import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:mobile/features/example/presentation/bloc/movie_bloc.dart';

class CustomeSearchBar extends StatefulWidget {
  const CustomeSearchBar({Key? key}) : super(key: key);

  @override
  _CustomeSearchBarState createState() => _CustomeSearchBarState();
}

class _CustomeSearchBarState extends State<CustomeSearchBar> {
  late TextEditingController _searchController;

  @override
  void initState() {
    super.initState();
    _searchController = TextEditingController();
  }

  @override
  void dispose() {
    _searchController.dispose();
    super.dispose();
  }

  void _performSearch() {
    String searchText = _searchController.text;
  }

  @override
  Widget build(BuildContext context) {
    return BlocBuilder<MovieBloc, MovieState>(
      builder: (context, state) {
        return Container(
          height: 60,
          padding: EdgeInsets.only(left: 15, right: 5),
          alignment: Alignment.center,
          margin: EdgeInsets.all(20),
          decoration: BoxDecoration(
            borderRadius: BorderRadius.all(Radius.circular(10)),
            color: Colors.white,
          ),
          child: Row(
            children: [
              Expanded(
                child: TextField(
                  controller: _searchController,
                  decoration: InputDecoration(
                    border: InputBorder.none,
                    hintText: 'Looking for shows',
                  ),
                  maxLines: null,
                ),
              ),
              ElevatedButton(
                onPressed: () {
                  print("wor..");
                  context
                      .read<MovieBloc>()
                      .add(SearchMovies(_searchController.text));
                },
                child: Icon(Icons.search, color: Colors.white),
                style: ElevatedButton.styleFrom(
                  backgroundColor: Colors.blue,
                  padding: EdgeInsets.symmetric(horizontal: 20, vertical: 14),
                  shape: RoundedRectangleBorder(
                    borderRadius: BorderRadius.circular(10),
                  ),
                ),
              ),
            ],
          ),
        );
      },
    );
  }
}
