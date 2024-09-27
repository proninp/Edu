using Microsoft.AspNetCore.Mvc;
using Timesheets.Domain.Interfaces;
using Timesheets.Models.Dto;

namespace Timesheets.Controllers;

[ApiController]
[Route("[controller]")]
public class SheetController : ControllerBase
{
    private readonly ISheetManager _sheetManager;

    public SheetController(ISheetManager sheetManager)
    {
        _sheetManager = sheetManager;
    }

    [HttpGet]
    public IActionResult Get(Guid id)
    {
        var result = _sheetManager.GetItem(id);
        return Ok(result);
    }

    [HttpPost]
    public IActionResult Create([FromBody] SheetCreateRequest sheetDto)
    {
        var id = _sheetManager.Create(sheetDto);
        return Ok(id);
    }
}
