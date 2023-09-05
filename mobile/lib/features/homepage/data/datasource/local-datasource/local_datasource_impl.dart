import 'package:shared_preferences/shared_preferences.dart';

import './local_datasource.dart';

class LocalDatasourceImpl extends LocalDatasource {
  final SharedPreferences prefs;

  LocalDatasourceImpl(this.prefs);
  @override
  Future<List<String>> getFavorites() async {
    List<String> ids = prefs.getStringList('myStrings') ?? [];
    return ids;
  }

  @override
  Future<void> addFavorite(String id) async {
    List<String> existingStrings = prefs.getStringList('myStrings') ?? [];
    if (!existingStrings.contains(id)) {
      existingStrings.add(id);
      prefs.setStringList('myStrings', existingStrings);
    }
  }

  @override
  Future<bool> isFavorite(String id) async {
    List<String> existingStrings = prefs.getStringList('myStrings') ?? [];
    if (!existingStrings.contains(id)) {
      return true;
    }
    return false;
  }
}
