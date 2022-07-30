namespace DataProcessing.Output;

public class ThirdPartyOutputWriter: IOutputWriter
{
    public Task WriteDataAsync(string? data, string pathAndFileName, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(data);
        ArgumentNullException.ThrowIfNull(pathAndFileName);
        var exporter = new ThirdParty.Exporter.SomeCleverExporter(pathAndFileName);
        return exporter.WriteDataAsync(data, cancellationToken);
    }
}