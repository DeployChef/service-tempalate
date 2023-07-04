using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Template.Common.Converters;

public class TimeOnlyJsonConverter : JsonConverter<TimeOnly>
{
    public override TimeOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();
        return string.IsNullOrEmpty(value)
            ? default
            : TimeOnly.ParseExact(value, TypeFormatConstants.TIME_ONLY_FORMAT, CultureInfo.InvariantCulture);
    }

    public override void Write(Utf8JsonWriter writer, TimeOnly value, JsonSerializerOptions options)
        => writer.WriteStringValue(value.ToString(TypeFormatConstants.TIME_ONLY_FORMAT, CultureInfo.InvariantCulture));
}
