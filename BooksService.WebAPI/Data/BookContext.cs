using BooksService.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksService.WebAPI.Data
{
  public class BookContext : DbContext
  {
    public BookContext(DbContextOptions<BookContext> options) : base(options)
    {

    }
    public DbSet<Book> Books { get; set; }
  }
}
