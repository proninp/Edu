using Timesheets.Data.Interfaces;
using Timesheets.Models;

namespace Timesheets.Data.Implementation;

public class SheetRepo : ISheetRepo
{
    private List<Sheet> Sheets { get; set; } = new List<Sheet>()
    {
        new Sheet
        {
            Id = Guid.Parse("93A5781E-13DB-0933-96FC-99024A967BAD"),
            Date = DateTime.Parse("2025-09-02 10:45:15"),
            EmployeeId = Guid.Parse("52B7EC3F-A16C-1C63-714A-6F72FFADA61D"),
            ContractId = Guid.Parse("CB419673-7867-90C5-2916-582AE218661E"),
            ServiceId = Guid.Parse("794C0235-D6AF-AEB2-6EA8-2D599AE662F4"),
            Amount = 4
        },
        new Sheet
        {
            Id = Guid.Parse("7A9D6366-52CC-786A-5F14-0B91FC9507FA"),
            Date = DateTime.Parse("2024-04-25 06:10:41"),
            EmployeeId = Guid.Parse("ACCD72C7-B513-7D97-53C8-29DABA236CE0"),
            ContractId = Guid.Parse("4138BD95-1F93-6450-1D91-0A73F17CCA72"),
            ServiceId = Guid.Parse("61D7E761-EE08-314D-68D4-795772C26C94"),
            Amount = 8
        },
        new Sheet{
            Id = Guid.Parse("A2C6CBAD-55E2-AB2A-14E1-79357609D902"),
            Date = DateTime.Parse("2024-06-25 20:32:32"),
            EmployeeId = Guid.Parse("DCE684B9-6D4C-3214-4E85-D24DE0E2D6FC"),
            ContractId = Guid.Parse("12DA788B-7C45-A3C8-A04D-565464850DE0"),
            ServiceId = Guid.Parse("3ECE7A22-E1F3-E63C-590A-6295BA359494"),
            Amount = 2
        },
        new Sheet{
            Id = Guid.Parse("B28B5800-18B1-819C-1936-5ADCFDBABFCB"),
            Date = DateTime.Parse("2023-12-28 22:20:09"),
            EmployeeId = Guid.Parse("5EC8C212-2C21-D2CC-46CE-A354938028B5"),
            ContractId = Guid.Parse("3F341BD8-A90A-257E-16D9-21C6B3162BE0"),
            ServiceId = Guid.Parse("3A8DBD28-6A86-B9E9-6797-241E4A7D9268"),
            Amount = 8
        },
        new Sheet{
            Id = Guid.Parse("D1BEB515-2D5A-1B25-C7A8-D234411602B5"),
            Date = DateTime.Parse("2025-02-21 10:15:22"),
            EmployeeId = Guid.Parse("B7E176DE-435C-C2CE-5117-6358DC9911BF"),
            ContractId = Guid.Parse("75E5CE5D-48CC-CC63-2D72-E1064B8FB959"),
            ServiceId = Guid.Parse("0E222829-5B26-BA91-2198-B4386981D5CC"),
            Amount = 5
        }
    };

    public void Add(Sheet item)
    {
        Sheets.Add(item);
    }

    public Sheet GetItem(Guid id)
    {
        return Sheets.FirstOrDefault(x => x.Id == id);
    }

    public IEnumerable<Sheet> GetItems()
    {
        throw new NotImplementedException();
    }

    public void Update()
    {
        throw new NotImplementedException();
    }
}
