namespace Calabonga.OperationResults
{
    /// <summary>
    /// IMetadataMessage and IHaveDataObject interface
    /// </summary>
    public interface IMetadataMessage : IHaveDataObject
    {
        /// <summary>
        /// Message
        /// </summary>
        string Message { get; }

        /// <summary>
        /// Data object
        /// </summary>
        object DataObject { get; }
    }
}
