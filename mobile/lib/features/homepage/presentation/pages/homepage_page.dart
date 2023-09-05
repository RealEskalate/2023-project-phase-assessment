import 'package:flutter/material.dart';

class HomePage extends StatefulWidget {
  const HomePage({super.key});

  @override
  State<HomePage> createState() => _HomePageState();
}

class _HomePageState extends State<HomePage> {
  final searchTermController = TextEditingController();

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        centerTitle: true,
        title: const Text('Alem Cinema'),
      ),
      body: SingleChildScerollView(
        child: Column(children: [
          Padding(
            padding: const EdgeInsetsDirectional.all(10),
            child: Row(mainAxisAlignment: MainAxisAlignment.center, children: [
              // TextFormField(
              //   controller: searchTermController,
              //   keyboardType: TextInputType.number,
              //   decoration: const InputDecoration(
              //     border: OutlineInputBorder(
              //         borderRadius: BorderRadius.all(Radius.circular(10.0)),
              //         borderSide: BorderSide(color: Colors.grey, width: 0)),
              //     hintText: "Looking for shows ...",
              //     hintStyle: TextStyle(
              //         color: Colors.grey,
              //         fontSize: 15.0,
              //         fontWeight: FontWeight.w300),
              //   ),
              //   style: const TextStyle(
              //       // Style for input text
              //       color: Colors.black, // Color of input text
              //       fontSize: 19.0,
              //       fontWeight: FontWeight.w400 // Font size of input text
              //       ),
              // ),
            ]),
          )
        ]),
      ),
    );
  }
}
