

import 'package:mobile/core/usecase.dart';
import 'package:mobile/features/example/domain/entities/Movie.dart';
import 'package:mobile/features/example/domain/repositories/movie_repository.dart';

class getOneRepository implements GetOneUsecase{

  final MovieRepository repository;

  getOneRepository({required this.repository});
  @override

  Future<Movie> call(String? id) async {
    return await repository.getOneMovie(id);
  }

}