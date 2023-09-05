import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:mobile/features/movies/presentation/bloc/movie_bloc.dart';

class CustomInputField extends StatelessWidget {
  final TextEditingController controller;
  const CustomInputField({super.key, required this.controller});

  bool isDarkMode(BuildContext context) {
    return false;
  }

  @override
  Widget build(BuildContext context) {
    final width = MediaQuery.of(context).size.width;
    return Row(
      mainAxisAlignment: MainAxisAlignment.spaceAround,
      children: [
        Container(
          width: width * 0.8,
          height: 50.43,
          decoration: ShapeDecoration(
            color: isDarkMode(context)
                ? const Color.fromARGB(255, 29, 26, 34)
                : Colors.white,
            shape: RoundedRectangleBorder(
              borderRadius: BorderRadius.circular(10),
            ),
            shadows: [
              BoxShadow(
                color: isDarkMode(context)
                    ? const Color.fromARGB(255, 61, 51, 77)
                    : const Color(0x3FB1B1B1),
                blurRadius: isDarkMode(context) ? 2 : 6,
                offset: isDarkMode(context)
                    ? const Offset(0, 0)
                    : const Offset(0, 1),
                spreadRadius: 0,
              )
            ],
          ),
          child: TextField(
            onChanged: (val){
              BlocProvider.of<MovieBloc>(context).add(SearchMoviesEvent(searchParams: val));
            },
            controller: controller,
            decoration: InputDecoration(
              border: OutlineInputBorder(
                borderSide: BorderSide.none,
                borderRadius: BorderRadius.circular(10),
              ),
              hintText: 'search and article...',
              hintStyle: const TextStyle(
                color: Color(0xFF9A9494),
                fontSize: 15,
                fontWeight: FontWeight.w300,
              ),
            ),
          ),
        ),
        CustomizedButton(
          icon: const Icon(Icons.search),
          onpressed: () => {},
        )
      ],
    );
  }
}

class CustomizedButton extends StatelessWidget {
  final Icon icon;
  final VoidCallback onpressed;

  const CustomizedButton({
    super.key,
    required this.onpressed,
    required this.icon,
  });

  @override
  Widget build(BuildContext context) {
    return FloatingActionButton(
      heroTag: null,
      onPressed: onpressed,
      backgroundColor: Theme.of(context).colorScheme.primary,
      child: Icon(
        icon.icon,
        size: 30,
        color: Colors.white,
      ),
    );
  }
}
