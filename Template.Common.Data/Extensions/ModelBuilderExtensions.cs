using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Template.Common.Data.Extensions;

public static class ModelBuilderExtensions
{
    private const string IS_UTC_ANNOTATION = "IsUtcDate";
    private static readonly ValueConverter<DateTime, DateTime> UTC_CONVERTER = new(i => i, i => DateTime.SpecifyKind(i, DateTimeKind.Utc));

    public static void IsUtc<TProperty>(this PropertyBuilder<TProperty> builder, bool defaultValue = true)
    {
        builder.HasAnnotation(IS_UTC_ANNOTATION, defaultValue);
    }

    public static void ApplyUtcDateTimeConverter(this ModelBuilder builder, bool defaultValue = true)
    {
        foreach (var entityType in builder.Model.GetEntityTypes())
        {
            foreach (var property in entityType.GetProperties())
            {
                if (!((bool?)property.FindAnnotation(IS_UTC_ANNOTATION)?.Value ?? defaultValue))
                    continue;

                if (property.ClrType == typeof(DateTime) || property.ClrType == typeof(DateTime?))
                {
                    property.SetValueConverter(UTC_CONVERTER);
                }
            }
        }
    }
}