public interface IAzureBlobStorageService
{
    Task UploadFileAsync(string filePath, string containerName, string blobName);
}
