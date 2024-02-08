public class AzureBlobStorageService : IAzureBlobStorageService
{
    private readonly BlobServiceClient _blobServiceClient;

    public AzureBlobStorageService(IAzureBlobStorageSettings settings)
    {
        _blobServiceClient = new BlobServiceClient(settings.ConnectionString);
    }

    public async Task UploadFileAsync(string filePath, string containerName, string blobName)
    {
        var blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);
        var blobClient = blobContainerClient.GetBlobClient(blobName);

        using (var fileStream = File.OpenRead(filePath))
        {
            await blobClient.UploadAsync(fileStream, true);
        }
    }
}
