﻿using HomeWork02.Models;
using System.Text.Json;
using System.Xml.Serialization;

namespace HomeWork02.Utilities;

public class PersonLoader
{
    public static List<Person> LoadPersons()
    {
        var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "data.json");
        if (!File.Exists(filePath))
            throw new FileNotFoundException($"File not found: {filePath}");

        var jsonString = File.ReadAllText(filePath);

        return JsonSerializer.Deserialize<List<Person>>(jsonString)
               ?? new List<Person>();
    }
}