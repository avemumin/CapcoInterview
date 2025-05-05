using BooksService.WebAPI.Data;
using BooksService.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksService.WebAPI.Services
{
  public interface IBookService
  {
    Task<Book> Add(Book book);
    Task<IEnumerable<Book>> GetAll();
  }
  public class BookService : IBookService
  {
    private readonly BookContext _bookContext;

    public BookService(BookContext bookContext)
    {
      _bookContext = bookContext;
    }

    public async Task<IEnumerable<Book>> GetAll()
    {
      var books = await _bookContext.Books.ToListAsync();

      return books;
    }
    public async Task<Book> Add(Book book)
    {
      _bookContext.Books.Add(book);
      await _bookContext.SaveChangesAsync();
      return book;
    }

   
  }
}
