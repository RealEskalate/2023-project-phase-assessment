import 'dart:convert';

import 'package:flutter_test/flutter_test.dart';
import 'package:http/http.dart' as http;
import 'package:mocktail/mocktail.dart';
import 'package:mobile/core/error/exceptions.dart';
import 'package:mobile/core/utils/constants.dart';
import 'package:mobile/features/movie/data/datasources/remote_data_sources.dart';
import 'package:mobile/features/movie/data/model/movie_model.dart';

class MockClient extends Mock implements http.Client {}

void main() {
  late http.Client client;
  late MovieRemoteDataSource remoteDataSource;

  setUp(() {
    client = MockClient();
    remoteDataSource = MovieRemotDataSourceImp(client);
    registerFallbackValue(Uri());
  });

  group("getMovies", () {
    final tMovies = [MovieModel.empty()];
    const tMessage = "Server down server"
        "down, I repeat server down"
        "Mayday Mayday Mayday We are goind down"
        "AHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHH";

    test("should return [List<Movie>] when the status code is 200", () async {
      // arrenge
      when(() => client.get(any())).thenAnswer(
        (_) async => http.Response(jsonEncode([tMovies.first.toMap()]), 200),
      );

      // act
      final result = await remoteDataSource.getMovies();

      // assert
      expect(result, equals(tMovies));
      verify(
        () => client.get(Uri.https("$kBaseUrl/article?searchParams=Quest")),
      ).called(1);
      verifyNoMoreInteractions(client);
    });

    test("should throw [ServerExceptin] when the status code is not 200 or 201",
        () async {
      // arrenge
      when(() => client.get(any())).thenAnswer(
        (_) async => http.Response(tMessage, 500),
      );

      // act
      final methodeCall = await remoteDataSource.getMovies;

      // assert
      expect(() => methodeCall(),
          throwsA(ServerException(message: tMessage, statusCode: 500)));
      verify(
        () => client.get(Uri.parse("$kBaseUrl/article?searchParams=Quest")),
      ).called(1);
      verifyNoMoreInteractions(client);
    });
  });
}
