using System.Collections.Generic;

namespace EF_Example.Models;

public record Book
{
    public int Id { get; init; }
    public string Title { get; init; }
    
    public List<Author> Authors { get; init; }
}