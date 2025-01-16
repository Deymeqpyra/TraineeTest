using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Persistence.Converters;

public class DateTimeUtcConverter() : ValueConverter<DateTime, DateTime>(
    time => time.ToUniversalTime(),
    time => time.Kind == DateTimeKind.Unspecified
        ? DateTime.SpecifyKind(time, DateTimeKind.Utc)
        : time.ToUniversalTime());
