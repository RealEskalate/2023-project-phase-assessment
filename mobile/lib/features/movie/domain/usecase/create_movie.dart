import 'package:equatable/equatable.dart';
import 'package:mobile/core/usecase/usecase.dart';
import 'package:mobile/core/utils/typedef.dart';

import '../repository/movie_repo.dart';

class CreateUser extends UsecaseWithParams<void, CreateUserParams> {
  final MovieRepository _movieRepository;
  CreateUser(this._movieRepository);

  @override
  ResultVoid call(CreateUserParams params) async => _movieRepository.createUser(
        category: params.category,
        image: params.image,
        createdAt: params.createdAt,
      );
}

class CreateUserParams extends Equatable {
  final String category;
  final String image;
  final String createdAt;
  CreateUserParams({
    required this.category,
    required this.image,
    required this.createdAt,
  });

  CreateUserParams.empty()
      : this(
          category: "_empty.category",
          image: "_empty.image",
          createdAt: "_empty.createdAt",
        );

  @override
  List<Object?> get props => [category, image, createdAt];
}
