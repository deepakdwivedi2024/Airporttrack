public class AirportRepository : IAirportRepository
{
    private readonly IMongoCollection<Airport> _collection;

    public AirportRepository(IMongoDatabase database)
    {
        _collection = database.GetCollection<Airport>("Airports");
    }

    public async Task<IEnumerable<Airport>> GetAllAsync()
    {
        return await _collection.Find(_ => true).ToListAsync();
    }

    public async Task<IEnumerable<BsonDocument>> AggregateAsync(BsonDocument[] pipeline)
    {
        return await _collection.AggregateAsync<BsonDocument>(pipeline).ToListAsync();
    }

    // Implement other CRUD methods
}
