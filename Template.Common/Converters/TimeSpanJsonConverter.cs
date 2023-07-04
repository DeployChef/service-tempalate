using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Template.Common.Converters;

public class TimeSpanJsonConverter : JsonConverter<TimeSpan>
{
    public override TimeSpan Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();
        return string.IsNullOrEmpty(value)
            ? default
            : TimeSpan.ParseExact(value, TypeFormatConstants.TIME_SPAN_FORMAT, CultureInfo.InvariantCulture);
    }

    public override void Write(Utf8JsonWriter writer, TimeSpan value, JsonSerializerOptions options)
        => writer.WriteStringValue(value.ToString(TypeFormatConstants.TIME_SPAN_FORMAT, CultureInfo.InvariantCulture));
}
