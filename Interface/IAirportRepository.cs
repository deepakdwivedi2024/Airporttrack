public interface IAirportRepository
{
    Task<IEnumerable<Airport>> GetAllAsync();
    Task<IEnumerable<BsonDocument>> AggregateAsync(BsonDocument[] pipeline);
    Task BulkInsertAsync(IEnumerable<Airport> airports);
    Task<IEnumerable<Airport>> GetSortedAndLimitedAsync(int limit);
    Task<IEnumerable<Airport>> GetFilteredAsync(string country);
    Task<IEnumerable<Airport>> GetNearbyAirportsAsync(double latitude, double longitude, double distance);
    Task<IEnumerable<Airport>> SearchAsync(string searchText);
    Task GenerateCSVAsync(IEnumerable<Airport> airports, string filePath);
    Task UploadToAzureBlobAsync(string filePath, string containerName, string blobName);
    void CreateIndexBTree();
    void CreateTextIndex();
    void CreateGeospatialIndex();
    void CreateBucketIndex();
    // Other CRUD methods
}

