using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Template.Common.Data.Configurations;

public abstract class EntityTypeConfiguration<T> : IEntityTypeConfiguration<T> where T : Entity
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.HasKey(i => i.Id);
        builder.Property(i => i.Id).HasColumnName("id").ValueGeneratedOnAdd().HasComment("Идентификатор");
        builder.Property(i => i.CreatedAt).HasColumnName("created_at").IsRequired().HasComment("Дата и время создания");
        builder.Property(i => i.UpdatedAt).HasColumnName("updated_at").IsRequired().HasComment("Дата м время обновления");
    }
}