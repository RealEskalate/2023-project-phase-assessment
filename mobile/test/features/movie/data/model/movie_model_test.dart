import 'dart:convert';

import 'package:flutter_test/flutter_test.dart';
import 'package:mobile/features/movie/data/model/movie_model.dart';
import 'package:mobile/features/movie/domain/entities/movie.dart';
import 'package:mobile/core/utils/typedef.dart';
import '../../../../fixtures/fixture_reader.dart';

void main() {
  final tModel = MovieModel.empty();
  test("should be a subclass of be [Movie] entity", () {
    // arrange

    // act

    // assert
    expect(tModel, isA<Movie>());
  });

  final tJson = fixture("movie.json");
  final tMap = jsonDecode(tJson) as DataMap;

  group("fromMap", () {
    test("should return a [MovieModel] with the right data", () {
      final result = MovieModel.fromMap(tMap);
      expect(result, equals(tModel));
    });
  });

  group("fromJson", () {
    test("should return a [MovieModel] with the right data", () {
      final result = MovieModel.fromJson(tJson);
      expect(result, equals(tModel));
    });
  });

  group("toMap", () {
    test("should return a [Map] with the right data", () {
      final result = tModel.toMap();
      expect(result, equals(tMap));
    });
  });

  group("toJson", () {
    test("should return a [JSON] string with the right data", () {
      final result = tModel.toJson();
      final tJson = jsonEncode({
        "id": "-1",
        "category": "_empty.category",
        "description": "_empty.description",
        "title": "_empty.title",
        "duration": "_empty.duration",
        "rating": "_empty.rating",
        "image": "_empty.image",
        "createdAt": "_empty.createdAt",
      });
      expect(result, equals(tJson));
    });
  });

  group("copyWith", () {
    test("should return a [MovieModel] with different  data", () {
      final result = tModel.copyWith(title: "ketema");

      expect(result.title, equals("ketema"));
    });
  });
}
