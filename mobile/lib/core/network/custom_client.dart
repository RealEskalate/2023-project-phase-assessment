import 'package:http/http.dart' as http;

typedef KeyValue = Map<String, dynamic>;
typedef Headers = Map<String, String>;

class CustomClient {
  final http.Client client;

  String? _authToken;

  String apiBaseUrl;

  CustomClient(this.client, {required this.apiBaseUrl});

  set authToken(String? value) {
    _authToken = value;
  }

  Future<http.Response> get(String relativeUrl,
      {KeyValue? queryParams, Headers headers = const {}}) async {
    Headers headersWithAuth = {
      ...headers,
      if (_authToken != null) 'Authorization': 'Bearer $_authToken'
    };

    return client.get(
        Uri.parse('$apiBaseUrl$relativeUrl')
            .replace(queryParameters: queryParams),
        headers: headersWithAuth);
  }
}
