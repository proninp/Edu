using HomeWork02.DataTransferObjects;

namespace HomeWork02.Models;

public class Person
{
    public required int Id { get; init; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Company { get; set; }
    public int Age { get; set; }
}