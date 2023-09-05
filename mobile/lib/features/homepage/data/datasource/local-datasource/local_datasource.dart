abstract class LocalDatasource {
  Future<List<String>> getFavorites();
  Future<void> addFavorite(String id);
  Future<bool> isFavorite(String id);
}
