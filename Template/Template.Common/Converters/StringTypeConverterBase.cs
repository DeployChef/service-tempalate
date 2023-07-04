using System.ComponentModel;
using System.Globalization;

namespace Template.Common.Converters;

public abstract class StringTypeConverterBase<T> : TypeConverter
{
    protected abstract T? Parse(string value);

    protected abstract string? ToString(T source);

    public override bool CanConvertFrom(ITypeDescriptorContext? context, Type sourceType)
        => sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);

    public override object? ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value)
        => value is string str ? Parse(str) : base.ConvertFrom(context, culture, value);

    public override bool CanConvertTo(ITypeDescriptorContext? context, Type? destinationType)
        => destinationType == typeof(string) || base.CanConvertTo(context, destinationType);

    public override object? ConvertTo(ITypeDescriptorContext? context, CultureInfo? culture, object? value, Type destinationType)
        => destinationType == typeof(string) && value is T typedValue
            ? ToString(typedValue)
            : base.ConvertTo(context, culture, value, destinationType);
}