import 'package:mobile/features/example/domain/entities/Movie.dart';

abstract class GetOneUsecase{
  Future<Movie> call(String? id);
}

abstract class GetAllUsecase{
  Future<List<Movie>> call();
}