# Airport API
Overview
The Airport API is a .NET Core Web API prototype that provides endpoints for managing airport data. It integrates with MongoDB for data storage, implements Swagger documentation for API documentation, includes data aggregation pipelines, and provides an ETL endpoint for Extract, Transform, Load operations. Additionally, it supports uploading files to Azure Blob Storage.

Features
CRUD operations for managing airport data
Data aggregation pipelines for advanced analytics
Swagger documentation for API endpoints
ETL endpoint for data processing
Upload functionality to Azure Blob Storage

Features
CRUD operations for managing airport data
Data aggregation pipelines for advanced analytics
Swagger documentation for API endpoints
ETL endpoint for data processing
Upload functionality to Azure Blob Storage
Installation
Clone the repository:

bash
git clone https://github.com/yourusername/airport-api.git
Navigate to the project directory:

bash
cd airport-api
Restore NuGet packages:

bash
dotnet restore
Configure MongoDB connection:

Open appsettings.json.
Update the MongoConnection string with your MongoDB connection string.
Update the DatabaseName with your MongoDB database name.
Configure Azure Blob Storage (if needed):

Open appsettings.json.
Update the BlobStorageConnectionString with your Azure Blob Storage connection string.
Usage
Run the application:

bash
dotnet run
Open Swagger UI:

Navigate to https://localhost:5001/swagger in your web browser to view the API documentation and test the endpoints.

Explore API Endpoints:

Use Swagger UI to explore and test the available endpoints for CRUD operations, data aggregation, ETL, and file upload.


Open Swagger UI:

Navigate to https://localhost:5001/swagger in your web browser to view the API documentation and test the endpoints.

Explore API Endpoints:

Use Swagger UI to explore and test the available endpoints for CRUD operations, data aggregation, ETL, and file upload.

GET /api/airports: Retrieves all airports.

POST /api/airports: Creates a new airport.

GET /api/airports/{id}: Retrieves a specific airport by ID.

PUT /api/airports/{id}: Updates a specific airport.

DELETE /api/airports/{id}: Deletes a specific airport.

GET /api/airports/aggregate: Performs data aggregation on airports.

POST /api/airports/csv: Generates a CSV file of airports.

POST /api/airports/upload-to-azure-blob: Uploads a CSV file to Azure Blob Storage.

GET /api/airports/sorted: Retrieves sorted and limited airports.

GET /api/airports/filtered: Retrieves airports filtered by country.

GET /api/airports/nearby: Retrieves airports near a specified location.

GET /api/airports/search: Searches airports based on a search text.

ETL Process:

The ETL (Extract, Transform, Load) process can be initiated by sending a POST request to the /api/etl endpoint. This endpoint triggers the ETL process asynchronously.

File Structure
Controllers/: Contains controller classes defining API endpoints.
Models/: Contains model classes representing airport data.
Repositories/: Contains repository classes for interacting with MongoDB.
Services/: Contains service classes such as ETL service and Azure Blob Storage service.
appsettings.json: Configuration file for MongoDB connection and Azure Blob Storage settings.
Startup.cs: Configures services and middleware for the application.
License
