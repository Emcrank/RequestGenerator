using RequestGenerator.Logic.Data;

namespace RequestGenerator.Logic.Input;

public interface IInputData
{
    IDictionary<string, DataColumn> DataByHeader { get; }

    int DataCount { get; }

    int HeaderCount { get; }
}