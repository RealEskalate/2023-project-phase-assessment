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

  group("createUser", () {
    test(
      "should complete successfully when the status code is 200 or 201",
      () async {
        when(
          () => client.post(any(), body: any(named: "body")),
        ).thenAnswer(
          (_) async => await http.Response("user created successfully!", 201),
        );

        // act

        final methodCall = remoteDataSource.createUser;

        // assert
        expect(
          methodCall(
            category: "Action",
            image:
                "https://fastly.picsum.photos/id/1/200/300.jpg?hmac=jH5bDkLr6Tgy3oAg5khKCHeunZMHq0ehBZr6vGifPLY",
            createdAt: "2023-09-04T16:35:44.676Z",
          ),
          completes,
        );

        verify(
          () => client.post(
            Uri.https(kBaseUrl, kGetUserEndpoint),
            body: jsonEncode({
              "id": "-1",
              "category": "_empty.category",
              "description": "_empty.description",
              "title": "_empty.title",
              "duration": "_empty.duration",
              "rating": "_empty.rating",
              "image": "_empty.image",
              "createdAt": "_empty.createdAt"
            }),
          ),
        ).called(1);
      },
    );

    test(
      "should complete successfully when the status code is 200 or 201",
      () async {
        when(
          () => client.post(any(), body: any(named: "body")),
        ).thenAnswer(
          (_) async => http.Response("Invalid email", 400),
        );

        // act

        final methodCall = remoteDataSource.createUser;

        // assert
        expect(
          () async => methodCall(
            category: "Action",
            image:
                "https://fastly.picsum.photos/id/1/200/300.jpg?hmac=jH5bDkLr6Tgy3oAg5khKCHeunZMHq0ehBZr6vGifPLY",
            createdAt: "2023-09-04T16:35:44.676Z",
          ),
          throwsA(
            ServerException(message: "Invalid email", statusCode: 400),
          ),
        );
      },
    );
  });

  group("getUsers", () {
    final tUsers = [MovieModel.empty()];
    const tMessage = "Server down server"
        "down, I repeat server down"
        "Mayday Mayday Mayday We are goind down"
        "AHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHH";
    test("should return [List<User>] when the status code is 200", () async {
      // arrenge
      when(() => client.get(any())).thenAnswer(
        (_) async => http.Response(jsonEncode([tUsers.first.toMap()]), 200),
      );

      // act
      final result = await remoteDataSource.getMovies();

      // assert
      expect(result, equals(tUsers));
      verify(
        () => client.get(Uri.https(kBaseUrl, kGetUserEndpoint)),
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
        () => client.get(Uri.https(kBaseUrl, kGetUserEndpoint)),
      ).called(1);
      verifyNoMoreInteractions(client);
    });
  });
}
