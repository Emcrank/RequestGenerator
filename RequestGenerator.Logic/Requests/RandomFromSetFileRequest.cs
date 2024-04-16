using System.Collections.ObjectModel;

namespace RequestGenerator.Logic.Requests;

public class RandomFromSetFileRequest : FileRequest
{
    public override string Name => "Random From Set File Request";
    public override string Description => "Generates a copy of a file at random from a set of pre-existing files.";

    public ObservableCollection<string> Files { get; } = new ObservableCollection<string>();

    public override string Generate(int index)
    {
        if (string.IsNullOrWhiteSpace(Destination))
            throw new InvalidOperationException("Destination was not set.");

        var substitutions = GetRequestSubstitutions(index);
        string outputFileName = GetOutputFileName(substitutions);
        string outputFilePath = Path.Combine(Destination, outputFileName);

        int randomIndex = Random.Shared.Next(0, Files.Count - 1);

        File.Copy(Files[randomIndex], outputFilePath, true);

        return outputFilePath;
    }
}