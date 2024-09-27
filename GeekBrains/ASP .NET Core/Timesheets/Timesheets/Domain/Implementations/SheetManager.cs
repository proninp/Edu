using Timesheets.Data.Interfaces;
using Timesheets.Domain.Interfaces;
using Timesheets.Models;
using Timesheets.Models.Dto;

namespace Timesheets.Domain.Implementations;

public class SheetManager : ISheetManager
{
    private readonly ISheetRepo _sheetRepo;

    public SheetManager(ISheetRepo sheetRepo)
    {
        _sheetRepo = sheetRepo;
    }

    public Guid Create(SheetCreateRequest sheetDto)
    {
        var sheet = new Sheet
        {
            Id = Guid.NewGuid(),
            Date = sheetDto.Date,
            ContractId = sheetDto.ContractId,
            EmployeeId = sheetDto.EmployeeId,
            ServiceId = sheetDto.ServiceId,
            Amount = sheetDto.Amount
        };
        _sheetRepo.Add(sheet);
        return sheet.Id;
    }

    public Sheet GetItem(Guid id)
    {
        return _sheetRepo.GetItem(id);
    }


}
