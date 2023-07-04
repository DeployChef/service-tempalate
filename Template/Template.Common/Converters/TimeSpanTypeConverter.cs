using System.Globalization;

namespace Template.Common.Converters;

public class TimeSpanTypeConverter : StringTypeConverterBase<TimeSpan>
{
    protected override TimeSpan Parse(string value)
        => TimeSpan.ParseExact(value, TypeFormatConstants.TIME_SPAN_FORMAT, CultureInfo.InvariantCulture);

    protected override string ToString(TimeSpan source)
        => source.ToString(TypeFormatConstants.TIME_SPAN_FORMAT, CultureInfo.InvariantCulture);
}