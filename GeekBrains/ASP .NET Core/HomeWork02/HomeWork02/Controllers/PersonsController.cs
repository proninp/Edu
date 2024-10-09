using HomeWork02.DataTransferObjects;
using HomeWork02.Domain.Interfaces;
using HomeWork02.Models;
using Microsoft.AspNetCore.Mvc;

namespace HomeWork02.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonsController : ControllerBase
{
    private IPersonManager _personManager;

    public PersonsController(IPersonManager personManager)
    {
        _personManager = personManager;
    }

    [HttpGet("{id}")]
    public ActionResult<Person> GetPersonById(int id)
    {
        var result = _personManager.GetPerson(id);
        if (result is null)
            return NotFound();
        return Ok(result);
    }

    [HttpGet("search")]
    public ActionResult<List<Person>> GetPersonBySearchTerm(string term)
    {
        var result = _personManager.GetPerson(term);
        if (result is null)
            return NotFound();
        return Ok(result);
    }

    [HttpGet]
    public ActionResult<IEnumerable<Person>> GetPersons([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        if (take <= 0 || skip < 0)
            return BadRequest("Take parameter must be greater than 0.");
        var persons = _personManager.GetPersons(skip, take);
        if (persons is null)
            return NotFound();
        return Ok(persons);
    }

    [HttpPost]
    public ActionResult<int> AddPerson(PersonDto person)
    {
        return Ok(_personManager.Create(person));
    }
}
