public static class EndpointExtensions
{
    public static IEndpointRouteBuilder MapETLEndpoint(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("/api/etl", async context =>
        {
            var etlService = context.RequestServices.GetRequiredService<IAirportETLService>();
            await etlService.RunETLProcessAsync();
            await context.Response.WriteAsync("ETL process completed successfully.");
        });

        return endpoints;
    }
}
