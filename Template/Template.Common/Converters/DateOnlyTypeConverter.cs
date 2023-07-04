using System.Globalization;

namespace Template.Common.Converters;

public class DateOnlyTypeConverter : StringTypeConverterBase<DateOnly>
{
    protected override DateOnly Parse(string value)
        => DateOnly.ParseExact(value, TypeFormatConstants.DATE_ONLY_FORMAT, CultureInfo.InvariantCulture);

    protected override string ToString(DateOnly source)
        => source.ToString(TypeFormatConstants.DATE_ONLY_FORMAT, CultureInfo.InvariantCulture);
}
