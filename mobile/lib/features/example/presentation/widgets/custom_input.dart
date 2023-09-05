import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:mobile/features/example/presentation/bloc/movie_bloc.dart';

class CustomInput extends StatelessWidget {
  TextEditingController controller;
  CustomInput({
    required this.controller,
    super.key,
  });

  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: const EdgeInsets.only(
        left: 20.0,
        right: 15,
        top: 10,
        ),
      child: Container(
        decoration: ShapeDecoration(
          shape: RoundedRectangleBorder(
            borderRadius: BorderRadius.circular(15),
          ),
          color: Colors.white,
        ),
        child: TextField(
          controller: controller,
          decoration: InputDecoration(
            hintText: 'Looking for shows',
            hintStyle: TextStyle(
              color: Colors.grey,
            ),
            border: InputBorder.none,
            suffixIcon: ElevatedButton(
              style: ElevatedButton.styleFrom(
                shape: RoundedRectangleBorder(
                  borderRadius: BorderRadius.circular(12),
                ),
              ),
              onPressed:  () => dispatchSearch(context),
              child: const Icon(
                Icons.search,
                size: 40,
              ),
            ),
          ),
        ),
      ),
    );
  }
  void dispatchSearch(BuildContext context) {
    BlocProvider.of<MovieBloc>(context).add(SearchMoviesEvent(
      query: controller.text,
    ));
  }
}
