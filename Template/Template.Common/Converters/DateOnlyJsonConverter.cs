using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Template.Common.Converters;

public class DateOnlyJsonConverter : JsonConverter<DateOnly>
{
    public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();
        return string.IsNullOrEmpty(value)
            ? default
            : DateOnly.ParseExact(value, TypeFormatConstants.DATE_ONLY_FORMAT, CultureInfo.InvariantCulture);
    }

    public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
        => writer.WriteStringValue(value.ToString(TypeFormatConstants.DATE_ONLY_FORMAT, CultureInfo.InvariantCulture));
}