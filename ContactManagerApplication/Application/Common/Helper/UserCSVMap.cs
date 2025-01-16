using CsvHelper.Configuration;
using Domain;

namespace Application.Common.Helper;

public class UserCsvMap : ClassMap<User>
{
    public UserCsvMap()
    {
        Map(u => u.Name).Name("Name");
        Map(u => u.DateOfBirth).Name("DateOfBirth");
        Map(u => u.Married).Name("Married");
        Map(u => u.Phone).Name("Phone");
        Map(m => m.Salary).Name("Salary");
    }
}