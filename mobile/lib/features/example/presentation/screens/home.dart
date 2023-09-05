import 'package:flutter/material.dart';

class Home extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        leading: IconButton(
          icon: Icon(Icons.arrow_back, color: Colors.black,),
          onPressed: () {
            Navigator.pop(context);
          },
        ),
        title: Text('Alem Cinema',style: TextStyle(color: Colors.black),),
      ),
      body: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
    
          Padding(
            padding: const EdgeInsets.all(8.0),
            child: Row(
              children: [
                const Expanded(
                  child: TextField(
                    decoration: InputDecoration(
                      hintText: 'Search',
                      border: OutlineInputBorder(),
                    ),
                  ),
                ),
                IconButton(
                  icon:
                      Icon(Icons.bookmark), 
                  onPressed: () {
                    
                  },
                ),
              ],
            ),
          ),
          
          Container(
            height: 100, 
            child: ListView.builder(
              scrollDirection: Axis.horizontal,
              itemCount: 3, 
              itemBuilder: (context, index) {
                return Card(
                 
                  child: Column(
                    children: [
                      Image.asset(
                          'image/movie$index.jpg'), 
                      Text('Movie $index'),
                    ],
                  ),
                );
              },
            ),
          ),
          
          const Padding(
            padding: EdgeInsets.all(8.0),
            child: Text(
              'All Movies',
              style: TextStyle(fontSize: 20, fontWeight: FontWeight.bold),
            ),
          ),
          Expanded(
            child: ListView.builder(
              itemCount: 20, 
              itemBuilder: (context, index) {
                return ListTile(
                  leading: Image.asset(
                      'image/movie$index.jpg'),
                  title: Text('Movie $index'), 
                );
              },
            ),
          ),
        ],
      ),
    );
  }
}
