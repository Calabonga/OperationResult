namespace Calabonga.OperationResults;

/// <summary>
/// Interface for data object fluent Api implementation
/// </summary>
public interface IHaveDataObject
{
    /// <summary>
    /// Adds data to your operation result some type.
    /// </summary>
    /// <param name="data"></param>
    void AddData(object data);
}