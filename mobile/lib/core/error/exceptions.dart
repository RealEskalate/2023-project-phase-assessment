import 'package:equatable/equatable.dart';

abstract class Exception extends Equatable{
  final String message;

  const Exception({required this.message});

  @override
  List<Object?> get props => [message];
}

class ServerException extends Exception {
  const ServerException({required String message}) : super(message: message);
}

class CacheException extends Exception {
  const CacheException({required String message}) : super(message: message);
}