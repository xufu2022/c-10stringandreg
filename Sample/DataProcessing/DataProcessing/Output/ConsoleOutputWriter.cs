namespace DataProcessing.Output;

public class ConsoleOutputWriter : IOutputWriter
{
    public Task WriteDataAsync(string? data, string pathAndFileName, CancellationToken cancellationToken = default)
    {
        var beforeColor = Console.ForegroundColor;
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine(data);
        Console.WriteLine();

        Console.ForegroundColor= beforeColor;
        return Task.CompletedTask;
    }
}