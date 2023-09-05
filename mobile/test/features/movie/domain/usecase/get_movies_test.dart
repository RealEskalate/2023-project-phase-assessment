import 'package:dartz/dartz.dart';
import 'package:flutter_test/flutter_test.dart';
import 'package:mocktail/mocktail.dart';
import 'package:mobile/features/movie/domain/entities/movie.dart';
import 'package:mobile/features/movie/domain/repository/movie_repo.dart';
import 'package:mobile/features/movie/domain/usecase/get_movies.dart';

import '../../movie_repo.mock.dart';

void main() {
  late MovieRepository repository;
  late GetMovies usecase;
  setUp(() {
    repository = MockMovieRepo();
    usecase = GetMovies(repository);
  });

  final tResponse = [Movie.empty()];
  test(
    "should call [MovieRepository.GetMovies]",
    () async {
      // arrange
      when(
        () => repository.getMovies(),
      ).thenAnswer((_) async => Right(tResponse));

      // act
      final result = await usecase();

      // assert
      expect(result, equals(Right<dynamic, List<Movie>>(tResponse)));

      verify(() => repository.getMovies()).called(1);
      verifyNoMoreInteractions(repository);
    },
  );
}
