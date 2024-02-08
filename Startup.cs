public void ConfigureServices(IServiceCollection services)
{
    services.AddControllers();
    services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "Airport API", Version = "v1" });
    });

    services.AddSingleton<IMongoClient>(sp =>
    {
        var mongoConnectionString = Configuration.GetConnectionString("MongoConnection");
        return new MongoClient(mongoConnectionString);
    });

    services.AddScoped<IMongoDatabase>(sp =>
    {
        var client = sp.GetService<IMongoClient>();
        var dbName = Configuration.GetValue<string>("MongoDB:DatabaseName");
        return client.GetDatabase(dbName);
    });

    services.AddScoped<IAirportRepository, AirportRepository>();
}
