import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

import '../../../../core/presentation/theme/app_colors.dart';

class MovieDetailScreen extends StatelessWidget {
  const MovieDetailScreen({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        elevation: 0.0,
        title: const Center(
          child: Text(
            'Detail',
            style: TextStyle(color: AppColors.black),
          ),
        ),
        backgroundColor: AppColors.white,
        leading: IconButton(
          onPressed: () {},
          icon: const Icon(
            Icons.arrow_back,
            color: AppColors.blue,
          ),
        ),
        actions: [
          IconButton(
            onPressed: () {},
            icon: const Icon(
              Icons.bookmark_border_outlined,
              color: AppColors.blue,
            ),
          )
        ],
      ),
      body: Container(
          padding: const EdgeInsets.all(10.0),
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              Container(
                decoration:
                    BoxDecoration(borderRadius: BorderRadius.circular(10.0)),
                height: 380.h,
                width: 300.w,
                child: ClipRRect(
                  borderRadius: BorderRadius.circular(10.0),
                  child: const Image(
                      image: AssetImage(
                        'assets/images/splash_screen.jpg',
                      ),
                      fit: BoxFit.cover),
                ),
              ),
              SizedBox(
                height: 10.h,
              ),
              Text(
                'A Man Called Otto',
                style: Theme.of(context).textTheme.titleMedium,
              ),
              Row(
                children: [
                  const Icon(
                    Icons.access_time,
                    color: AppColors.blue,
                  ),
                  SizedBox(
                    width: 5.w,
                  ),
                  Text('1 hour'),
                  SizedBox(
                    width: 5.w,
                  ),
                  Text('|'),
                  SizedBox(
                    width: 5.w,
                  ),
                  Text('Comedy & drama')
                ],
              ),
              SizedBox(
                height: 20.h,
              ),
              SizedBox(
                height: 200.h,
                child: const SingleChildScrollView(
                  child: Text(
                    'dnwidewiheui suwie uwehdue jqwndnwu sldkmowe aksnwie soiejfieo sjdwoiej jsndi ne jidwiejided ttttttttttttttttttttttttttttttttttttttttttttt sbdudwude jnswqiejd, dnwidewiheui suwie uwehdue jqwndnwu sldkmowe aksnwie soiejfieo sjdwoiej jsndi ne jidwiejided ttttttttttttttttttttttttttttttttttttttttttttt sbdudwude jnswqiejd, dnwidewiheui suwie uwehdue jqwndnwu sldkmowe aksnwie soiejfieo sjdwoiej jsndi ne jidwiejided ttttttttttttttttttttttttttttttttttttttttttttt sbdudwude jnswqiejd, dnwidewiheui suwie uwehdue jqwndnwu sldkmowe aksnwie soiejfieo sjdwoiej jsndi ne jidwiejided ttttttttttttttttttttttttttttttttttttttttttttt sbdudwude jnswqiejd',
                    softWrap: true,
                    // overflow: TextOverflow.ellipsis,
                  ),
                ),
              ),
              SizedBox(
                width: 350.w,
                height: 50.h,
                child: ElevatedButton(
                  onPressed: () {},
                  child: Text('Watch Now'),
                ),
              )
            ],
          )),
    );
  }
}
