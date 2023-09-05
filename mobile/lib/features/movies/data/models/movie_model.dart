class MovieModel {
  String? sId;
  String? category;
  String? title;
  String? description;
  String? duration;
  String? image;
  double? rating;
  String? createdAt;
  String? id;

  MovieModel(
      {required this.sId,
      required this.category,
      required this.title,
      required this.description,
      required this.duration,
      required this.image,
      required this.rating,
      required this.createdAt,
      required this.id});

  factory MovieModel.fromJson(Map<String, dynamic> json) {
    return MovieModel(
        sId: json['_id'],
        category: json['category'],
        title: json['title'],
        description: json['description'],
        duration: json['duration'],
        image: json['image'],
        rating: json['rating'],
        createdAt: json['createdAt'],
        id: json['id']);
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
