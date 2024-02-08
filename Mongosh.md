# Mongo query
// Retrieve all airports
db.airports.find();

// Create a new airport
db.airports.insertOne({
    "Name": "New Airport",
    "City": "New City",
    "Country": "New Country",
    "IATA": "NEW",
    "ICAO": "NWA",
    "Latitude": 0,
    "Longitude": 0,
    "Altitude": 0,
    "Timezone": 0,
    "DST": "U",
    "TimezoneTz": "UTC",
    "Type": "airport",
    "Source": "Custom"
});

// Retrieve a specific airport by ID
var airportId = 1;
db.airports.findOne({ "Id": airportId });

// Update a specific airport
var airportIdToUpdate = 1;
db.airports.updateOne(
    { "Id": airportIdToUpdate },
    { $set: { "Name": "Updated Airport" } }
);

// Delete a specific airport
var airportIdToDelete = 1;
db.airports.deleteOne({ "Id": airportIdToDelete });

// Perform data aggregation on airports
db.airports.aggregate([
    { $group: { _id: "$Country", count: { $sum: 1 } } }
]);

// Generate a CSV file of airports (not applicable in MongoDB shell)

// Upload a CSV file to Azure Blob Storage (not applicable in MongoDB shell)

// Retrieve sorted and limited airports
db.airports.find().sort({ "Name": 1 }).limit(10);

// Retrieve airports filtered by country
var countryToFilter = "Papua New Guinea";
db.airports.find({ "Country": countryToFilter });

// Retrieve airports near a specified location
var latitude = 0;
var longitude = 0;
var maxDistance = 1000; // In meters
db.airports.find({
    "Location": {
        $nearSphere: {
            $geometry: {
                type: "Point",
                coordinates: [longitude, latitude]
            },
            $maxDistance: maxDistance
        }
    }
});

// Search airports based on a search text
var searchText = "airport";
db.airports.find({ $text: { $search: searchText } });
