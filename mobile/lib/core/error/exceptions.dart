import 'package:equatable/equatable.dart';

class ServerException extends Equatable implements Exception {
   ServerException({required this.message, required this.statusCode});
  final String message;
  final int statusCode;

  factory ServerException.fromException(ServerException exception) =>
      ServerException(message: exception.message, statusCode: exception.statusCode);

  @override
  List<Object?> get props => [message, statusCode];
}
