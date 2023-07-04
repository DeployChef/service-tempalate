using System.Globalization;

namespace Template.Common.Converters;

public class TimeOnlyTypeConverter : StringTypeConverterBase<TimeOnly>
{
    protected override TimeOnly Parse(string value)
        => TimeOnly.ParseExact(value, TypeFormatConstants.TIME_ONLY_FORMAT, CultureInfo.InvariantCulture);

    protected override string ToString(TimeOnly source)
        => source.ToString(TypeFormatConstants.TIME_ONLY_FORMAT, CultureInfo.InvariantCulture);
}
