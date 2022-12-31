namespace Calabonga.OperationResults;

/// <summary>
/// Metadata object base for all type  <see cref="IMetadataMessage"/>
/// </summary>
[Serializable]
public class Metadata : IMetadataMessage
{
    private readonly OperationResult? _source;

    public Metadata()
    {
        Type = MetadataType.Info;
        DataObject = new object();
    }

    public Metadata(OperationResult? source, string message)
        : this()
    {
        _source = source;
        Message = message;
    }

    public Metadata(OperationResult? source, string message, MetadataType type = MetadataType.Info)
        : this(source, message)
        => Type = type;

    public string? Message { get; }

    public MetadataType Type { get; }

    /// <inheritdoc />
    public object DataObject { get; private set; }

    /// <summary>
    /// Add special type of metadata
    /// </summary>
    /// <param name="data"></param>
    public void AddData(object data)
    {
        if (_source == null)
        {
            return;
        }

        if (data is Exception exception && _source.Metadata == null)
        {
            _source.Metadata = new Metadata(_source, exception.Message);
            return;
        }

        if (_source?.Metadata != null)
        {
            _source.Metadata.DataObject = data;
        }
    }
}