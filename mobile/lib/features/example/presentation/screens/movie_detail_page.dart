import 'package:flutter/material.dart';
import 'package:mobile/core/utils/app_dimension.dart';

class movieDetail extends StatelessWidget {
  const movieDetail({super.key});

  @override
  Widget build(BuildContext context) {
    return SafeArea(
      child: Scaffold(
        appBar: AppBar(
          backgroundColor: Colors.white,
          leading: IconButton(
            icon: Icon(Icons.arrow_back,
            size: AppDimension.height(35, context),
            ),
            onPressed: () {
              Navigator.pushNamed(context, "/home");
            },
          ),
          title: Container(
              margin: EdgeInsets.only(left: AppDimension.width(60, context)),
              child: Text('Alem Cinema')),
    
          actions: [
            Icon(
              Icons.bookmark,
              size: AppDimension.height(35, context),
            )
          ],
        ),
    
        body: SingleChildScrollView(
          child: Column(
            mainAxisAlignment: MainAxisAlignment.center,
            children: [
              Center(
                child: Container(
                  width: AppDimension.width(300, context),
                  height: AppDimension.height(500, context),
                  child: Image.asset("assets/images/onboarding.jpg",
                  fit: BoxFit.cover,
                  ),
                ),
              ),
        
              Container(
                margin: EdgeInsets.only(top: AppDimension.height(15, context)),
                child: Column(
                  children: [
                    Text("A MAN CALLED OTTO",
                    style: TextStyle(
                      fontWeight: FontWeight.w600,
                    ),
                    ),
        
                    Container(
                      margin: EdgeInsets.only(left: AppDimension.width(60, context)),
                      child: Row(
                        children: [
                          Icon(Icons.access_time),
                          Text("1 hour| comedy or drama"),
                    
                        ],
                      ),
                    ),
    
                    Container(
      margin: EdgeInsets.only(top: AppDimension.height(10, context)),
      width: AppDimension.width(350, context),
      height: AppDimension.height(350, context),
      child: Text(
      "Your long text goes here, and it will be truncated with an ellipsis at the end if it exceeds the container's width.Your long text goes here, and it will be truncated with an ellipsis at the end if it exceeds the container's width.Your long text goes here, and it will be truncated with an ellipsis at the end if it exceeds the container's width.Your long text goes here, and it will be truncated with an ellipsis at the end if it exceeds the container's width.",
      maxLines:(AppDimension.height(350, context)/35).toInt(), // Set the maximum number of lines
      overflow: TextOverflow.ellipsis, // Overflow with ellipsis
      style: TextStyle(
        color: Colors.black,
        fontSize: AppDimension.height(25, context),
      ),
      ),
    ),
    Center(
              child: Container(
                margin: EdgeInsets.only(top: AppDimension.height(50, context)),
                width: AppDimension.width(200, context), // Set the desired width
                height:
                    AppDimension.height(50, context), // Set the desired height
                child: ElevatedButton(
                  onPressed: () {
                    
                  },
                  style: ElevatedButton.styleFrom(
                    primary: Colors.blue, // Background color
                    onPrimary: Colors.white,
                    shape: RoundedRectangleBorder(
                      borderRadius: BorderRadius.circular(AppDimension.height(
                          10, context)), // Remove the border radius
                    ), // Text color
                  ),
                  child: Text('Watch Now'),
                ),
              ),
            )
    
        
                  ],
                ),
              )
            ],
          ),
        ),
      ),
    );
  }
}
