public interface IAirportRepository
{
    Task<IEnumerable<Airport>> GetAllAsync();
    Task<IEnumerable<BsonDocument>> AggregateAsync(BsonDocument[] pipeline);
    // Other CRUD methods
}
