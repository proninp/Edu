﻿namespace Lesson01;

public class Post
{
    public int UserId { get; set; }
    
    public int Id { get; set; }

    public string Title { get; set; }

    public string Body { get; set; }

    public override string? ToString() =>
        $"{UserId}\n{Id}\n{Title}\n{Body}";
}