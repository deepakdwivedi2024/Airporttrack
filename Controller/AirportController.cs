[Route("api/[controller]")]
[ApiController]
public class AirportController : ControllerBase
{
    private readonly IAirportRepository _repository;

    public AirportController(IAirportRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Airport>>> Get()
    {
        var airports = await _repository.GetAllAsync();
        return Ok(airports);
    }

    [HttpGet("aggregate")]
    public async Task<ActionResult<IEnumerable<BsonDocument>>> Aggregate()
    {
        var pipeline = new[]
        {
            BsonDocument.Parse("{$match: { Country: 'Papua New Guinea' } }"),
            BsonDocument.Parse("{$group: { _id: '$City', count: { $sum: 1 } } }")
        };

        var result = await _repository.AggregateAsync(pipeline);
        return Ok(result);
    }

    [HttpGet("sorted")]
     public async Task<ActionResult<IEnumerable<Airport>>> GetSortedAndLimited([FromQuery] int limit)
    {
       var airports = await _repository.GetSortedAndLimitedAsync(limit);
       return Ok(airports);
    }

    [HttpGet("filtered")]
     public async Task<ActionResult<IEnumerable<Airport>>> GetFiltered([FromQuery] string country)
    {
       var airports = await _repository.GetFilteredAsync(country);
       return Ok(airports);
    }

     [HttpGet("nearby")]
    public async Task<ActionResult<IEnumerable<Airport>>> GetNearbyAirports([FromQuery] double latitude, [FromQuery] double longitude, [FromQuery] double distance)
    {
      var airports = await _repository.GetNearbyAirportsAsync(latitude, longitude, distance);
      return Ok(airports);
    }

  [HttpGet("search")]
   public async Task<ActionResult<IEnumerable<Airport>>> Search([FromQuery] string searchText)
   {
    var airports = await _repository.SearchAsync(searchText);
    return Ok(airports);
   }

[HttpPost("csv")]
  public async Task<IActionResult> GenerateCSV()
  {
    var airports = await _repository.GetAllAsync();
    var filePath = "path/to/csv/file.csv";
    await _repository.GenerateCSVAsync(airports, filePath);
    return Ok("CSV file generated successfully.");
  }

[HttpPost("upload-to-azure-blob")]
   public async Task<IActionResult> UploadToAzureBlob()
  {
    var filePath = "path/to/csv/file.csv";
    var containerName = "your-container-name";
    var blobName = "your-blob-name";
    await _repository.UploadToAzureBlobAsync(filePath, containerName, blobName);
    return Ok("File uploaded to Azure Blob Storage successfully.");
   }

   [HttpPost("index/btree")]
    public IActionResult CreateBTreeIndex()
    {
        _repository.CreateIndexBTree();
        return Ok("B-tree index created successfully.");
    }
    
   [HttpPost("index/text")]
    public IActionResult CreateTextIndex()
    {
        _repository.CreateTextIndex();
        return Ok("Text index created successfully.");
    }

    [HttpPost("index/geospatial")]
    public IActionResult CreateGeospatialIndex()
    {
        _repository.CreateGeospatialIndex();
        return Ok("Geospatial index created successfully.");
    }

    [HttpPost("index/bucket")]
    public IActionResult CreateBucketIndex()
    {
        _repository.CreateBucketIndex();
        return Ok("Bucket index created successfully.");
    }
    // Implement other CRUD endpoints

}
