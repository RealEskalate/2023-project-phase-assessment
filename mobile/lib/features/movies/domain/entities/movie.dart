import 'package:equatable/equatable.dart';
class Movie extends Equatable{
   String sId;
  String category;
  String title;
  String description;
  String duration;
  String image;
  double rating;
  String createdAt;
  int iV;
  String id;
  Movie({required this.sId, required this.category, required this.title, required this.description, required this.duration, required this.image, required this.rating, required this.createdAt, required this.iV, required this.id});
  factory Movie.fromJson(Map<String, dynamic> json) {
    return Movie(
      sId: json['_id'],
      category: json['category'],
      title: json['title'],
      description: json['description'],
      duration: json['duration'],
      image: json['image'],
      rating: json['rating'],
      createdAt: json['createdAt'],
      iV: json['__v'],
      id: json['id'],
    );
  }
  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['_id'] = this.sId;
    data['category'] = this.category;
    data['title'] = this.title;
    data['description'] = this.description;
    data['duration'] = this.duration;
    data['image'] = this.image;
    data['rating'] = this.rating;
    data['createdAt'] = this.createdAt;
    data['__v'] = this.iV;
    data['id'] = this.id;
    return data;
  }
  @override
  List<Object?> get props => [sId, category, title, description, duration, image, rating, createdAt, iV, id];
}