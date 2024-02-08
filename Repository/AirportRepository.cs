public class AirportRepository : IAirportRepository
{
    private readonly IMongoCollection<Airport> _collection;

    public AirportRepository(IMongoDatabase database)
    {
        _collection = database.GetCollection<Airport>("Airports");
    }

    public async Task<IEnumerable<BsonDocument>> AggregateAsync(BsonDocument[] pipeline)
    {
        return await _collection.AggregateAsync<BsonDocument>(pipeline).ToListAsync();
    }

    public async Task BulkInsertAsync(IEnumerable<Airport> airports)
    {
        await _collection.InsertManyAsync(airports);
    }

    public async Task<IEnumerable<Airport>> GetSortedAndLimitedAsync(int limit)
    {
        return await _collection.Find(_ => true).Limit(limit).SortBy(a => a.Name).ToListAsync();
    }

    public async Task<IEnumerable<Airport>> GetFilteredAsync(string country)
    {
        return await _collection.Find(a => a.Country == country).ToListAsync();
    }

    public async Task<IEnumerable<Airport>> GetNearbyAirportsAsync(double latitude, double longitude, double distance)
    {
        var filter = Builders<Airport>.Filter.NearSphere(a => a.Location, new GeoJsonPoint(GeoJsonGeographicCoordinates.From(latitude, longitude)), distance);
        return await _collection.Find(filter).ToListAsync();
    }

    public async Task<IEnumerable<Airport>> SearchAsync(string searchText)
    {
        var filter = Builders<Airport>.Filter.Text(searchText);
        return await _collection.Find(filter).ToListAsync();
    }

    public async Task GenerateCSVAsync(IEnumerable<Airport> airports, string filePath)
    {
        // Logic to generate CSV file
    }

    public async Task UploadToAzureBlobAsync(string filePath, string containerName, string blobName)
    {
        // Logic to upload file to Azure Blob Storage
    }
    public void CreateIndexBTree()
    {
        var keys = Builders<Airport>.IndexKeys.Ascending("Name");
        var options = new CreateIndexOptions { Unique = true };
        _collection.Indexes.CreateOne(keys, options);
    }

    public void CreateTextIndex()
    {
        var keys = Builders<Airport>.IndexKeys.Text(x => x.Name, x => x.City, x => x.Country);
        _collection.Indexes.CreateOne(keys);
    }

    public void CreateGeospatialIndex()
    {
        var keys = Builders<Airport>.IndexKeys.Geo2DSphere(x => x.Location);
        _collection.Indexes.CreateOne(keys);
    }
    // Implement other CRUD methods
}
