using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class AirportETLService : IAirportETLService
{
    private readonly IAirportRepository _repository;

    public AirportETLService(IAirportRepository repository)
    {
        _repository = repository;
    }

    public async Task RunETLProcessAsync()
    {
        // 1. Extract data (for example, from an external API or database)
        var extractedData = await ExtractDataAsync();

        // 2. Transform data (modify or enrich the extracted data)
        var transformedData = TransformData(extractedData);

        // 3. Load data (store the transformed data in the database)
        await LoadDataAsync(transformedData);
    }

    private async Task<IEnumerable<Airport>> ExtractDataAsync()
    {
        // Example: Retrieve data from an external API or database
        // This method should return a collection of Airport objects
        // Replace this with your actual data extraction logic
        return await ExternalAPIService.GetAirportsAsync();
    }

    private IEnumerable<Airport> TransformData(IEnumerable<Airport> data)
    {
        // Example: Modify or enrich the extracted data
        // This method should return the transformed data
        // Replace this with your actual data transformation logic
        var transformedData = new List<Airport>();
        foreach (var airport in data)
        {
            // Example transformation: Convert latitude and longitude to radians
            airport.Latitude = ToRadians(airport.Latitude);
            airport.Longitude = ToRadians(airport.Longitude);
            transformedData.Add(airport);
        }
        return transformedData;
    }

    private async Task LoadDataAsync(IEnumerable<Airport> data)
    {
        // Example: Store the transformed data in the database
        // This method should persist the data in the database
        // Replace this with your actual data loading logic
        await _repository.BulkInsertAsync(data);
    }

    private double ToRadians(double degree)
    {
        return degree * Math.PI / 180;
    }
}
