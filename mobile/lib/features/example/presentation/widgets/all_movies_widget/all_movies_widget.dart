import 'package:flutter/material.dart';
import 'package:mobile/core/utils/app_dimension.dart';

class AllMoviesWidget extends StatelessWidget {
  const AllMoviesWidget({super.key});

  @override
  Widget build(BuildContext context) {
    return Container(
      margin: EdgeInsets.only(
        top: AppDimension.height(20, context),
        bottom: AppDimension.height(20, context)

      ),
      width: AppDimension.width(200, context),
      height: AppDimension.height(150, context),
      child: Card(
        child: Row(
          children: [
            Container(
              margin: EdgeInsets.only(left: AppDimension.width(20, context),
              top: AppDimension.height(5, context),
              right: AppDimension.width(20, context)
              ),
              width: AppDimension.width(120, context),
              height: AppDimension.height(100, context),
              child: Image.asset("assets/images/onboarding.jpg",
              fit: BoxFit.cover,
              
              
              ),
            ),

            Container(
              margin: EdgeInsets.symmetric(vertical:AppDimension.height(10, context)),
              child: Column(
                mainAxisAlignment: MainAxisAlignment.spaceBetween,
                children: [
                  Container(
                    
                    child: Text("operation Fortune",
                    style: TextStyle(
                      fontSize: AppDimension.height(25, context)
                    ),
                    ),
            
                  ),
            
                   Container(
                    width: AppDimension.width(150, context),
                     child: Row(
                          mainAxisAlignment: MainAxisAlignment.spaceBetween,
                          children: [
                            Container(
                              child: Row(children: [
                              Icon(Icons.star,
                              color: Colors.yellow.shade900,
                              ),
                              Text("4.5",
                              style: TextStyle(
                                fontSize: AppDimension.height(20, context)
                              ),
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
                   ),
                ],
              ),
            )


          ],
        ),
      ),
      
    );
  }
}
