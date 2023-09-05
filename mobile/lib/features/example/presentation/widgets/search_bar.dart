import 'package:flutter/material.dart';

class SearchBarWidget extends StatefulWidget {
  final Function searchByName;
  const SearchBarWidget({super.key, required this.searchByName});

  @override
  _SearchBarWidgetState createState() => _SearchBarWidgetState();
}

class _SearchBarWidgetState extends State<SearchBarWidget> {
  TextEditingController queryController = TextEditingController();

  @override
  Widget build(BuildContext context) {
    return Stack(
      children: [
        Container(
          width: 379,
          height: 70.5,
          padding: EdgeInsets.only(left: 15),
          decoration: BoxDecoration(
            border: Border.all(color: Colors.grey.withOpacity(0.1)),
            color: Colors.white,
            borderRadius: BorderRadius.circular(10),
            boxShadow: [
              BoxShadow(
                color: Colors.grey.withOpacity(0.1),
                spreadRadius: 5,
                blurRadius: 7,
                offset: const Offset(0, 2),
              ),
            ],
          ),
          child: Center(
            child: TextField(
              controller: queryController,
              decoration: InputDecoration(
                hintText: 'Looking for shows',
                hintStyle: TextStyle(
                  color: Theme.of(context).hintColor,
                  fontSize: 15,
                  fontWeight: FontWeight.w300,
                ),
                border: InputBorder.none,
              ),
            ),
          ),
        ),
        Positioned(
          right: 0,
          width: 52,
          height: 70.5,
          child: ElevatedButton(
            
            onPressed: () {
              widget.searchByName(queryController.text);
            },
            style: ElevatedButton.styleFrom(
              backgroundColor: Colors.blue,
              padding: EdgeInsets.symmetric(vertical: 16, horizontal: 16),
              shape: RoundedRectangleBorder(
                borderRadius: BorderRadius.circular(10),
              ),
            ),
            child: Icon(
              Icons.search, // Clear icon
              color: Colors.white,
              size: 24,
            ),
          ),
        ),
      ],
    );
  }

  void _filterArticles(BuildContext context) {
    if (queryController.text.isNotEmpty) {
      //   BlocProvider.of<ArticleBloc>(context).add(FilterArticles(query: queryController.text));
    } else {
      //   BlocProvider.of<ArticleBloc>(context).add(const LoadArticles());
    }
  }
}
