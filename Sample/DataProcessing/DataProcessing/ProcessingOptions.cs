namespace DataProcessing;

internal sealed class ProcessingOptions
{
    private readonly List<IOutputWriter> _outputWriters = new();

    public ProcessingOptions(ILoggerFactory loggerFactory)
    {
        
    }
}