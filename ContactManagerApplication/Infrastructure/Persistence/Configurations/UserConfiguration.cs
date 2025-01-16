using Domain;
using Infrastructure.Persistence.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(x=>x.Name).IsRequired().HasColumnType("nvarchar(255)");
        builder.Property(x=>x.Phone).IsRequired().HasColumnType("varchar(11)");
        builder.Property(x=>x.Salary).IsRequired().HasColumnType("decimal(18,2)");
        builder.Property(x=>x.Married).IsRequired().HasColumnType("bit");

        builder.Property(x => x.DateOfBirth)
            .HasConversion(new DateTimeUtcConverter())
            .HasDefaultValueSql("GETUTCDATE()");
    }
}