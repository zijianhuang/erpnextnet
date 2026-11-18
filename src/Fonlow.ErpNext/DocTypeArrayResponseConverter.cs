using Fonlow.ErpNext.DocTypes;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Fonlow.ErpNext
{
    /// <summary>
    /// ERPNext response data could be a single object or object array. This converter will normalize the data always into array.
    /// </summary>
    /// <typeparam name="DataT"></typeparam>
    public class DocTypeArrayResponseConverter<DataT> : JsonConverter<DocTypeArrayResponse<DataT>>
    {
        public override DocTypeArrayResponse<DataT> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using var doc = JsonDocument.ParseValue(ref reader);
            var root = doc.RootElement;

            if (!root.TryGetProperty("data", out var dataElement))
            {
                throw new JsonException("Missing 'data' property");
            }

            var response = new DocTypeArrayResponse<DataT>();

            if (dataElement.ValueKind == JsonValueKind.Array)
            {
                response.Data = JsonSerializer.Deserialize<DataT[]>(dataElement.GetRawText(), options);
            }
            else if (dataElement.ValueKind == JsonValueKind.Object)
            {
                var single = JsonSerializer.Deserialize<DataT>(dataElement.GetRawText(), options);
                response.Data = new[] { single };
            }
            else if (dataElement.ValueKind == JsonValueKind.Null)
            {
                response.Data = Array.Empty<DataT>();
            }
            else
            {
                throw new JsonException($"Unexpected 'data' format: {dataElement.ValueKind}");
            }

            return response;
        }

        public override void Write(Utf8JsonWriter writer, DocTypeArrayResponse<DataT> value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("data");
            JsonSerializer.Serialize(writer, value.Data, options);
            writer.WriteEndObject();
        }
    }

}
