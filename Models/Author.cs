using System.Collections.Generic;

namespace EF_Example.Models;

public record Author
{
    public int Id { get; init; }
    public string FullName { get; init; }
    
    public List<Book> Books { get; init; }
}