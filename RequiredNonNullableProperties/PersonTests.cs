using System.Globalization;
using CsvHelper;
using FluentAssertions;

namespace RequiredNonNullableProperties;

public class PersonTests
{
    [Test]
    public void ReadFromCsv()
    {
        using var reader = new StreamReader("people.csv");
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        var records = csv.GetRecords<Person>().ToList();

        records.Select(records => records.FirstName).Should().NotBeNull();
        records.Select(records => records.LastName).Should().NotBeNull();
    }

    [Test]
    public void CreateInCode()
    {
        var person = new Person { FirstName = "John Doe", LastName = "Doe" };

        person.FirstName.Should().NotBeNull();
        person.LastName.Should().NotBeNull();
    }
}
