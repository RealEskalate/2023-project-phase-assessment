class Movie {
  String? sId;
  String? category;
  String? title;
  String? description;
  String? duration;
  String? image;
  double? rating;
  String? createdAt;
  String? id;

  Movie(
      {this.sId,
      this.category,
      this.title,
      this.description,
      this.duration,
      this.image,
      this.rating,
      this.createdAt,
      this.id});

  Movie.fromJson(Map<String, dynamic> json) {
    sId = json['_id'];
    category = json['category'];
    title = json['title'];
    description = json['description'];
    duration = json['duration'];
    image = json['image'];
    rating = json['rating'];
    createdAt = json['createdAt'];
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
    data['id'] = this.id;
    return data;
  }
}
