import '../../domain/entities/movie.dart';

class GetMoviesDto {
  bool? success;
  List<Data>? data;

  GetMoviesDto({this.success, this.data});

  GetMoviesDto.fromJson(Map<String, dynamic> json) {
    success = json['success'];
    if (json['data'] != null) {
      data = <Data>[];
      json['data'].forEach((v) {
        data!.add(new Data.fromJson(v));
      });
    }
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['success'] = this.success;
    if (this.data != null) {
      data['data'] = this.data!.map((v) => v.toJson()).toList();
    }
    return data;
  }
}

class Data {
  String? sId;
  String? category;
  String? title;
  String? description;
  String? duration;
  String? image;
  num? rating;
  String? createdAt;
  int? iV;
  String? id;

  Data(
      {this.sId,
      this.category,
      this.title,
      this.description,
      this.duration,
      this.image,
      this.rating,
      this.createdAt,
      this.iV,
      this.id});

  Data.fromJson(Map<String, dynamic> json) {
    sId = json['_id'];
    category = json['category'];
    title = json['title'];
    description = json['description'];
    duration = json['duration'];
    image = json['image'];
    rating = json['rating'];
    createdAt = json['createdAt'];
    iV = json['__v'];
    id = json['id'];
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

  Movie toMovie() {
    return Movie(
      title: this.title ?? '',
      description: description ?? '',
      duration: duration?? '',
      image: image?? '',
      rating: rating.toString(), 
      category: category ?? '',
    );
  }
}
