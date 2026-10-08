using System;
using System.Linq;

using EF_Example;
using EF_Example.Models;

using Microsoft.EntityFrameworkCore;

const string path = @"C:\Programming\EF_Example\books.db";

using (var db = new DataBaseContext(path))
{
    var author1 = new Author() { FullName = "Эрих Мария Ремарк" };
    var author2 = new Author() { FullName = "Ильф" };
    var author3 = new Author() { FullName = "Петров" };

    var book1 = new Book() { Title = "Три товарища", Authors = [author1]};
    var book2 = new Book() {Title = "12 стульев", Authors = [author2, author3]};

    db.Authors.AddRange(author1, author2, author3);
    db.Books.AddRange(book1, book2);
    db.SaveChanges();
}

using (var db = new DataBaseContext(path))
{
    var books = db.Books
        .Include(b => b.Authors)
        .ToList();
    foreach (var book in books)
    {
        Console.WriteLine($"{book.Title} - {string.Join(", ", book.Authors.Select(a => a.FullName))}");
    }
}

