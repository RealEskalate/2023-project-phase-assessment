import 'package:mobile/core/usecase.dart';
import 'package:mobile/features/example/domain/entities/Movie.dart';
import 'package:mobile/features/example/domain/repositories/movie_repository.dart';


class GetAllMoviesImpl implements GetAllUsecase{

  final MovieRepository repository;

  GetAllMoviesImpl({required this.repository});

  Future<List<Movie>> call() async {
    // print("usecase");
    return await repository.getAllMovies();
  }
}
