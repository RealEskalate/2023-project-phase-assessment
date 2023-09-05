import 'package:equatable/equatable.dart';

abstract class Failure extends Equatable {
  final String message;
  final int statusCode;
  Failure({
    required this.message,
    required this.statusCode,
  });

  String get errorMessage => "$statusCode Error: $message";

  @override
  List<Object> get props => [message, statusCode];
}

class CachFailure extends Failure {
  CachFailure({required super.message, required super.statusCode});
}

class ServerFailure extends Failure {
  ServerFailure({required super.message, required super.statusCode});

  factory ServerFailure.fromException(exception) => ServerFailure(
      message: exception.message, statusCode: exception.statusCode);
}
