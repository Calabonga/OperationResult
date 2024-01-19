using System.Text.Json;
using System.Text.Json.Serialization;

namespace Calabonga.OperationResults;

public class OperationResultConverter<T> : JsonConverter<OperationResult<T>>
{
    public override OperationResult<T>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.StartObject)
        {
            throw new JsonException();
        }

        if (reader.TokenType == JsonTokenType.EndObject)
        {
            return OperationResult.CreateResult<T>();
        }

        var operation = OperationResult.CreateResult<T>();

        T result = default;

        while (reader.Read())
        {
            if (reader.TokenType == JsonTokenType.EndObject)
            {
                break;
            }

            if (reader.TokenType == JsonTokenType.PropertyName)
            {
                var propertyName = reader.GetString()?.ToLowerInvariant();

                reader.Read();

                switch (propertyName)
                {
                    case "metadata":

                        var converterMetadata = (JsonConverter<Metadata>)options.GetConverter(typeof(Metadata));
                        if (converterMetadata.CanConvert(typeof(Metadata)))
                        {
                            operation.Metadata = converterMetadata.Read(ref reader, typeof(Metadata), options)!;
                        }

                        break;

                    case "ok":
                        break;

                    case "result":

                        var converter = (JsonConverter<T>)options.GetConverter(typeof(T));
                        if (converter.CanConvert(typeof(T)))
                        {
                            operation.Result = converter.Read(ref reader, typeof(T), options)!;
                        }
                        break;
                }
            }
        }

        return operation;
    }

    public override void Write(Utf8JsonWriter writer, OperationResult<T> value, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }
}