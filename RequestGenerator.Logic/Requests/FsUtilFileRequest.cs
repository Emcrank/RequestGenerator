using System.Diagnostics;

namespace RequestGenerator.Logic.Requests;

public class FsUtilFileRequest : FileRequest
{
    private int minSizeMb = 1;
    private int maxSizeMb = 10;

    public override string Name => "FsUtil File Request";

    public override string Description => "Generates files using FsUtil of a random size between the min and max.";

    public int MinSizeMb
    {
        get => minSizeMb;
        set => SetField(ref minSizeMb, value);
    }

    public int MaxSizeMb
    {
        get => maxSizeMb;
        set => SetField(ref maxSizeMb, value);
    }

    public override string Generate(string destination, int index)
    {
        var substitutions = GetRequestSubstitutions(index);
        string outputFileName = GetOutputFileName(substitutions);
        string outputFilePath = Path.Combine(destination, outputFileName);

        long minSizeBytes = minSizeMb * 1024 * 1024;
        long maxSizeBytes = maxSizeMb * 1024 * 1024;

        long chosenSizeBytes = Random.Shared.NextInt64(minSizeBytes, maxSizeBytes);

        //fsutil file createnew <filename> <length>
        using var process = new Process();
        process.StartInfo = new ProcessStartInfo("fsutil.exe")
        {
            CreateNoWindow = true,
            UseShellExecute = false,
            Arguments = $"file createnew \"{outputFilePath}\" {chosenSizeBytes}"
        };

        process.Start();
        process.WaitForExit();

        return outputFileName;
    }
}