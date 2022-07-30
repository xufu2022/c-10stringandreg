namespace DataProcessing;

internal interface IOutputWriter
{
    public Task WriteDataAsync(string? data, string pathAndFileName, CancellationToken cancellationToken = default);
}
