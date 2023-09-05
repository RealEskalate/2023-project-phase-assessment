import 'package:mobile/features/example/domain/entities/MovieEntity.dart';

class MovieModel extends MovieEntity{

   MovieModel({
    String? sId,
    String? category,
    String? title,
    String? description,
    String? duration,
    String? image,
    double? rating,
    String? createdAt,
    int? iV,
    String? id,
  }) : super(
    sId: sId,
    category: category,
    title: title,
    description: description,
    duration: duration,
    image: image,
    rating: rating,
    createdAt: createdAt,
    iV: iV,
    id: id,
  );

  Map<String,dynamic> toMap(){
    return {
      'sId':sId,
      'category':category,
      'title':title,
      'description':description,
      'duration':duration,
      'image':image,
      'rating':rating,
      'createdAt':createdAt,
      'iV':iV,
      'id':id,
    };
  }

  factory MovieModel.fromJson(Map<String,dynamic> json){
    return MovieModel(
      sId: json['sId'],
      category: json['category'],
      title: json['title'],
      description: json['description'],
      duration: json['duration'],
      image: json['image'],
      rating: json['rating'],
      createdAt: json['createdAt'],
      iV: json['iV'],
      id: json['id'],
    );
  } 
}