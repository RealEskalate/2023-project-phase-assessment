import 'package:flutter/material.dart';
import 'package:mobile/core/utils/app_dimension.dart';

class SavedMovieCard extends StatelessWidget {
  const SavedMovieCard({super.key});

  @override
  Widget build(BuildContext context) {
    return Stack(
      children: [
        Container(

          margin: EdgeInsets.only(left: AppDimension.width(20, context),
          right: AppDimension.width(20, context),
          top: AppDimension.height(30, context)

          
          ),
          width: AppDimension.width(190, context),
height: AppDimension.height(330, context),

          child: ClipRRect(
                        borderRadius: BorderRadius.circular(
              AppDimension.height(15, context),
            ),
            child: Image.asset("assets/images/onboarding.jpg",
            
            fit: BoxFit.cover,
            ),
          ),

        ),


        Container(
          decoration: BoxDecoration(
            color: Colors.white,
            borderRadius: BorderRadius.circular(
              AppDimension.height(10, context)
            )
          ),
          margin: EdgeInsets.only(
            top: AppDimension.height(270, context),
            left: AppDimension.width(40, context)
          ),
          width: AppDimension.width(150, context),
          height: AppDimension.height(80, context),
          
          
          child: Container(
            margin: EdgeInsets.symmetric(vertical: AppDimension.height(10, context)),
            child: Column(
              mainAxisAlignment: MainAxisAlignment.spaceBetween,
              children: [
                Container(
                  child: Text("Autobiography")
                  ),
                  Container(
                    width: AppDimension.width(130, context),
                    child: Row(
                      mainAxisAlignment: MainAxisAlignment.spaceBetween,
                      children: [
                        Container(
                          child: Row(children: [
                          Icon(Icons.star,
                          color: Colors.yellow.shade900,
                          ),
                          Text("4.5",
                          
                          ),
                          ],),
                        ),
          
                        Container(
                          child: Row(children: [
                         Icon(Icons.access_time),
                          Text("1 hour"),
                          ],),
                        )
          
                      ],
                    ),
                  )
                
              ],
            ),
          )
        )
      ],
    );
  }
}
