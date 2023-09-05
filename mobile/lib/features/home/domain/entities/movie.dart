// this is the movie entity

class Movie {
  final String id;
  final String title;
  final String description;
  final String duration;
  final String image;
  final String rating;

  Movie(this.title, this.description, this.duration, this.image, this.rating,
      this.id);
}
