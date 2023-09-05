// core/usecases/usecase.dart

import 'package:dartz/dartz.dart';
import '../Error/failures.dart';


abstract class UseCase<Params, T> {
  Future<Either<Faliure, T>> call(Params params);
}

class NoParams{}