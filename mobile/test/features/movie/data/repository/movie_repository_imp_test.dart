import 'package:dartz/dartz.dart';
import 'package:flutter_test/flutter_test.dart';
import 'package:mocktail/mocktail.dart';
import 'package:mobile/core/error/exceptions.dart';
import 'package:mobile/core/error/failure.dart';
import 'package:mobile/features/movie/data/datasources/remote_data_sources.dart';
import 'package:mobile/features/movie/data/model/movie_model.dart';
import 'package:mobile/features/movie/data/repository/movie_repository_implementation.dart';
import 'package:mobile/features/movie/domain/entities/movie.dart';

class MocMovieRemoteDataSource extends Mock implements MovieRemoteDataSource {}

void main() {
  late MovieRemoteDataSource remoteSource;
  late MovieRepositoryImp repoImp;
  setUp(() {
    remoteSource = MocMovieRemoteDataSource();
    repoImp = MovieRepositoryImp(remoteSource);
  });

  final tException = ServerException(
    message: "Unknow exception",
    statusCode: 500,
  );


  group("getMovies", () {
    final expectedAnswer = [MovieModel.empty()];
    test(
        "Should call [RemoteDataSource.getMovies] and return"
        "[List<<Movie>>] when the call to remote data source is successful",
        () async {
      // arrange
      when(
        () => remoteSource.getMovies(),
      ).thenAnswer((_) async => expectedAnswer);

      // act
      final result = await remoteSource.getMovies();

      // assert
      expect(result, isA<List<Movie>>());
      verify(() => remoteSource.getMovies()).called(1);
      verifyNoMoreInteractions(remoteSource);
    });

    test(
        "Should return [ServerFailure] when the call to remote"
        "source is unsuccessful", () async {
      // arrange
      when(
        () => remoteSource.getMovies(),
      ).thenThrow(tException);

      // act
      final result = await repoImp.getMovies();

      // assert
      expect(
        result,
        equals(
          Left(ServerFailure.fromException(tException)),
        ),
      );
    });
  });
}
