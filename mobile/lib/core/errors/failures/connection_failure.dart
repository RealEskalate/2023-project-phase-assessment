import 'package:mobile/core/errors/failures/failure.dart';

class ConnectionFailure extends Failure {
  final String? message;
  ConnectionFailure({this.message = ""});
}
